using UnityEngine;
using System.Collections;

public class EnemyAI6 : EnemyBehavior {

	//The value to apply to the z component of rotation
	public float angle;

	public float speed;
	public float lifeTime;
	public float fireRate;
	public float bulletSpeed;

	public int hits;

	private float radians;

	private float timer;
	private Vector2 direction;


	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		//This enemy is not destoryed by touching the left wall.
		LeftWallException = true;
		//Give an extra rotation of 
		transform.Rotate(0f,0f,angle+180);
		if ((angle >= -90.0f && angle <= 90.0f) || angle >= 270) {
			Vector3 theScale = transform.localScale;
			theScale.y *= -1;
			transform.localScale = theScale;
		}
		SetEnemyHealth (hits);

		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;

		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy4_B_hit");

		radians = Mathf.Deg2Rad * angle;
		float xVel = Mathf.Cos (radians);
		float yVel = Mathf.Sin (radians);
		direction = new Vector2 (xVel, yVel);
		StartNewVelocity(direction * speed, lifeTime);
	}



	// Update is called once per frame
	void Update () {
		if (isDestroyed) {
			return;
		}
		Movement ();
		if (GetIsTimeUp ()) {
			Destroy(gameObject);
		}
		timer += Time.deltaTime;
		if (timer > fireRate) {
			Shoot(direction * speed * bulletSpeed);
			timer = 0.0f;
		}
		HandleHitAnimation ();
		//Return from hit animation to neutral animation.
	}
	

	        
}
