using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, PauseableItem {
	
	public GameController gameController;
	private float speed;
	private List<GameObject> bulletPool;
	Animator animator;
	int hits;
	int numBullets;
	private AudioSource fireSfx;
	private AudioSource damageSfx;
	private float hitTimer;
	private PlayerSpeed playerSpeed;
	private PlayerBulletLevel bulletLevel;

	private Vector3 startSavePos;
	private Vector3 endSavePos;
	private Vector3 pauseSavePos;

	private bool takingDamage;
	private bool disableControls;
	private bool _paused;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent <Animator> ();
		hitTimer = 0.0f;
		hits = 3;
		numBullets = 2;
		fireSfx = gameObject.AddComponent<AudioSource> ();
		//Shot sound
		fireSfx.clip = Resources.Load ("Audio/SFX/beep3") as AudioClip;
		damageSfx = gameObject.AddComponent<AudioSource> ();
		//Sound when the player is hit
		damageSfx.clip = Resources.Load ("Audio/SFX/playerDamage") as AudioClip;

		//Bullet pool of player bullets.
		bulletPool = new List<GameObject> ();
		for (int i= 0; i < numBullets; i++) {
			//Put all the bullet live in the pool
			GameObject bullet = (GameObject)Resources.Load ("Bullet");
			bullet = Instantiate(bullet);
			bulletPool.Add(bullet);
		}
		float[] speedList = new float[]{2.2f, 2.9f, 3.6f};
		playerSpeed = new PlayerSpeed (speedList);
		bulletLevel = new PlayerBulletLevel ();
		speed = speedList [0];
		disableControls = false;
		_paused = false;
		RegisterToList ();
		takingDamage = false;

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
		//Update player input
		updateInput ();

		updateHitAnimation ();
	}

	/// <summary>
	/// Take damage from the enemy bullet
	/// </summary>
	public void TakeDamage(){
		if (hitTimer == 0.0f) {
			//take out taking damage for now
			hits--;
			GetComponent<Rigidbody2D> ().velocity = new Vector2(0f, 0f);
			animator.SetInteger ("animState", 1);
			//Get the length of the animation.
			hitTimer = 2.5f;
			gameController.UpdatePlayerLives();
			disableControls = true;
			damageSfx.Play();
			takingDamage = true;
		}

	}

	/// <summary>
	/// Shoot A bullet from the stack
	/// </summary>
	private void shoot(){
		for (int i= 0; i < numBullets; i++) {
			GameObject bulletObj = bulletPool[i];
			Bullet bullet = bulletObj.GetComponent<Bullet>();
			if(!bullet.GetIsActive()){
				bulletObj.transform.position = transform.position;
				bullet.Shoot();
				fireSfx.Play();
				return;
			}
		}
	}

	/// <summary>
	/// Spread shot 
	/// IN DIRE NEED OF OPTIMAZATION
	/// </summary>
	private void spreadShot(){
//		Bullet bullet1;
//		Bullet bullet2;
//		Bullet bullet3;
		GameObject bullet1 = new GameObject();
		GameObject bullet2 = new GameObject();
		GameObject bullet3 = new GameObject();
		int counter = 0;
		for (int i= 0; i < numBullets; i++) {
			GameObject bulletObj = bulletPool[i];
			Bullet bullet = bulletObj.GetComponent<Bullet>();
			if(!bullet.GetIsActive()){
				//bulletObj.transform.position = transform.position;
				switch(counter){
				case 0:
					bullet1 = bulletObj;
					//bullet.ShootUp();
					counter++;
					break;
				case 1:
					bullet2 = bulletObj;
					//bullet.Shoot();
					counter++;
					break;
				case 2:
					bullet3 = bulletObj;
					//bullet.ShootDown();
					counter++;
					break;
				default:
					break;
				}
			}
			if(counter == 3) break;
		}
		if (counter == 3) {
			bullet1.transform.position = transform.position;
			bullet2.transform.position = transform.position;
			bullet3.transform.position = transform.position;
			bullet1.GetComponent<Bullet> ().ShootUp ();
			bullet2.GetComponent<Bullet> ().Shoot ();
			bullet3.GetComponent<Bullet> ().ShootDown ();
			fireSfx.Play();
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
		gameController.UpdatePlayerSpeed ();
	}

	public void IncreaseBulletLevel(){
		bulletLevel.IncrementBulletLevel ();
		switch (bulletLevel.GetBulletLevel ()) {
		case 1:
		{
			//Put an extra bullet in the pool
			GameObject bullet = (GameObject)Resources.Load ("Bullet");
			bullet = Instantiate(bullet);
			numBullets++;
			bulletPool.Add(bullet);
		}
			break;
		case 2:
		{
			//Put an extra bullet in the pool
			GameObject bullet = (GameObject)Resources.Load ("Bullet");
			bullet = Instantiate(bullet);
			numBullets++;
			bulletPool.Add(bullet);
		}
			break;
		case 3:
			for(int i = 0; i<9; i++){
				//Put all the bullet live in the pool
				GameObject bulletSpread = (GameObject)Resources.Load ("Bullet");
				bulletSpread = Instantiate(bulletSpread);
				bulletPool.Add(bulletSpread);
				numBullets++;
			}
			break;
		default:
			break;
		}
	}

	private void updatePlayerMovement(){
		if (!disableControls) {
			//Update position
			float horiz = Input.GetAxis ("Horizontal");
			float vert = Input.GetAxis ("Vertical");
			if (vert < 0.0f) {
				vert = -1.0f;
				if(!takingDamage){
					animator.SetInteger ("animState", 3);
				}
				else{
					animator.SetInteger ("animState", 5);
				}
			} else if (vert > 0.0f) {
				vert = 1.0f;
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




			if (horiz < 0.0f) {
				horiz = -1.0f;
			} else if (horiz > 0.0f) {
				horiz = 1.0f;
			}
		
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (horiz, vert) * speed;
		}
	}

	private void updateInput(){
		if(Input.GetButtonDown("Fire1") && !disableControls){
			if(bulletLevel.GetBulletLevel() != 3){
				shoot ();
			}
			else{
				spreadShot ();
			}
		}
		if (Input.GetButtonDown ("Fire2")) {
			playerSpeed.IncreaseSpeed();
			speed = playerSpeed.GetCurrentSpeed();
			gameController.UpdatePlayerSpeed();
			
		}
	}

	private void updateHitAnimation(){
		//Handle taking damage and animation
		if (hitTimer > 0.0f) {
			//player intially hit
			if(animator.GetInteger("animState") == 1){
				hitTimer -= Time.deltaTime;
				if(hitTimer <= 0.0f){
					animator.SetInteger ("animState", 2);
					hitTimer = 0.5f;
					startSavePos = gameObject.transform.position;
					gameObject.transform.position = new Vector2 (-7.5f, startSavePos.y);
					endSavePos = gameObject.transform.position;
				}
			//If the ship has returned to the screen after starting a new life
			} else if(takingDamage){
				//Player is flying back int
				if(disableControls){
					hitTimer -= Time.deltaTime;
					gameObject.transform.position = Vector3.Lerp(startSavePos, endSavePos, hitTimer/0.5f);
					if(hitTimer <= 0.0f){
						SoundEffectPlayer sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer> ();
						sfxPlayer.PlayClip(Resources.Load ("Audio/BGM/newLife") as AudioClip);
						hitTimer = 4.5f;
						disableControls = false;
					}
				//The player has regained control and is flashing and they are invincible
				}else{
					hitTimer -= Time.deltaTime;
					if(hitTimer <= 0.0f){
						GetComponent<BoxCollider2D>().enabled = false;
						GetComponent<BoxCollider2D>().enabled = true;
						animator.SetInteger ("animState", 0);
						hitTimer = 0.0f;
						takingDamage = false;
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
		gameController.RegisterPause(this);
	}
	
	public void RemoveFromList()
	{
		gameController.DelistPause(this);
	}

	public void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Enemy")
		{
			TakeDamage();
		}
	}
}
