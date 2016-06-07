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
				shootTimeLimit = 1.4f;
				break;
			case Boss2TurretMode.TrackShield:
				shootTimeLimit = 1.7f;
				break;
			case Boss2TurretMode.FanNormal:
				shootTimeLimit = 1.5f;
				break;
			case Boss2TurretMode.FanShield:
				shootTimeLimit = 1.5f;
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

		shootTimer = 0.0f;

		//Initialize all of the bullet fanning directions
		InitFanningDirections ();

		_mode = Boss2TurretMode.TrackNormal;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		switch (_mode) {
		case Boss2TurretMode.TrackNormal:
			TrackBulletUpdate (false);
			Debug.Log ("Track normal");
			break;
		case Boss2TurretMode.TrackShield:
			TrackBulletUpdate (true);
			Debug.Log ("Track shield");
			break;
		case Boss2TurretMode.FanNormal:
			FanBulletUpdate (false);
			Debug.Log ("Fan normal");
			break;
		case Boss2TurretMode.FanShield:
			FanBulletUpdate (true);
			Debug.Log ("Fan shield");
			break;
		}
	}

	//
	void InitFanningDirections(){
		//Initialize all of the bullet fanning directions
		fanningDirections = new List<Vector2> ();
		float yDir = -0.7f;
		for (int i = 0; i < 5; i++) {
			//Get the direction and normalize it
			Vector2 fanBulletDirection = new Vector2();
			fanBulletDirection = transform.position;
			fanBulletDirection.Normalize ();
			Debug.Log ("yDir: " + yDir);
			fanBulletDirection = new Vector2 (-1.0f, yDir).normalized * fanningBulletSpeed;
			//Add it to the list and advance the direction
			fanningDirections.Add(fanBulletDirection);
			yDir += 0.35f;
		}
	}

	//Update for shooting in fan
	void FanBulletUpdate(bool shield = false){
		shootTimer += Time.deltaTime;
		//Time to shoot has triggered.
		if (shootTimer > shootTimeLimit) {
			Debug.Log ("Fan shooting");
			Shoot(fanningDirections[fanBulletNum], shield);
			//Reset timer
			shootTimer = 0.0f;
			fanBulletNum++;
			if (fanBulletNum > 4) {
				fanBulletNum = 0;
			}
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
			Debug.Log ("Track shooting");
			//Get the direction we are firing in.
			Vector2 fireDir = gameController.playerPosition - gameObject.transform.position;
			fireDir = fireDir.normalized * trackingBulletSpeed;
			//Shoot the bullet
			Shoot (fireDir,shield);
			//Reset timer
			shootTimer = 0.0f;
		}
	}
}
