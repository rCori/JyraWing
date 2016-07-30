using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, PauseableItem {

	public bool DEBUGNODAMAGE;

	[System.Flags]
	public enum Direction
	{
		None = 0,
		Up = 1,
		Down = 2,
		Left = 4,
		Right = 8
	}

	public enum VertDir
	{
		None = 0,
		Up = 1,
		Down = 2
	}

	public enum HorizDir
	{
		None = 0,
		Left = 1,
		Right = 2
	}


	private GameController gameController;
	private float speed;
	Animator animator;
	int hits;
	int numBullets;
	private AudioSource damageSfx;
	private float hitTimer;
	private IPlayerShield playerShield;

	private Vector3 startSavePos;
	private Vector3 endSavePos;
	private Vector3 pauseSavePos;

	private float horiz;
	private float vert;

	public enum TakingDamage
	{
		NONE = 0,
		EXPLODE,
		RETURNING,
		BLINKING
	}
	private TakingDamage takingDamage;

	private bool _paused;

	public delegate void PlayerDamageEvent (TakingDamage takingDamage);
	public static event PlayerDamageEvent HitEvent;
	public delegate void PlayerEvent ();
	public static event PlayerEvent InitLives, TakeDamageEvent, ResetEvent;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent <Animator> ();
		hitTimer = 0.0f;
		hits = 3;
		numBullets = 20;
		damageSfx = gameObject.AddComponent<AudioSource> ();
		//Sound when the player is hit
		damageSfx.clip = Resources.Load ("Audio/SFX/playerDamage") as AudioClip;
		speed = 3.0f;

		//The shield we will get assigned by instantiating the shield GameObject and then extracting
		//the shield interface from that game object
		GameObject playerShieldObject = Resources.Load ("PlayerShield") as GameObject;
		playerShieldObject = Instantiate (playerShieldObject);
		//Use the GameObject to get the PlayerShield interface
		PlayerShieldBehaviour playerShieldBehaviour = playerShieldObject.GetComponent<PlayerShieldBehaviour>();
		//Get the same GameController reference from the player for player shield
		playerShieldBehaviour.gameController = gameController;
		playerShield = playerShieldBehaviour.GetPlayerShield();

		gameController = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController ();
		_paused = false;
		RegisterToList ();

		horiz = 0f;
		vert = 0f;

		PlayerInputController.UpDownEvent += updatePlayerVert;
		PlayerInputController.LeftRightEvent += updatePlayerHoriz;
		CountdownTimer.PlayerContinueEvent += ResetTakingDamage;
		CountdownTimer.PlayerContinueEvent += () =>  StartCoroutine (returningFromHitRoutine ());
		Player.TakeDamageEvent += TakeDamage;
	}
	
	// Update is called once per frame
	void Update () {
		if (_paused) {
			//Hoping this prevents the corner drifiting bug.
			transform.position = pauseSavePos;
			transform.rotation.Set(0f,0f,0f,0f);
			return;
		}

		//update the position of the shield sprite
		playerShield.spritePosition = gameObject.transform.position;

	}

	/// <summary>
	/// Take damage from the enemy bullet
	/// </summary>
	public void TakeDamage(){
		//take out taking damage for now
		hits--;
		GetComponent<Rigidbody2D> ().velocity = new Vector2(0f, 0f);
		//Get the length of the animation.
		hitTimer = 2.5f;
		damageSfx.Play();
		takingDamage = TakingDamage.EXPLODE;
		StartCoroutine(returningFromHitRoutine());
		HitEvent (TakingDamage.EXPLODE);
		playerShield.DisableShield ();
		if (hits == 0) {
			gameController.PlayerKilled ();
		}
	}


	//Public interface needed by the game controller
	/// <summary>
	/// Getter for the number of lives remaining
	/// </summary>
	/// <returns>Number of player lives.</returns>
	public int LifeCount()
	{
		return hits;
	}

	public bool HasShield(){
		return playerShield.HasShield();
	}

	private void updatePlayerVert(float value) {
		vert = value;
		updatePlayerMovement ();
	}

	private void updatePlayerHoriz(float value) {
		horiz = value;
		updatePlayerMovement ();
	}

	private void updatePlayerMovement() {
		if (takingDamage == TakingDamage.BLINKING || takingDamage == TakingDamage.NONE) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (horiz, vert) * speed;
		}
	}
		
	IEnumerator returningFromHitRoutine(){
		yield return new WaitForSeconds (2f);
		endSavePos = new Vector2 (-2.5f, 0f);
		gameObject.transform.position = new Vector2 (-9.5f, 0f);
		startSavePos = gameObject.transform.position;
		takingDamage = TakingDamage.RETURNING;
		HitEvent (TakingDamage.RETURNING);
		yield return new WaitForSeconds (2f);
		float startTime = Time.time;
		while (Time.time < startTime + 2.5f) {
			gameObject.transform.position = Vector3.Lerp(startSavePos, endSavePos, (Time.time - startTime) / 1.2f);
			yield return null;
		}
		gameObject.transform.position = endSavePos;
		takingDamage = TakingDamage.BLINKING;
		HitEvent (TakingDamage.BLINKING);
		yield return new WaitForSeconds (4.0f);
		playerShield.EnableShield ();
		hitTimer = 0.0f;
		takingDamage = TakingDamage.NONE;
		HitEvent (TakingDamage.NONE);
	}

	//Make sure the player is removed from the list although actually this shouldn't be necssary
	void OnDestroy()
	{
		RemoveListeners ();
		RemoveFromList ();
	}

	/* Implementation of PauseableItem interface */
	public bool paused
	{
		get
		{
			return _paused;
		}
		
		set{
			_paused = value;
			if(_paused){
				pauseSavePos = transform.position;
				GetComponent<Rigidbody2D> ().velocity = new Vector2(0f, 0f);
				//I am hoping this fixes the drift by mashing pause in the corner bug.
				animator.speed = 0f;
			}
			else{
				animator.speed = 1f;
			}
		}
	}
	
	public void RegisterToList()
	{
		if (GameObject.Find ("PauseController")) {
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().RegisterPauseableItem(this);
		}
	}
	
	public void RemoveFromList()
	{
		if (GameObject.Find ("PauseController")) {
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().DelistPauseableItem(this);
		}
	}

	//By having the player handle it's own collision with enemy objects the
	//"hiding inside an enemy" bug has been handled.
	public void OnTriggerEnter2D(Collider2D other){
		bool bulletHit = false;
		bool enemyHit = false;
		if (other.tag == "EnemyBullet" && hitTimer == 0.0f && !DEBUGNODAMAGE) {
			EnemyBullet enemyBullet = other.GetComponent<EnemyBullet> ();
			if (!(enemyBullet.GetIsShieldable () && HasShield ())) {
				enemyHit = true;
			}
		}
		if(other.tag == "Enemy" && hitTimer == 0.0f && !DEBUGNODAMAGE) {
			bulletHit = true;
		}
		if (enemyHit || bulletHit) {
			TakeDamageEvent ();
		}
	}

	public void RemoveListeners() {
		PlayerInputController.UpDownEvent -= updatePlayerVert;
		PlayerInputController.LeftRightEvent -= updatePlayerHoriz;
		CountdownTimer.PlayerContinueEvent -= ResetTakingDamage;
		CountdownTimer.PlayerContinueEvent -= () =>  StartCoroutine (returningFromHitRoutine ());
		Player.TakeDamageEvent -= TakeDamage;
	}

	public void ResetTakingDamage() {
		takingDamage = TakingDamage.RETURNING;
		hitTimer = 2.0f;
		hits = 3;
	}

	public bool IsPlayerTakingDamage() {
		if (takingDamage != TakingDamage.NONE) {
			return true;
		} else {
			return false;
		}
	}

}
