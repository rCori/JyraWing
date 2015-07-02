using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameController gameController;
	private float speed;
	private List<GameObject> bulletPool;
	Animator animator;
	int hits;
	int numBullets;
	private AudioSource fireSfx;
	private float hitTimer;
	private PlayerSpeed playerSpeed;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent <Animator> ();
		hitTimer = 0.0f;
		hits = 3;
		numBullets = 2;
		fireSfx = gameObject.AddComponent<AudioSource> ();
		fireSfx.clip = Resources.Load ("Audio/SFX/bullet_sfx") as AudioClip;
		bulletPool = new List<GameObject> ();
		for (int i= 0; i < numBullets; i++) {
			//Put all the bullet live in the pool
			GameObject bullet = (GameObject)Resources.Load ("Bullet");
			bullet = Instantiate(bullet);
			bulletPool.Add(bullet);
		}
		float[] speedList = new float[]{1.0f, 1.5f, 2.0f, 2.5f};
		playerSpeed = new PlayerSpeed (speedList);
		speed = speedList [0];

	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		float horiz = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");
		if (vert < 0.0f) {
			vert = -1.0f;
		}
		else if( vert > 0.0f){
			vert = 1.0f;
		}

		if(horiz < 0.0f){
			horiz = -1.0f;
		}
		else if(horiz > 0.0f){
			horiz = 1.0f;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(horiz,vert) * speed;
		if(Input.GetButtonDown("Fire1")){
			shoot ();
		}
		if (Input.GetButtonDown ("Fire2")) {
			playerSpeed.IncreaseSpeed();
			speed = playerSpeed.GetCurrentSpeed();
			gameController.UpdatePlayerSpeed();

		}
		//Handle taking damage and animation
		if (hitTimer > 0.0f) {
			hitTimer -= Time.deltaTime;
			if(hitTimer <= 0.0f){
				animator.SetInteger ("animState", 0);
				hitTimer = 0.0f;
			}
		}
	}

	/// <summary>
	/// Take damage from the enemy bullet
	/// </summary>
	public void TakeDamage(){
		if (hitTimer == 0.0f) {
			hits--;
			animator.SetInteger ("animState", 1);
			hitTimer = 0.5f;
			gameController.UpdatePlayerLives();
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
}
