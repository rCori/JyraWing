﻿using UnityEngine;
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
	private PlayerBulletLevel bulletLevel;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent <Animator> ();
		hitTimer = 0.0f;
		hits = 3;
		numBullets = 2;
		fireSfx = gameObject.AddComponent<AudioSource> ();
		fireSfx.clip = Resources.Load ("Audio/SFX/shootenem") as AudioClip;
		bulletPool = new List<GameObject> ();
		for (int i= 0; i < numBullets; i++) {
			//Put all the bullet live in the pool
			GameObject bullet = (GameObject)Resources.Load ("Bullet");
			bullet = Instantiate(bullet);
			bulletPool.Add(bullet);
		}
		float[] speedList = new float[]{1.2f, 1.7f, 2.3f, 2.7f};
		playerSpeed = new PlayerSpeed (speedList);
		bulletLevel = new PlayerBulletLevel ();
		speed = speedList [0];

	}
	
	// Update is called once per frame
	void Update () {
		//Update position
		updatePlayerMovement ();
		//Update player input
		updateInput ();

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
//		if (hitTimer == 0.0f) {
//			hits--;
//			animator.SetInteger ("animState", 1);
//			hitTimer = 0.5f;
//			gameController.UpdatePlayerLives();
//		}

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
		//Update position
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
	}

	private void updateInput(){
		if(Input.GetButtonDown("Fire1")){
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
}
