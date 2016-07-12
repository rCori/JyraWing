using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAITurretLevel1 : EnemyBehavior {
	
	/// <summary>
	/// The direction the enemy will fire
	/// </summary>
	private Vector2 fireDir;

	///<summary>
	/// Time couting up to limit when next shot is fired
	/// </summary>
	private float shootTimer;


	/// <summary>
	/// TIme between each shot.
	/// </summary>
	private float shootTimeLimit;

	private bool isFlipped;

	//Keep a steady interval to update positional idle animation.
	private float updateAnimTimer;
	private float updateAnimTimeLimit;

	private int TURRET_HEALTH = 3;

	//Two extra directions for shieldable bullets to be shot in
	Vector2 upDir;
	Vector2 downDir;

	//Gets called on Instantiation.
	void Awake(){
		EnemyDefaults ();
		fireDir = gameController.playerPosition - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);

		//Set the up and down directions for shieldable bullets
		upDir.Set (-1f, -3f);
		downDir.Set (-1f, 3f);

		shootTimer = 0.0f;

		shootTimeLimit = 3.0f;

		animator = gameObject.GetComponent <Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		
		isFlipped = true;

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		//SetHitAnimationName ("NONE");

		//Set timers for updating thhe pillbox animation
		//pointing up, down, or straight ahead
		updateAnimTimer = 0f;
		updateAnimTimeLimit = 0.5f;
		SetEnemyHealth (TURRET_HEALTH);

		GameObject pointIcon = Resources.Load ("Pickups/PointIcons/PointIcon1_0") as GameObject;
		EnemyBehavior.PointObjectRelative origin1PointObject = new EnemyBehavior.PointObjectRelative ();
		origin1PointObject.pointObject = pointIcon;
		origin1PointObject.relativePos = new Vector2 (-0.1f, 0.2f);

		GameObject pointIcon2 = Resources.Load ("Pickups/PointIcons/PointIcon2_0") as GameObject;
		EnemyBehavior.PointObjectRelative origin2PointObject = new EnemyBehavior.PointObjectRelative ();
		origin2PointObject.pointObject = pointIcon;
		origin2PointObject.relativePos = new Vector2 (0.2f, -0.3f);

		List<EnemyBehavior.PointObjectRelative> pointSpawns = new List<EnemyBehavior.PointObjectRelative> ();
		pointSpawns.Add (origin1PointObject);
		pointSpawns.Add (origin2PointObject);
		SetPointObject (pointSpawns);
	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		fireDir = gameController.playerPosition - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);


		shootTimer += Time.deltaTime;
		if (shootTimer > shootTimeLimit) {
			shootTimer = 0.0f;
			StartShootAnimation ();
		}
			
	}
		

	public void StartShootAnimation() {
		animator.SetInteger ("animState", 3);
	}

	public void ShootAtSetTarget() {
		Shoot(fireDir);
		//Only shoot 
		if(shieldableBullets)
		{
			Shoot(upDir,true);
			Shoot(downDir, true);
		}
	}
}
