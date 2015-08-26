using UnityEngine;
using System.Collections;

public class EnemyAI9 : EnemyBehavior {

	enum MoveState {begin = 0, top, diagonal, bottom};
	MoveState state;
	public float fireDelay;
	public float fireRate;
	public float startDelay;
	bool isFiring;
	float fireTimer;

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
		isFiring = false;
		fireTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
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
				StartNewVelocity (new Vector2 (-3.0f, 0.0f), 1.0f);
				state = MoveState.bottom;
				break;
			case MoveState.bottom:
				Destroy(gameObject);
				break;
			}
		}

	}

	void Shooting(){
		fireTimer += Time.deltaTime;
		//If we have waited past the delay to shoot
		if (isFiring) {
			if (fireTimer > fireRate) {
				Shoot ();
				fireTimer = 0.0f;
			}
		//We are still waiting to shoot.
		} else {
			if(fireTimer > fireDelay){
				//Now we can start shooting
				isFiring = true;
				fireTimer = 0.0f;
			}
		}
	}
}
