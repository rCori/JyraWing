using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAIShipArc : EnemyBehavior {

	[System.Serializable]
	public struct MoveInstruction {
		public EnemyBehavior.MovementStatus type;
		public Vector2 startVelocity;
		public Vector2 endVelocities;
		public float time;
	};

	public List<MoveInstruction> MoveInstructionList;

	private int currentMovementStep;

	//The value to apply to the z component of rotation
	public float angle;
	public float shieldableAngleAdjustment = 15.0f;

	public float speed;
	public float lifeTime;
	public float fireRate;
	public float bulletSpeed;

	public int hits;

	private float radians;

	private float timer;
	private Vector2 direction;

	private Vector2 leftDir;
	private Vector2 rightDir;

	private int SHIP_HEALTH = 3;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		//This enemy is not destoryed by touching the left wall.
		LeftWallException = true;

		SetEnemyHealth (hits);

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;

		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy4_B_hit");

		radians = Mathf.Deg2Rad * angle;
		float xVel = Mathf.Cos (radians);
		float yVel = Mathf.Sin (radians);
		direction = new Vector2 (xVel, yVel);

		//Now make left and right directions for shooting shieldable bullets

		radians = Mathf.Deg2Rad * (angle - shieldableAngleAdjustment);

		xVel = Mathf.Cos (radians);
		yVel = Mathf.Sin (radians);
		leftDir = new Vector2 (xVel, yVel);

		radians = Mathf.Deg2Rad * (angle + shieldableAngleAdjustment);

		xVel = Mathf.Cos (radians);
		yVel = Mathf.Sin (radians);
		rightDir = new Vector2 (xVel, yVel);

		StartNewVelocity(direction * speed, lifeTime);
		SetEnemyHealth (SHIP_HEALTH);

	}



	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement();
		if (GetIsTimeUp ()) {

			if(currentMovementStep < MoveInstructionList.Count) {
				if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Velocity) {
					StartNewVelocity (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.ArcVelocity) {
					StartArcVelocity (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].endVelocities, MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.None) {
					StartStandStill (MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Lerp) {
					StartNewMovement (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
				} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Lerp) {
					StartNewSphericalMovement (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
				}
				currentMovementStep++;
			} else {
				Destroy(gameObject);
			}
		}
		timer += Time.deltaTime;
		if (timer > fireRate) {
			Shoot (direction * speed * bulletSpeed);
			if(shieldableBullets){
				Shoot (leftDir * speed * bulletSpeed *1.5f, true);
				Shoot (rightDir * speed * bulletSpeed *1.5f, true);

			}
			timer = 0.0f;
		}
		HandleHitAnimation ();
		//Return from hit animation to neutral animation.
	}

}