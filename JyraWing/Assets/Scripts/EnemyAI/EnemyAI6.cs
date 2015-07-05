using UnityEngine;
using System.Collections;

public class EnemyAI6 : EnemyBehavior {

	//The value to apply to the z component of rotation
	public float angle;

	public float speed;
	public float lifeTime;
	public float fireRate;
	public float bulletSpeed;

	private float radians;

	private float timer;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);

		//Give an extra rotation of 
		transform.Rotate(0f,0f,angle+180);

		radians = Mathf.Deg2Rad * angle;
		float xVel = Mathf.Cos (radians);
		float yVel = Mathf.Sin (radians);
		direction = new Vector2 (xVel, yVel);
		StartNewVelocity(direction * speed,lifeTime);
	}

	// Update is called once per frame
	void Update () {
		Movement ();
		if (GetIsTimeUp ()) {
			Debug.Log ("Destroy");
			Destroy(gameObject);
		}
		timer += Time.deltaTime;
		if (timer > fireRate) {
			Shoot(direction * speed * bulletSpeed);
			timer = 0.0f;
		}
	}
}
