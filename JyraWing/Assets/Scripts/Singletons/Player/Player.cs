using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, PauseableItem {

	public bool DEBUGNODAMAGE;
	public bool DEBUGMAXBULLETLEVEL;
	public bool DEBUGMAXSPEEDLEVEL;

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
	private AudioSource fireSfx;
	private AudioSource damageSfx;
	private float hitTimer;
	private PlayerSpeed playerSpeed;
	private PlayerBulletLevel bulletLevel;
	private OldPlayerInputController playerInputController;
	private IPlayerShield playerShield;

	private Vector3 startSavePos;
	private Vector3 endSavePos;
	private Vector3 pauseSavePos;

	private bool takingDamage;
	private bool _paused;


	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent <Animator> ();
		hitTimer = 0.0f;
		hits = 3;
		numBullets = 20;
		fireSfx = gameObject.AddComponent<AudioSource> ();
		//Shot sound
		fireSfx.clip = Resources.Load ("Audio/SFX/beep3") as AudioClip;
		damageSfx = gameObject.AddComponent<AudioSource> ();
		//Sound when the player is hit
		damageSfx.clip = Resources.Load ("Audio/SFX/playerDamage") as AudioClip;

		//Helper classes and components for the player
		playerSpeed = new PlayerSpeed ();
		bulletLevel = new PlayerBulletLevel ();
		playerInputController = new OldPlayerInputController ();
		speed = playerSpeed.GetCurrentSpeed();


		//The shield we will get assigned by instantiating the shield GameObject and then extracting
		//the shield interface from that game object
		GameObject playerShieldObject = Resources.Load ("PlayerShield") as GameObject;
		playerShieldObject = Instantiate (playerShieldObject);
		//Use the GameObject to get the PlayerShield interface
		PlayerShieldBehaviour playerShieldBehaviour = playerShieldObject.GetComponent<PlayerShieldBehaviour>();
		//Get the same GameController reference from the player for player shield
		playerShieldBehaviour.gameController = gameController;
		playerShieldBehaviour.playerInputController = playerInputController;
		playerShield = playerShieldBehaviour.GetPlayerShield();



		gameController = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController ();
		_paused = false;
		RegisterToList ();
		takingDamage = false;

		//Set direction to non
		if (DEBUGMAXBULLETLEVEL) {
//			IncreaseBulletLevel();
//			IncreaseBulletLevel();
//			IncreaseBulletLevel();
		}
		if (DEBUGMAXSPEEDLEVEL) {
			playerSpeed.IncreaseSpeedCap ();
			playerSpeed.IncreaseSpeedCap ();
			playerSpeed.IncreaseSpeedCap ();
		}
		PlayerInputController.ChangeSpeedButton += ToggleSpeed;
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
		updatePlayerMovement ();

		//updateHitAnimation ();

		playerInputController.PlayerInputUpdate ();

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
			takingDamage = true;
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
	public int SpeedCount(){
		return playerSpeed.GetSpeedLevel ();
	}

	public int SpeedCountCap(){
		return playerSpeed.GetSpeedCap ();
	}

	public void IncreaseSpeedCap(){
		playerSpeed.IncreaseSpeedCap ();
		//Set the gameController speed variables
		//Speed cap is how many levels of speed are available to the player
		gameController.AvailableSpeed = playerSpeed.GetSpeedCap ();
		//speed level is how many levels of speed the player has activated
		gameController.ActiveSpeed = playerSpeed.GetSpeedLevel ();
		gameController.ShouldUpdateSpeed ();
	}

	public bool HasShield(){
		return playerShield.HasShield(playerInputController.GetShieldButton ());
	}

	private void updatePlayerMovement(){
		if(!playerInputController.GetDisabledControls()){
			//Update position
			int horiz = playerInputController.GetHorizontalMovement();
			int vert = playerInputController.GetVerticalMovement();
			/*
			if (vert ==  -1) {
				if(!takingDamage){
					animator.SetInteger ("animState", 3);
				}
				else{
					animator.SetInteger ("animState", 5);
				}
			} else if (vert == 1) {
				if(!takingDamage){
					animator.SetInteger ("animState", 4);
				}
				else{
					animator.SetInteger ("animState", 6);
				}
			}
			else if(takingDamage) 
			{
				animator.SetInteger ("animState", 2);
			}
			else{
				animator.SetInteger ("animState", 0);
			}
			*/
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (horiz, vert) * speed;
		}
	}

	public void ToggleSpeed(bool down) {
		if (down) {
			playerSpeed.IncreaseSpeed();
			speed = playerSpeed.GetCurrentSpeed();
			gameController.ActiveSpeed = playerSpeed.GetSpeedLevel();
			gameController.AvailableSpeed = playerSpeed.GetSpeedCap();
			gameController.ShouldUpdateSpeed();
		}
	}

	private void updateHitAnimation(){
		//Handle taking damage and animation
		if (hitTimer > 0.0f) {
			//player intially hit
			//Debug.Log ( "animation state is: " + animator.GetInteger("animState"));
			if(animator.GetInteger("animState") == 1){
				hitTimer -= Time.deltaTime;
				if(hitTimer <= 0.0f){
					//animator.SetInteger ("animState", 2);
					hitTimer = 0.5f;
					startSavePos = gameObject.transform.position;
					gameObject.transform.position = new Vector2 (-7.5f, startSavePos.y);
					endSavePos = gameObject.transform.position;
				}
			//If the ship has returned to the screen after starting a new life
			} else if(takingDamage){
				//Player is flying back int
				//if(playerInputController.GetDisabledControls()){
				if(false) {
					hitTimer -= Time.deltaTime;
					gameObject.transform.position = Vector3.Lerp(startSavePos, endSavePos, hitTimer/0.5f);
					if(hitTimer <= 0.0f){
						SoundEffectPlayer sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer> ();
						sfxPlayer.PlayClip(Resources.Load ("Audio/BGM/newLife") as AudioClip);
						hitTimer = 4.5f;
						//playerInputController.DisableControls(false);
					}
				//The player has regained control and is flashing and they are invincible
				}else{
					hitTimer -= Time.deltaTime;
					if(hitTimer <= 0.0f){
						//animator.SetInteger ("animState", 0);
						hitTimer = 0.0f;
						takingDamage = false;
						//playerInputController.DisableShield(false);
					}
				}
			} 
		}
	}

	//Make sure the player is removed from the list although actually this shouldn't be necssary
	void OnDestroy()
	{
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
		gameController.RegisterPauseableItem (this);
	}
	
	public void RemoveFromList()
	{
		//gameController.DelistPause(this);
		gameController.DelistPauseableItem (this);
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

}
