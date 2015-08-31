using UnityEngine;
using System.Collections;

//AI for dimond enemy Enemy_A
public class EnemyAI1 : EnemyBehavior {

	int moveState;
	

	void Awake(){
		moveState = 0;
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy_3_hit");
	}
	

	// Update is called once per frame
	void Update () {
		if (isDestroyed) {
			return;
		}
		if(GetIsTimeUp()){
			switch (moveState) {
			case 0:
				moveState = 1;
				StartNewVelocity(new Vector2(-0.75f,-1f) ,0.5f);
				break;
			case 1:
				moveState = 0;
				StartNewVelocity(new Vector2(-0.75f,1f), 0.5f);
				break;
			}
		}
		Movement ();
		HandleHitAnimation ();
	}
}
