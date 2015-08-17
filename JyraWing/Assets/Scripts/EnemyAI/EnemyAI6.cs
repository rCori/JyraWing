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

	Animator animator;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		//This enemy is not destoryed by touching the left wall.
		LeftWallException = true;
		//Give an extra rotation of 
		transform.Rotate(0f,0f,angle+180);
		SetEnemyHealth (hits);
		radians = Mathf.Deg2Rad * angle;
		float xVel = Mathf.Cos (radians);
		float yVel = Mathf.Sin (radians);
		direction = new Vector2 (xVel, yVel);
		StartNewVelocity(direction * speed,lifeTime);
		animator = gameObject.GetComponent<Animator> ();
	}



	// Update is called once per frame
	void Update () {
		Movement ();
		if (GetIsTimeUp ()) {
			Destroy(gameObject);
		}
		timer += Time.deltaTime;
		if (timer > fireRate) {
			Shoot(direction * speed * bulletSpeed);
			timer = 0.0f;
		}
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("enemyBHit")) {
			animator.SetInteger("animState", 0);
		}
		//Return from hit animation to neutral animation.
	}

	void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
		//Additional behavior
		
		if (other.tag == "Bullet") {
			animator.SetInteger("animState", 1);
		}
	}
}
