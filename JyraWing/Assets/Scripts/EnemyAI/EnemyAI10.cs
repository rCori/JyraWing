using UnityEngine;
using System.Collections;

public class EnemyAI10 : EnemyBehavior{

	public int Health;
	
	Vector2 shootDir;

	float timer;

	void Awake(){
		EnemyDefaults ();
		SetEnemyHealth (Health);
		
		//Set the explosions sound
		animator = gameObject.GetComponent <Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		
		//Set which animations this enemy has
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("waterTurret_hit");

		//Set the direction the turret shoots in
		shootDir = new Vector2 (-2.0f, 0f);

		//Set timer to it's upper limit 
		timer = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement ();

		timer -= Time.deltaTime;
		if (timer <= 0) {
			Shoot (shootDir, true);
			timer = 0.5f;
		}

		HandleHitAnimation();
	}


}
