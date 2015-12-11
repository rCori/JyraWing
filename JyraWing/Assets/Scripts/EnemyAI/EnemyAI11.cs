using UnityEngine;
using System.Collections;

public class EnemyAI11 :  EnemyBehavior{
	

	public float ySpeed = -2.0f;
	public float oscillationFactor = 0.5f;
	public float delayTimer = 0f;
	public float fireTimeLimit = 1.2f;

	private float timer;
	private float timeFactor;
	private float timeToDestroy;
	private Vector2 velocity;
	private bool inDelay;

	//Completly seperate timers for firing.
	private float fireTimer;
	private Vector2 bulletVel;

	void Awake(){
		timer = 0f;
		fireTimer = 0f;
		timeToDestroy = 10.0f/Mathf.Abs(ySpeed);
		timeFactor = 1f / timeToDestroy;

		bulletVel = new Vector2 (-1.5f, 0f);

		//Spawns may want to delay this showing up.
		inDelay = true;
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy3_hit");
	}



	void Update(){
		timer += Time.deltaTime;
		if (inDelay && timer > delayTimer) {
			inDelay = false;
			timer = 0f;
		}
		if (!inDelay) {
			float xVel = Mathf.Cos (timer * timeFactor * Mathf.PI) * oscillationFactor;
			velocity = new Vector2 (xVel, ySpeed);
			if (GetIsTimeUp ()) {
				StartNewVelocity (velocity, 0.1f);
			}		
			Movement ();
			HandleHitAnimation ();
			if (timer > timeToDestroy) {
				Destroy (gameObject);
			}
		}
		BulletUpdate ();

	}

	void BulletUpdate(){
		fireTimer += Time.deltaTime;
		if (fireTimer > fireTimeLimit) {
			fireTimer = 0f;
			Shoot (bulletVel, true);
		}
	}

}
