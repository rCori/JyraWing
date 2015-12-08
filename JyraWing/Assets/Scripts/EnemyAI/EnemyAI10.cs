using UnityEngine;
using System.Collections;

public class EnemyAI10 : EnemyBehavior{

	public enum FireDirection{
		LEFT = 0,
		RIGHT,
		UP,
		DOWN,
	}
	
	public int Health = 2;
	//Define the rate of fire
	public float FireRate = 0.5f;
	//Define how fast the bullets fire
	public float BulletSpeed = 2.0f;
	//WHat direction the enemy is facing
	public FireDirection fireDirection;

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
		switch(fireDirection){
		case(FireDirection.DOWN):
			shootDir = new Vector2 (0f, -BulletSpeed);
			break;
		case(FireDirection.UP):
			shootDir = new Vector2(0f, BulletSpeed);
			break;
		case(FireDirection.LEFT):
			shootDir = new Vector2(-BulletSpeed, 0f);
			break;
		case(FireDirection.RIGHT):
			shootDir = new Vector2(BulletSpeed, 0f);
			break;
		}
		
		//Set timer to it's upper limit 
		timer = FireRate;
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
			timer = FireRate;
		}
		
		HandleHitAnimation();
	}


}
