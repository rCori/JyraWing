using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//This class has a recurring issue with getting stuck in neutral animation after being destroyed
//I think I fixed it, but if it crops up again, debug EnemyBehavior.SetAnimationToDefault and see
//if it goes through to set the animation state when it shouldn't, like if animation state is 2.
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

	private int TURRET_HEALTH = 4;

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

		shootTimer = 1.8f;

		shootTimeLimit = 2.5f;

		animator = gameObject.GetComponent <Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);
		
		isFlipped = true;

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);

		//Set timers for updating thhe pillbox animation
		//pointing up, down, or straight ahead
		updateAnimTimer = 0f;
		updateAnimTimeLimit = 0.5f;
		SetEnemyHealth (TURRET_HEALTH);

		GivePointObject(1, 0.3f);
		GivePointObject (2, 0.5f);
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
		if (isDestroyed) {
			return;
		}
		if (IsDestroyAnimation()) {
			Debug.Log ("Got stuck in StartShootAnimation!");
		}
		animator.SetInteger ("animState", 3);
	}

	public void ShootAtSetTarget() {
		if (isDestroyed) {
			return;
		}
		if (IsDestroyAnimation()) {
			Debug.Log ("Got stuck in ShootAtSetTarget!");
		}
		Shoot(fireDir);
		//Only shoot 
		if(shieldableBullets)
		{
			Shoot(upDir,true);
			Shoot(downDir, true);
		}
	}

	private bool IsDestroyAnimation() {
		int animState = animator.GetInteger ("animState");
		return animState == 2;
	}
}
