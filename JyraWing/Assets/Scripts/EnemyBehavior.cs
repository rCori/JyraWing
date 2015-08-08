using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {
	
	public enum MovementStatus {None, Lerp, Slerp, Velocity}

	float moveTimer;
	float moveTimeLimit;
	Vector3 startPos;
	Vector3 endPos;
	MovementStatus moveStatus;

	int hitPoints;
	
	AudioSource explosionSfx;

	public EnemyBulletPool bulletPool;
	public GameController gameController;
	private SoundEffectPlayer sfxPlayer;

	private int powerupGroupID;

	public bool LeftWallException;

	/// <summary>
	/// Initialize default values for the enemy
	/// </summary>
	public void EnemyDefaults(){
		moveTimer = 1f;
		moveTimeLimit = 0f;
		moveStatus = MovementStatus.None;
		hitPoints = 1;
		powerupGroupID = -1;
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();

	}

	/// <summary>
	/// Starts a movement command from where ever the enemy is to the position i_endPos
	/// </summary>
	/// <param name="i_endPos">ending position.</param>
	/// <param name="i_time">Time the movement will take.</param>
	public void StartNewMovement(Vector3 i_endPos, float i_time){
		//isMoving = true;
		moveStatus = MovementStatus.Lerp;
		moveTimeLimit = i_time;
		moveTimer = 0f;
		startPos = gameObject.transform.position;
		endPos = i_endPos;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}

	/// <summary>
	/// Starts a movement operation like StartNewMovement only the operation is a spherical LERP.
	/// This can be used to create curved movements
	/// </summary>
	/// <param name="i_endPos">ending position.</param>
	/// <param name="i_time">Time the movement will take.</param>
	public void StartNewSphericalMovement(Vector3 i_endPos, float i_time){
		moveStatus = MovementStatus.Slerp;
		moveTimeLimit = i_time;
		moveTimer = 0f;
		startPos = gameObject.transform.position;
		endPos = i_endPos;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}

	/// <summary>
	/// Starts a movement operation where enemy has a velocity for an amount of time
	/// </summary>
	/// <param name="i_vel">Velocity the enemy will have.</param>
	/// <param name="i_time">Time amount.</param>
	public void StartNewVelocity(Vector2 i_vel, float i_time){
		moveStatus = MovementStatus.Velocity;
		startPos = gameObject.transform.position;
		moveTimeLimit = i_time;
		moveTimer = 0f;
		gameObject.GetComponent<Rigidbody2D> ().velocity = i_vel;
	} 

	/// <summary>
	/// Starts a movement operation where the enemy has no current path or velocity.
	/// </summary>
	/// <param name="i_time">I_time.</param>
	public void StartStandStill(float i_time){
		moveStatus = MovementStatus.None;
		moveTimeLimit = i_time;
		moveTimer = 0f;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
	}

	public void Movement(){
		moveTimer += Time.deltaTime;
		if (moveTimer < moveTimeLimit) {
			if(moveStatus == MovementStatus.Lerp){
				gameObject.transform.position = Vector2.Lerp(startPos, endPos,moveTimer/moveTimeLimit);
			}
			else if(moveStatus == MovementStatus.Slerp){
				gameObject.transform.position = Vector3.Slerp(startPos, endPos,moveTimer/moveTimeLimit);
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

	/// <summary>
	/// Shoots an enemy bullet with a specified velocity
	/// </summary>
	/// <param name="i_dir">Enemy bullet velocity.</param>
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

	/// <summary>
	/// Sets the enemy health.
	/// Enemy health how many times it needs to be shot before it is destoryed
	/// Note: If using enemyDefaults, this must be called AFTER instantiation.
	/// Defaults sets this to 1.
	/// </summary>
	/// <param name="i_hitPoints">I_hit points.</param>
	public void SetEnemyHealth(int i_hitPoints)
	{
		hitPoints = i_hitPoints;
	}


	/// <summary>
	/// Sets the explosion sfx audio clip for when the enemy is destoryed..
	/// </summary>
	/// <param name="clip">Clip.</param>
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

				if(!sfxPlayer){
					sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				}
				//SoundEffectPlayer effectPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				sfxPlayer.PlaySoundClip(explosionSfx);


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
		}
	}

	/// <summary>
	/// If this enemy belongs to a group that drops a powerup, set 
	/// that this enemy belongs to that group.
	/// </summary>
	/// <param name="i_id">I_id.</param>
	public void SetPowerupGroupID(int i_id){
		powerupGroupID = i_id;
	}


	/// <summary>
	/// Handle powerup squad arrangments and ordering
	/// </summary>
	void OnDestroy() {
		if (powerupGroupID != -1) {
			gameController.CheckSquadAndRemove (powerupGroupID, gameObject);
		}
	}
}
