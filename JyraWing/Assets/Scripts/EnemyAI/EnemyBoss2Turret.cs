using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBoss2Turret : EnemyBehavior {

	public enum Boss2TurretMode
	{
		TrackNormal = 0,
		TrackShield,
		FanNormal,
		FanShield
	}

	public float fanningBulletSpeed;
	public float trackingBulletSpeed;

	/// <summary>
	/// The direction the enemy will fire
	/// </summary>
	private Vector2 fireDir;
	
	///<summary>
	/// Time couting up to limit when next shot is fired
	/// </summary>
	private float shootTimer;
	
	
	/// <summary>
	/// Time between each shot.
	/// </summary>
	private float shootTimeLimit;

	private List<Vector2> fanningDirections;
	private int fanBulletNum;

	private Boss2TurretMode _mode;

	public Boss2TurretMode Mode{
		get{
			return _mode;
		}
		set{
			_mode = value;
			//Change timers appropriatly
			switch(_mode){
			case Boss2TurretMode.TrackNormal:
				shootTimeLimit = 1.0f;
				break;
			case Boss2TurretMode.TrackShield:
				shootTimeLimit = 0.7f;
				break;
			case Boss2TurretMode.FanNormal:
				shootTimeLimit = 0.5f;
				break;
			case Boss2TurretMode.FanShield:
				shootTimeLimit = 0.5f;
				break;
			}
			//Reset fanning.
			fanBulletNum=0;
		}
	}

	// Use this for initialization
	void Awake () {
		EnemyDefaults ();

		//Default firing mode
		Mode = Boss2TurretMode.TrackNormal;

		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);

		//RIght now there are no animations
		HasAnimations animationsOwned = HasAnimations.None;
		SetAnimations (animationsOwned);

		//Initialize all of the bullet fanning directions
		InitFanningDirections ();
	}
	
	// Update is called once per frame
	void Update () {
		FanBulletUpdate ();
		if (isDestroyed || _paused) {
			return;
		}
	}

	//
	void InitFanningDirections(){
		//Initialize all of the bullet fanning directions
		fanningDirections = new List<Vector2> ();
		float yDir = -2.0f;
		for (int i = 0; i < 5; i++) {
			//Get the direction and normalize it
			Vector2 fanBulletDirection = new Vector2();
			fanBulletDirection = transform.position;
			fanBulletDirection.Normalize ();
			fanBulletDirection -= new Vector2 (-1.0f, yDir);
			
			//Add it to the list and advance the direction
			fanningDirections.Add(fanBulletDirection);
			yDir += 1.0f;
		}
	}

	//Update for shooting in fan
	void FanBulletUpdate(bool shield = false){
		shootTimer += Time.deltaTime;
		//Time to shoot has triggered.
		if (shootTimer > shootTimeLimit) {
			Shoot(fanningDirections[fanBulletNum], shield);
			//Reset timer
			shootTimer = 0.0f;
		}
	}

	public void SetHitPoints(int health){
		hitPoints = health;
	}

	//Update for shooting tracking shots
	void TrackBulletUpdate(bool shield = false){
		shootTimer += Time.deltaTime;
		//Time to shoot has triggered
		if (shootTimer > shootTimeLimit) {
			//Get the direction we are firing in.
			Vector2 fireDir = gameController.playerPosition - gameObject.transform.position;
			fireDir.Normalize();
			fireDir.Set(fireDir.x*4, fireDir.y*4);
			//Shoot the bullet
			Shoot (fireDir,shield);
			//Reset timer
			shootTimer = 0.0f;
		}
	}
}
