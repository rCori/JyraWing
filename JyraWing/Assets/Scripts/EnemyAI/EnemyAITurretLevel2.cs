using UnityEngine;
using System.Collections;

public class EnemyAITurretLevel2: EnemyBehavior {

	public enum FireDirection{
		LEFT = 0,
		RIGHT,
		UP,
		DOWN,
	}

	//Define the rate of fire
	private float FireRate = 1.5f;
	//Define how fast the bullets fire
	private float BulletSpeed = 3.5f;
	//WHat direction the enemy is facing
	public FireDirection fireDirection;

	Vector2 shootDir0, shootDir1, shootDir2;

	float timer;
	private int TURRET_HEALTH = 5;

	void Awake(){
		EnemyDefaults ();

		//Set the explosions sound
		animator = gameObject.GetComponent <Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);

		//Set which animations this enemy has
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;

		SetAnimations (animationsOwned);

		//Set the direction the turret shoots in
		switch(fireDirection){
		case(FireDirection.DOWN):
			shootDir0 = new Vector2 (-0.4f, -BulletSpeed * 0.85f);
			shootDir1 = new Vector2 (0f, -BulletSpeed);
			shootDir2 = new Vector2 (0.4f, -BulletSpeed * 0.85f);
			break;
		case(FireDirection.UP):
			shootDir0 = new Vector2 (-0.4f, BulletSpeed * 0.85f);
			shootDir1 = new Vector2(0f, BulletSpeed);
			shootDir2 = new Vector2(0.4f, BulletSpeed * 0.85f);
			break;
		case(FireDirection.LEFT):
			shootDir0 = new Vector2(-BulletSpeed * 0.85f, 0.4f);
			shootDir1 = new Vector2(-BulletSpeed, 0f);
			shootDir2 = new Vector2(-BulletSpeed * 0.85f, -0.4f);
			break;
		case(FireDirection.RIGHT):
			shootDir0 = new Vector2(BulletSpeed * 0.85f, 0.4f);
			shootDir1 = new Vector2(BulletSpeed, 0f);
			shootDir2 = new Vector2(BulletSpeed * 0.85f, -0.4f);
			break;
		}

		//Set timer to it's upper limit 
		timer = FireRate;
		SetEnemyHealth (TURRET_HEALTH);
		for(int i = 0; i < 5; i++) {
            GivePointObject(1, 1.5f);
        }
        for(int i = 0; i < 2; i++) {
            GivePointObject(2, 1.0f);
        }

	}

	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement ();

		timer -= Time.deltaTime;
		if (timer <= 0) {
			Shoot (shootDir0, true);
			Shoot (shootDir1, true);
			Shoot (shootDir2, true);
			timer = FireRate;
		}

		HandleHitAnimation();
	}
}
