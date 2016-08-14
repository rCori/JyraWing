using UnityEngine;
using System.Collections;

public class EnemyAISimpleCircle : EnemyBehavior {

	/// <summary>
	/// Timer that will count from 0 to 2pi seconds
	/// </summary>
	float circleTimer;

	float spinSpeed;


	void Awake(){
		circleTimer = 0.0f;
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy3_hit");

		GivePointObject (0, 0.0f);

	}

	// Update is called once per frame
	void Update () {
		circleTimer += Time.deltaTime*14.0f;
		if (circleTimer > (Mathf.PI*2)) {
			circleTimer = 0.0f;
		}
		//This makes the enemy rotate
		float xVel = Mathf.Cos(circleTimer)*4;
		float yVel = Mathf.Sin (circleTimer)*4;
		Vector2 newVelocity = new Vector2(xVel-2f, yVel);
		if (GetIsTimeUp ()) {
			StartNewVelocity (newVelocity, 0.1f);
		}
		Movement ();
		HandleHitAnimation ();
	}
}
