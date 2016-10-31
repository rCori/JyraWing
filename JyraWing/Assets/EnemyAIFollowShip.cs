using UnityEngine;
using System.Collections;

public class EnemyAIFollowShip : EnemyBehavior { 

	private int FOLLOW_SHIP_HEALTH = 5;

	private Animator animator;

	private enum MoveState {turning = 0, moving};
	private MoveState moveState;

	private Vector2 playerLastLocation;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);
		//This enemy is not destoryed by touching the left wall.
		LeftWallException = false;

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;

		SetAnimations (animationsOwned);

		SetEnemyHealth (FOLLOW_SHIP_HEALTH);

		moveState = MoveState.turning;

		GivePointObject (1, 0.0f);

	}
	
	// Update is called once per frame
	void Update () {
		Movement();
		if (GetIsTimeUp ()) {
			if (moveState == MoveState.moving) {
				RedirectTowardsPlayer ();
				moveState = MoveState.turning;
			} else {
				
			}
		}
	}

	void RedirectTowardsPlayer() {
		playerLastLocation = gameController.playerPosition - gameObject.transform.position;

	}
		
	void MoveTowardsPlayer() {
	}

}
