using UnityEngine;
using System.Collections;

public class EnemyAI4 : EnemyBehavior {

	/// <summary>
	/// The direction the enemy will fire
	/// </summary>
	private Vector2 fireDir;

	/// <summary>
	/// Running timer for shootin bullets
	/// </summary>

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

	//Gets called on Instantiation.
	void Awake(){
		EnemyDefaults ();
		fireDir = gameController2.playerPosition - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);
		shootTimer = 0.0f;

		shootTimeLimit = 3.0f;

		animator = gameObject.GetComponent <Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		
		isFlipped = true;

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("pillboxHit");

		//Set timers for updating thhe pillbox animation
		//pointing up, down, or straight ahead
		updateAnimTimer = 0f;
		updateAnimTimeLimit = 0.5f;


	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		fireDir = gameController2.playerPosition - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);
		shootTimer += Time.deltaTime;
		if (shootTimer > shootTimeLimit) {
		
			Shoot(fireDir);
			shootTimer = 0.0f;
		}


		//Update the animation not every update but on a regular interval
		updateAnimTimer += Time.deltaTime;
		if (updateAnimTimer > updateAnimTimeLimit) {
			updateAnimation ();
			updateAnimTimer = 0.0f;
		}

		//This is a bad fix for this issue.
		//Make the sprite flip horizontally depending on the situation
		float widthDiff = gameController2.playerPosition.x - gameObject.transform.position.x;
		if ((widthDiff > 0 && !isFlipped) || (widthDiff < 0 && isFlipped)) {
			flipHorizontally();
		}
		HandleHitAnimation ();
	}

	void flipHorizontally()
	{
		isFlipped = !isFlipped;
		float modify;
		if (isFlipped) {
			modify = -1;
		} else {
			modify = 1;
		}
		gameObject.transform.localScale = new Vector2 (4f*modify, 4f);

	}

	//update what frame of animation the pillbox will have
	//This will change the sprite to point up or down.
	private void updateAnimation()
	{
		//Make the sprite point up or down depending ont he situation
		float heightDiff = gameController2.playerPosition.y - gameObject.transform.position.y;
		if (heightDiff < 1.5f && heightDiff > -1.5f) {
			//straight ahead
			animator.SetInteger ("animState", 0);
		} else if (heightDiff > 1.5f) {
			//point up
			animator.SetInteger ("animState", 3);
		} else if (heightDiff < -1.5f) {
			//point down
			animator.SetInteger ("animState", 4);
		}
	}
}
