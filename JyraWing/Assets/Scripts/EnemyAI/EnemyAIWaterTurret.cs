using UnityEngine;
using System.Collections;

public class EnemyAIWaterTurret : EnemyBehavior{

	//Define the rate of fire
	private float FireRate = 0.6f;
	//Define how fast the bullets fire
	private float BulletSpeed = 4.0f;

	private int WATER_TURRET_HEALTH = 8;

	Vector2 shootDir;
	
	float timer;
	
	void Awake(){
		EnemyDefaults ();
        shootDir = gameController.playerPosition - gameObject.transform.position;
        shootDir.Normalize();
        shootDir.Set(shootDir.x * 4, shootDir.y * 4);
        //Set the explosions sound
        animator = gameObject.GetComponent <Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);
		
		//Set which animations this enemy has
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		//SetHitAnimationName ("waterTurret_hit");
		
		//Set timer to it's upper limit 
		timer = FireRate;

		SetEnemyHealth (WATER_TURRET_HEALTH);

		GivePointObject (2, 0.1f);
		GivePointObject (2, 0.1f);

	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
        Movement ();
		
		timer -= Time.deltaTime;
		if (timer <= 0) {
            shootDir = gameController.playerPosition - gameObject.transform.position;
            shootDir.Normalize();
            shootDir.Set(shootDir.x * 4, shootDir.y * 4);
            Shoot (shootDir, true);
			timer = FireRate;
		}
		
		HandleHitAnimation();
	}


}
