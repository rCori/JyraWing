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
	Animator animator;
	


	//Gets called on Instantiation.
	void Awake(){
		EnemyDefaults ();
		fireDir = gameController.GetPlayerPosition() - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);
		shootTimer = 0.0f;

		shootTimeLimit = 3.0f;

		animator = gameObject.GetComponent <Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);
		
		isFlipped = true;
	}
	
	// Update is called once per frame
	void Update () {
		fireDir = gameController.GetPlayerPosition() - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);
		shootTimer += Time.deltaTime;
		if (shootTimer > shootTimeLimit) {
		
			Shoot(fireDir);
			shootTimer = 0.0f;
		}

		//Make the sprite point up or down depending ont he situation
		float heightDiff = gameController.GetPlayerPosition().y - gameObject.transform.position.y;
		if (heightDiff < 1.5f && heightDiff > -1.5f) {
			animator.SetInteger ("animState", 0);
		} else if (heightDiff > 1.5f) {
			animator.SetInteger ("animState", 1);
		} else if (heightDiff < -1.5f) {
			animator.SetInteger ("animState", 2);
		}

		//This is a bad fix for this issue.
		//Make the sprite flip horizontally depending on the situation
		float widthDiff = gameController.GetPlayerPosition().x - gameObject.transform.position.x;
		if ((widthDiff > 0 && !isFlipped) || (widthDiff < 0 && isFlipped)) {
			flipHorizontally();
		} 
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
}
