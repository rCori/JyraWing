using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour, PauseableItem {
	
	public enum MovementStatus {None, Lerp, Slerp, Velocity}

	///Mark this as an enum that can have multiple values ORed together
	///THis way they can used as independant flags.
	[System.Flags]
	public enum HasAnimations
	{
		None = 0,
		Hit = 1,
		Destroy = 2
	}

	/// <summary>
	/// How long the current move operation has been going for.
	/// Time will be up when moveTimeLimit < moveTimer
	/// </summary>
	private float moveTimer;

	/// <summary>
	/// How long a move operation will go for
	/// </summary>
	private float moveTimeLimit;

	/// <summary>
	/// The start position for a movement
	/// Used primarily by the Lerp and Slerp movement
	/// </summary>
	private Vector3 startPos;

	/// <summary>
	/// The end position for a movement
	/// Used primarily by the Lerp and Slerp movement
	/// </summary>
	private Vector3 endPos;

	/// <summary>
	/// The move status.
	/// </summary>
	protected MovementStatus moveStatus;

	/// <summary>
	/// How many bullets an enemy will take before it goes down.
	/// Default is 1.
	/// </summary>
	protected int hitPoints;

	/// <summary>
	/// Sound effect when the enemy is destroyed
	/// </summary>
	protected AudioSource explosionSfx;

	/// <summary>
	/// The bullet pool. To shoot the enemy must request a bullet from the pool.
	/// </summary>
	public EnemyBulletPool bulletPool;

	/// <summary>
	/// The shieldable bullet pool.
	/// Works the same as the other bullet pool but the bullets
	/// in this pool have the shieldable property.
	/// </summary>
	public EnemyBulletPool shieldableBulletPool;

	/// <summary>
	/// The game controller.
	/// Connection to other in game objects and events
	/// </summary>
	public GameController gameController;

	/// <summary>
	/// Plays sound effects for explosions.
	/// </summary>
	protected SoundEffectPlayer sfxPlayer;


	/// <summary>
	/// If the enemy is part of a group that will drop a powerup when it dies, this id assigns it to that group
	/// </summary>
	private int powerupGroupID;


	/// <summary>
	/// If this is false, the enemy will be destoryed when it stouches the left barrier
	/// If true, the enemy can pass through the barrier unharmed
	/// By default this is false but if the enemy is going to come from the left side of the screen, this needs to be true.
	/// </summary>
	public bool LeftWallException;


	/// <summary>
	/// Enables or disables the behavior of shooting bullets that can bve defelected with
	/// the player shield.
	/// </summary>
	public bool shieldableBullets;


	private AudioClip hitSfx;

	/// <summary>
	/// Bitmask for how many animations the enemy can play.
	/// Assumes animation variable is "animState" and transitions
	/// have the typical set up.
	/// </summary>
	private HasAnimations animationsOwned;
	protected Animator animator;
	private string hitAnimationName;
	protected bool isDestroyed;
	protected bool powerWillSpawn;
	protected bool _paused;
	private Vector2 storedVel;
	protected bool priorityAudio;

	/// <summary>
	/// Initialize default values for the enemy
	/// </summary>
	public void EnemyDefaults(){
		moveTimer = 1f;
		moveTimeLimit = 0f;
		moveStatus = MovementStatus.None;
		hitPoints = 1;
		//By default an enemy belongs to no powerup group.
		powerupGroupID = -1;
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
		hitSfx = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		animationsOwned = HasAnimations.None;
		animator = gameObject.GetComponent<Animator> ();
		hitAnimationName = "NO ANIMATION SET";
		isDestroyed = false;
		_paused = false;
		powerWillSpawn = false;
		storedVel = new Vector2 (0f, 0f);
		priorityAudio = false;
		RegisterToList ();


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

	public void Shoot(bool shieldable = false){
		GameObject bulletObj;
		//Determine what kind of bullet we will get, shieldable or not
		
		if(!shieldable){
			bulletObj = bulletPool.GetBullet();
		} else {
			bulletObj = shieldableBulletPool.GetBullet();
		}
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
	public void Shoot(Vector2 i_dir, bool shieldable = false){
		GameObject bulletObj;
		//Determine what kind of bullet we will get, shieldable or not

		if(!shieldable){
			bulletObj = bulletPool.GetBullet();
		} else {
			bulletObj = shieldableBulletPool.GetBullet();
		}
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
		//Add an audio source to the enemy
		explosionSfx = gameObject.AddComponent<AudioSource> ();
		//Set the actual audio clip to what was passed in.
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
		//Do not activate this trigger if the enemy has been destroyed.
		if (isDestroyed) {
			return;
		}
		if (other.tag == "Bullet") {

			if(hitPoints == 0){
				return;
			}
			hitPoints--;
			//This will get rid of the 
			other.GetComponent<Bullet>().BulletDestroy();
			
			if(hitPoints == 0)
			{
				
				if(!sfxPlayer){
					sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				}
				//SoundEffectPlayer effectPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				//If the enemy has priority in audio, it will create a new audio source only for it so it cannot be interrupted. 
				if(priorityAudio){
					sfxPlayer.PlayPrioritySoundClip(explosionSfx);
				}
				else{
					sfxPlayer.PlaySoundClip(explosionSfx);
				}


				//If there is a destroy animation to play, set isDestroy to true and try to play it
				if((animationsOwned & HasAnimations.Destroy) != 0){
					isDestroyed = true;
					//If this group has a powerup to spawn see if it should be done.
					if(powerupGroupID != -1){
						bool ret = gameController.CheckIsSquadGone(powerupGroupID);
						if(ret)
						{
							powerWillSpawn = true;
						}
					}
					gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, 0f);
					try{
						//Try to set the destroy animation
						if(animator){
							animator.SetInteger("animState", 2);
						}
						//If the animator does not exist, then animationOwned should not have the destory animation set
						//This was an error and it should be thrown.
						else{
							throw new System.Exception();
						}
					}
					catch(System.Exception e){
						Debug.LogException(e);
					}
				}
				//If not just immediatly destroy the object.
				else{
					//If there is a powerupGroup we even care about
					if(powerupGroupID != -1){
						bool ret = gameController.CheckIsSquadGone(powerupGroupID);
						if(ret)
						{
							powerWillSpawn = true;
						}
					}
					DestroySelf ();
				}
			}
			//The bullet hit and hitpoints are being lowered but the enemy isn't destroyed yet.
			//Play the hit animation flash.
			else{
				if(!sfxPlayer){
					sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				}
				sfxPlayer.PlayClip(hitSfx);
				//Check for the hit animation flag to be set
				if((animationsOwned & HasAnimations.Hit) != 0){
					try{
						//Try to set the hit flash animation
						if(animator){
							animator.SetInteger("animState", 1);
						}
						//If the animator does not exist, then animationOwned should not have the destory animation set
						//This was an error and it should be thrown.
						else{
							throw new System.Exception();
						}
					}
					catch(System.Exception e){
						Debug.LogException(e);
					}
				}
			}
		}
	}


	//	public int GetPowerupGroupID()
	//	{
	//		return powerupGroupID;
	//	}

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
		//Null reference issue on close is blocked by a null check on gameObject.
		if (powerupGroupID != -1 && !isDestroyed && gameController != null) {
			gameController.RemoveSquad (powerupGroupID);
		}

		RemoveFromList ();

	}

	//Intended to be used at the end of a destroy animation
	//That way object destruction happens exactly when it should and the
	// destroy animation does not need to be timed. You must remember
	//TO call this as an even at the end of that animation however.
	public void DestroySelf()
	{
		//If there is a powerupGroup we even care about
		if(powerWillSpawn){
			Debug.Assert(powerupGroupID != -1);
			gameController.SpawnGroupPower(powerupGroupID, gameObject.transform.position);
		}
		Destroy (gameObject);
	}

	/// <summary>
	/// The standard animations an enemy can have is hit and destroyed
	/// </summary>
	/// <param name="anims">Anims.</param>
	protected void SetAnimations(HasAnimations anims)
	{
		animationsOwned = anims;
	}

	///<summary>
	/// If the enemy has a hit animation this function 
	/// needs to be placed into the enemy update loop. hitAnimationName 
	/// needs to actually be set by the sublcass enemy for this to work.
	/// </summary>
	protected void HandleHitAnimation(){
		if (animator.GetCurrentAnimatorStateInfo (0).IsName (hitAnimationName)) {
			animator.SetInteger("animState", 0);
		}
	}

	/// <summary>
	/// This base class will actually need to know the name of the hit animation if the enemy posses one
	/// It uses this name to handle the hit animation ending and returning to idle.
	/// </summary>
	/// <param name="i_hitAnimationName">I_hit animation name.</param>
	protected void SetHitAnimationName(string i_hitAnimationName){
		hitAnimationName = i_hitAnimationName;
	}

	/// <summary>
	/// Return if isDestroyed is set.
	/// If an enemy shoots an enemy and reduces it's health to 0, the object still exists
	/// but the enemy is considrered dead. When it is done with it's destroy animation it will actually
	/// be removed from the game. But while that animation happens, this can be used to determine the enemy is
	/// dead without actually being null.
	/// </summary>
	public bool GetIsDestroyed(){
		return isDestroyed;
	}


	/* Implementation of PauseableObject */
	public bool paused
	{
		get
		{
			return _paused;
		}

		set
		{
			_paused = value;
			if(_paused)
			{
				storedVel = GetComponent<Rigidbody2D>().velocity;
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
				animator.speed = 0f;
			}
			else{
				GetComponent<Rigidbody2D>().velocity = storedVel;
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

}
