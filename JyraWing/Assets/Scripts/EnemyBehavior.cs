﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {
	

	float moveTimer;
	float moveTimeLimit;
	Vector3 startPos;
	Vector3 endPos;
	bool isMoving;
	bool hasVelocity;

	//int bulletNum;
	int hitPoints;

	//List<GameObject> bulletPool;

	AudioSource explosionSfx;

	public enemyBulletPool bulletPool;
	public GameController gameController;
	private SoundEffectPlayer sfxPlayer;

	private int powerupGroupID;

	/// <summary>
	/// Initialize default values for the enemy
	/// </summary>
	public void EnemyDefaults(){
		moveTimer = 1f;
		moveTimeLimit = 0f;
		isMoving = false;
		hasVelocity = false;
		hitPoints = 1;
		powerupGroupID = -1;
		Debug.Log ("enemyDefaults powerupGroupID " + powerupGroupID);
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();

	}

	/// <summary>
	/// Starts a movement command from where ever the enemy is to the position i_endPos
	/// </summary>
	/// <param name="i_endPos">ending position.</param>
	/// <param name="i_time">TIme the movement will take.</param>
	public void StartNewMovement(Vector3 i_endPos, float i_time){
		isMoving = true;
		hasVelocity = false;
		moveTimeLimit = i_time;
		moveTimer = 0f;
		startPos = gameObject.transform.position;
		endPos = i_endPos;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}

	public void StartNewVelocity(Vector2 i_vel, float i_time){
		isMoving = true;
		hasVelocity = true;
		startPos = gameObject.transform.position;
		moveTimeLimit = i_time;
		moveTimer = 0f;
		gameObject.GetComponent<Rigidbody2D> ().velocity = i_vel;
	} 

	public void StartStandStill(float i_time){
		isMoving = false;
		hasVelocity = false;
		moveTimeLimit = i_time;
		moveTimer = 0f;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}

	public void Movement(){
		moveTimer += Time.deltaTime;
		if (moveTimer < moveTimeLimit) {
			if(!hasVelocity && isMoving){
				gameObject.transform.position = Vector2.Lerp(startPos, endPos,moveTimer/moveTimeLimit);
			}
		}
	}

	/// <summary>
	/// Returns if the current move command's time has elapsed or not.
	/// </summary>
	/// <returns><c>true</c>, if time is up, <c>false</c> otherwise.</returns>
	public bool GetIsTimeUp(){

		return (moveTimer > moveTimeLimit);
	}

	public void Shoot(){
		GameObject bulletObj = bulletPool.GetBullet();
		//We check if the bullet is valid, if it is then shoot it.
		if(bulletObj)
		{
			EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet>();
			if(!bullet.GetIsActive()){
				bulletObj.transform.position = transform.position;
				bullet.Shoot();
				return;
			}
		}

	}

	public void Shoot(Vector2 i_dir){
		GameObject bulletObj = bulletPool.GetBullet();
		//We check if the bullet is valid, if it is then shoot it.
		if(bulletObj)
		{
			EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet> ();
			if (!bullet.GetIsActive ()) {
				bulletObj.transform.position = transform.position;
				bullet.Shoot (i_dir);
				return;
			}

		}
	}

	public void SetEnemyHealth(int i_hitPoints)
	{
		hitPoints = i_hitPoints;
	}

	public void SetExplosionSfx (AudioClip clip)
	{
		explosionSfx = gameObject.AddComponent<AudioSource> ();
		explosionSfx.clip = clip;
	}

	/// <summary>
	/// Uses the default trigger. Subclasses may override.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
	}

	/// <summary>
	/// Subclasses can choose to use this or not
	/// </summary>
	/// <param name="other">The Collider2D coming out of OnTriggerEnter2D.</param>
	public void DefaultTrigger(Collider2D other)
	{
		if (other.tag == "Bullet") {
			hitPoints--;
			
			//This will get rid of the 
			other.GetComponent<Bullet>().BulletDestroy();
			
			if(hitPoints == 0)
			{
				SpawnPowerup pow = GetComponent<SpawnPowerup>();
				if (pow) {
					pow.CreatePower ();	
				} 

				if(!sfxPlayer){
					sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				}
				//SoundEffectPlayer effectPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				sfxPlayer.PlaySoundClip(explosionSfx);

				Debug.Log (powerupGroupID);

				//If there is a powerupGroup we even care about
				if(powerupGroupID != -1){
					gameController.CheckSquadAndSpawn(powerupGroupID, gameObject);
				}

				Destroy (gameObject);
			}
		}
		
		if (other.tag == "Player" && other.isTrigger) {
			Player player = other.gameObject.GetComponent<Player>();
			player.TakeDamage();
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
			gameObject.transform.position = new Vector2(0,10f);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="i_id">I_id.</param>
	public void SetPowerupGroupID(int i_id){
		powerupGroupID = i_id;
		Debug.Log ("Setting group ID to " + powerupGroupID);
	}
}
