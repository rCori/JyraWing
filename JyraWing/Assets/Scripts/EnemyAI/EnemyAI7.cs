using UnityEngine;
using System.Collections;

public class EnemyAI7 : EnemyBehavior {

	int directionCounter;

	public float bulletSpeed;
	public float shotTime;
	public int health;
	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		directionCounter = 0;
		SetEnemyHealth (health);
		StartStandStill (0.1f);
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("largeTurretHit");
	}

	void Update(){
		//Do not activate this trigger if the enemy has been destroyed.
		if (isDestroyed) {
			return;
		}
		Movement ();
		if (GetIsTimeUp ()) {
			Vector2 dir;
			switch (directionCounter) {
			case 0:
				dir = new Vector2(-0.5f, 0.2f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 1:
				dir = new Vector2(-0.5f, 0.1f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 2:
				dir = new Vector2(-0.5f, 0f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 3:
				dir = new Vector2(-0.5f, -0.1f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 4:
				dir = new Vector2(-0.5f, -0.2f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 5:
				dir = new Vector2(-0.5f, -0.15f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 6:
				dir = new Vector2(-0.5f, -0.05f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 7:
				dir = new Vector2(-0.5f, 0.05f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 8:
				dir = new Vector2(-0.5f, 0.15f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			}
			directionCounter++;
			if(directionCounter > 8){
				directionCounter = 0;
			}
			StartStandStill(shotTime);

		}
		HandleHitAnimation ();
	}

	
}
