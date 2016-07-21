using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, PauseableItem {

	public bool DEBUGNODAMAGE;
//	public bool DEBUGMAXBULLETLEVEL;
//	public bool DEBUGMAXSPEEDLEVEL;

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


	//public GameController gameController;
	private GameController gameController;
	private float speed;
	//private List<GameObject> bulletPool;
	Animator animator;
	int hits;
	int numBullets;
	private AudioSource damageSfx;
	private float hitTimer;
	//private PlayerSpeed playerSpeed;
	//private PlayerBulletLevel bulletLevel;
	//private OldPlayerInputController playerInputController;
	private IPlayerShield playerShield;

	private Vector3 startSavePos;
	private Vector3 endSavePos;
	private Vector3 pauseSavePos;

	private float horiz;
	private float vert;

	//private bool takingDamage;
	public enum TakingDamage
	{
		NONE = 0,
		EXPLODE,
		RETURNING,
		BLINKING
	}
	private TakingDamage takingDamage;

	private bool _paused;

	public delegate void PlayerEvent (TakingDamage takingDamage);
	public static event PlayerEvent HitEvent;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent <Animator> ();
		hitTimer = 0.0f;
		hits = 3;
		numBullets = 20;
		damageSfx = gameObject.AddComponent<AudioSource> ();
		//Sound when the player is hit
		damageSfx.clip = Resources.Load ("Audio/SFX/playerDamage") as AudioClip;

		//Helper classes and components for the player
		//playerSpeed = new PlayerSpeed ();
		//bulletLevel = new PlayerBulletLevel ();
		//playerInputController = new OldPlayerInputController ();
		speed = 3.0f;

		//The shield we will get assigned by instantiating the shield GameObject and then extracting
		//the shield interface from that game object
		GameObject playerShieldObject = Resources.Load ("PlayerShield") as GameObject;
		playerShieldObject = Instantiate (playerShieldObject);
		//Use the GameObject to get the PlayerShield interface
		PlayerShieldBehaviour playerShieldBehaviour = playerShieldObject.GetComponent<PlayerShieldBehaviour>();
		//Get the same GameController reference from the player for player shield
		playerShieldBehaviour.gameController = gameController;
		//playerShieldBehaviour.playerInputController = playerInputController;
		playerShield = playerShieldBehaviour.GetPlayerShield();

		gameController = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController ();
		_paused = false;
		RegisterToList ();

//		//Set direction to non
//		if (DEBUGMAXBULLETLEVEL) {
////			IncreaseBulletLevel();
////			IncreaseBulletLevel();
////			IncreaseBulletLevel();
//		}
//		if (DEBUGMAXSPEEDLEVEL) {
//			playerSpeed.IncreaseSpeedCap ();
//			playerSpeed.IncreaseSpeedCap ();
//			playerSpeed.IncreaseSpeedCap ();
//		}

		horiz = 0f;
		vert = 0f;

		//PlayerInputController.ChangeSpeedButton += ToggleSpeed;
		PlayerInputController.UpDownEvent += updatePlayerVert;
		PlayerInputController.LeftRightEvent += updatePlayerHoriz;
		CountdownTimer.PlayerContinueEvent += ResetTakingDamage;
	}
	
	// Update is called once per frame
	void Update () {
		if (_paused) {
			//Hoping this prevents the corner drifiting bug.
			transform.position = pauseSavePos;
			transform.rotation.Set(0f,0f,0f,0f);
			return;
		}
		//Update position
		//updatePlayerMovement ();

		//playerInputController.PlayerInputUpdate ();

		updateHitStatus (Time.deltaTime);

		//update the position of the shield sprite
		playerShield.spritePosition = gameObject.transform.position;

	}

	/// <summary>
	/// Take damage from the enemy bullet
	/// </summary>
	public void TakeDamage(){
		if (hitTimer == 0.0f && !DEBUGNODAMAGE) {
			//take out taking damage for now
			hits--;
			GetComponent<Rigidbody2D> ().velocity = new Vector2(0f, 0f);
			//animator.SetInteger ("animState", 1);
			//Get the length of the animation.
			hitTimer = 2.5f;
			gameController.DecreaseLifeCount();
			//playerInputController.DisableControls(true);
			//playerInputController.DisableShield(true);
			damageSfx.Play();
			takingDamage = TakingDamage.EXPLODE;
			HitEvent (TakingDamage.EXPLODE);
			playerShield.DisableShield ();
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

	/// <summary>
	/// Getter for the speed level of the player 
	/// </summary>
	/// <returns>Speed count.</returns>
//	public int SpeedCount(){
//		return playerSpeed.GetSpeedLevel ();
//	}
//
//	public int SpeedCountCap(){
//		return playerSpeed.GetSpeedCap ();
//	}
//
//	public void IncreaseSpeedCap(){
//		playerSpeed.IncreaseSpeedCap ();
//		//Set the gameController speed variables
//		//Speed cap is how many levels of speed are available to the player
//		gameController.AvailableSpeed = playerSpeed.GetSpeedCap ();
//		//speed level is how many levels of speed the player has activated
//		gameController.ActiveSpeed = playerSpeed.GetSpeedLevel ();
//		gameController.ShouldUpdateSpeed ();
//	}

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

//	public void ToggleSpeed(bool down) {
//		if (down) {
//			playerSpeed.IncreaseSpeed();
//			speed = playerSpeed.GetCurrentSpeed();
//			gameController.ActiveSpeed = playerSpeed.GetSpeedLevel();
//			gameController.AvailableSpeed = playerSpeed.GetSpeedCap();
//			gameController.ShouldUpdateSpeed();
//		}
//	}

	private void updateHitStatus(float delta) {
		if (hitTimer > 0.0f) {
			hitTimer -= delta;
			switch (takingDamage) {
			case TakingDamage.EXPLODE:
				if (hitTimer <= 0f) {
					hitTimer = 2.0f;
					takingDamage = TakingDamage.RETURNING;

					startSavePos = gameObject.transform.position;
					gameObject.transform.position = new Vector2 (-7.5f, startSavePos.y);
					endSavePos = gameObject.transform.position;
					HitEvent (takingDamage);
				}
				break;
			case TakingDamage.RETURNING:
				if (hitTimer <= 0f) {
					hitTimer = 2.5f;
					takingDamage = TakingDamage.BLINKING;

					SoundEffectPlayer sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer> ();
					sfxPlayer.PlayClip (Resources.Load ("Audio/BGM/newLife") as AudioClip);
					//playerInputController.DisableControls(false);
					//playerInputController.DisableShield(false);
					HitEvent (takingDamage);
				} else {
					gameObject.transform.position = Vector3.Lerp(startSavePos, endSavePos, hitTimer/0.5f);
				}
				break;
			case TakingDamage.BLINKING:
				if (hitTimer <= 0f) {
					hitTimer = 0f;
					takingDamage = TakingDamage.NONE;
					playerShield.EnableShield ();
					HitEvent (takingDamage);
				}
				break;
			case TakingDamage.NONE:
				if (hitTimer <= 0f) {
					HitEvent (takingDamage);
				}
				break;
			default:
				break;
			}
		}
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
		//gameController.RegisterPause(this);
		//gameController.RegisterPauseableItem (this);
		if (GameObject.Find ("PauseController")) {
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().RegisterPauseableItem(this);
		}
	}
	
	public void RemoveFromList()
	{
		//gameController.DelistPause(this);
		//gameController.DelistPauseableItem (this);
		if (GameObject.Find ("PauseController")) {
			GameObject.Find ("PauseController").GetComponent<PauseControllerBehavior>().DelistPauseableItem(this);
		}
	}

	public void TransitionSide(int value) {
		animator.SetBool ("moveHeld", true);
	}

	//By having the player handle it's own collision with enemy objects the
	//"hiding inside an enemy" bug has been handled.
	public void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Enemy")
		{
			TakeDamage();
		}
	}

	public void RemoveListeners() {
		//PlayerInputController.ChangeSpeedButton -= ToggleSpeed;
		PlayerInputController.UpDownEvent -= updatePlayerVert;
		PlayerInputController.LeftRightEvent -= updatePlayerHoriz;
		CountdownTimer.PlayerContinueEvent -= ResetTakingDamage;
	}

	public void ResetTakingDamage() {
		takingDamage = TakingDamage.NONE;
		hitTimer = 0.0f;
		//playerInputController.DisableShield(false);
	}

	public bool IsPlayerTakingDamage() {
		if (takingDamage != TakingDamage.NONE) {
			return true;
		} else {
			return false;
		}
	}

}
