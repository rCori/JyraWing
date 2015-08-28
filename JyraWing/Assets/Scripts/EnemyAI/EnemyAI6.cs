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

	private bool isDestroyed;

	Animator animator;

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
		radians = Mathf.Deg2Rad * angle;
		float xVel = Mathf.Cos (radians);
		float yVel = Mathf.Sin (radians);
		direction = new Vector2 (xVel, yVel);
		StartNewVelocity(direction * speed, lifeTime);
		animator = gameObject.GetComponent<Animator> ();
		isDestroyed = false;

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
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("enemy4_B_hit")) {
			animator.SetInteger("animState", 0);
		}
		//Return from hit animation to neutral animation.
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (isDestroyed) {
			return;
		}
		if (other.tag == "Bullet") {
			if(hitPoints == 0)
			{
				return;
			}
			hitPoints--;
			
			//This will get rid of the 
			other.GetComponent<Bullet>().BulletDestroy();
			
			if(hitPoints == 0)
			{
				
				if(!sfxPlayer){
					sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				}
				//SoundEffectPlayer effectPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				sfxPlayer.PlaySoundClip(explosionSfx);
				
				isDestroyed = true;
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, 0f);
				animator.SetInteger("animState", 2);
			}
			else
			{
				if(!sfxPlayer){
					sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
				}
				sfxPlayer.PlayClip(hitSfx);
				animator.SetInteger("animState", 1);
			}
		}
		
		if (other.tag == "Player" && other.isTrigger) {
			Player player = other.gameObject.GetComponent<Player>();
			player.TakeDamage();
		}
	}

	void DestroySelf()
	{
		Destroy (gameObject);
	}
	        
}
