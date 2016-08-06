using UnityEngine;
using System.Collections;

public class EnemyAIShipLevel1SpecialEncounter : EnemyBehavior {

	enum MoveState {begin = 0, top, diagonal, bottom};
	MoveState state;
	public float startDelay;
	float fireTimer;
	public float[] fireTimes;
	//Keep track of what time is next in the bullets to fire.
	int shotsFired;

	/// <summary>
	/// If this is true instead of starting at the top and traveling
	/// diagonally down, the enemy will start at the bottom of the
	/// screen and move diagonally up.
	/// </summary>
	public bool isReverse;
	// Use this for initialization
	void Awake () {
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		state = MoveState.begin;
		if (!isReverse) {
			transform.position = new Vector2 (7.0f, 5.0f);
		} else {
			transform.position = new Vector2 (7.0f, -5.0f);
		}
		StartStandStill (startDelay);
		fireTimer = 0.0f;

		shotsFired = 0;

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy4_B_hit");

		GivePointObject ("PointIcon1_0", 0.1f);

	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement ();
		//Dont shoot if we haven't started to move 
		if (state != MoveState.begin) {
			Shooting ();
		}
		if (GetIsTimeUp ()) {
			switch (state){
			case MoveState.begin:
				state = MoveState.top;
				if(!isReverse){
					transform.position = new Vector2 (7.0f, 3.5f);
					StartNewVelocity (new Vector2 (-3.0f, 0.0f), 1.0f);
				}
				else{
					transform.position = new Vector2 (7.0f, -3.5f);
					StartNewVelocity (new Vector2 (-3.0f, 0.0f), 1.0f);
				}
				break;
			case MoveState.top:
				state = MoveState.diagonal;
				if(!isReverse){
					StartNewVelocity(new Vector2(-3.0f, -3.5f), 2.0f);
				}
				else{
					StartNewVelocity(new Vector2(-3.0f, 3.5f), 2.0f);
				}
				break;
			case MoveState.diagonal:
				StartNewVelocity (new Vector2 (-3.0f, 0.0f), 2.0f);
				state = MoveState.bottom;
				break;
			case MoveState.bottom:
				Destroy(gameObject);
				break;
			}
		}
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("enemy4_B_hit")) {
			animator.SetInteger("animState", 0);
		}

	}
	

	void Shooting(){
		//advance the timer
		fireTimer += Time.deltaTime;
		//if there are more bullets to fire
		if (shotsFired != fireTimes.Length) {
			//If the fireTimer has gone far enough to shoot again.
			if(fireTimer > fireTimes[shotsFired]){
				shotsFired++;
				Shoot ();
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
	}

}
