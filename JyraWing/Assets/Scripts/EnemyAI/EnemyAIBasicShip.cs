using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIBasicShip : EnemyBehavior {


	[System.Serializable]
	public struct MoveInstruction {
		public EnemyBehavior.MovementStatus type;
		public Vector2 startVelocity;
		public Vector2 endVelocities;
		public float time;
	};

	public List<MoveInstruction> MoveInstructionList;

	//The value to apply to the z component of rotation
	public float angle;
	public float shieldableAngleAdjustment = 15.0f;

	public float speed;
	public float lifeTime;
	public bool shootInDirection = true;


	private float radians;

	private float timer;
	private Vector2 direction;
	private float bulletSpeed = 3.4f;
	private float fireRate = 1.5f;

	private int SHIP_HEALTH = 3;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);
		//This enemy is not destoryed by touching the left wall.
		LeftWallException = true;

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;

		SetAnimations (animationsOwned);
		//SetHitAnimationName ("enemy4_B_hit");

		radians = Mathf.Deg2Rad * angle;
		float xVel = Mathf.Cos (radians);
		float yVel = Mathf.Sin (radians);
		direction = new Vector2 (xVel, yVel);

		//Now make left and right directions for shooting shieldable bullets

		if (shootInDirection) {
			radians = Mathf.Deg2Rad * (angle - shieldableAngleAdjustment);
		} else {
			radians = Mathf.Deg2Rad * (-shieldableAngleAdjustment);
		}
		xVel = Mathf.Cos (radians);
		yVel = Mathf.Sin (radians);

		if (shootInDirection) {
			radians = Mathf.Deg2Rad * (angle + shieldableAngleAdjustment);
		} else {
			radians = Mathf.Deg2Rad * (shieldableAngleAdjustment);
		}
		xVel = Mathf.Cos (radians);
		yVel = Mathf.Sin (radians);

		StartNewVelocity(direction * speed, lifeTime);
		SetEnemyHealth (SHIP_HEALTH);


		GivePointObject (1, 0.3f);
		GivePointObject (2, 0.5f);

	}



	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement ();
		if (GetIsTimeUp ()) {
			Destroy(gameObject);
		}
		timer += Time.deltaTime;
		if (timer > fireRate) {
			if (shootInDirection) {
				Shoot (direction * speed * bulletSpeed);
			} else {
				Shoot (Vector2.left * speed * bulletSpeed);
			}
			timer = 0.0f;
		}
		HandleHitAnimation ();
		//Return from hit animation to neutral animation.
	}
	

	        
}
