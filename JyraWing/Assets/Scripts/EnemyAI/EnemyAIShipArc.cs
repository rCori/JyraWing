using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAIShipArc : EnemyBehavior {

	[System.Serializable]
	public struct MoveInstruction {
		public EnemyBehavior.MovementStatus type;
		public Vector2 startVelocity;
		public Vector2 endVelocity;
		public float time;
	};

	public List<MoveInstruction> MoveInstructionList;

	private int currentMovementStep;

	private float radians;
	private float timer;
	private float bulletSpeed = 3.4f;
	private float fireRate = 1.5f;
	private int SHIP_HEALTH = 3;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		//This enemy is not destoryed by touching the left wall.
		LeftWallException = true;

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;

		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy4_B_hit");

		BeginNextMovementStep ();
		SetEnemyHealth (SHIP_HEALTH);
	}



	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement();
		if (GetIsTimeUp ()) {
			BeginNextMovementStep ();
		}
		timer += Time.deltaTime;
		if (timer > fireRate) {
			Shoot (Vector2.left * bulletSpeed);
			timer = 0.0f;
		}
		HandleHitAnimation ();
		//Return from hit animation to neutral animation.
	}

	private void BeginNextMovementStep() {
		if(currentMovementStep < MoveInstructionList.Count) {
			if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Velocity) {
				StartNewVelocity (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
			} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.ArcVelocity) {
				StartArcVelocity (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].endVelocity, MoveInstructionList [currentMovementStep].time);
			} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.None) {
				StartStandStill (MoveInstructionList [currentMovementStep].time);
			} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Lerp) {
				StartNewMovement (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
			} else if (MoveInstructionList [currentMovementStep].type == EnemyBehavior.MovementStatus.Slerp) {
				StartNewSphericalMovement (MoveInstructionList [currentMovementStep].startVelocity, MoveInstructionList [currentMovementStep].time);
			}
			currentMovementStep++;
		} else {
			Destroy(gameObject);
		}
	}

}