using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIDiamondOscillate : EnemyBehavior {

	public Vector2 direction;
	public float time;
	public bool repeat;

	bool dir;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		dir = true;
		StartNewVelocity (direction, time);
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy3_hit");

		GivePointObject ("PointIcon0_0", 0.0f);
	}
	

	// Update is called once per frame
	void Update () {
		if (_paused) {
			return;
		}
		Movement ();
		if (GetIsTimeUp ()) {
			if(repeat){
				if(dir){
					StartNewVelocity (-direction, time);
				}
				else{
					StartNewVelocity (direction, time);
				}

				dir = ! dir;
			}
			else{
				Destroy(gameObject);
			}
		}
		HandleHitAnimation ();
	}
}
