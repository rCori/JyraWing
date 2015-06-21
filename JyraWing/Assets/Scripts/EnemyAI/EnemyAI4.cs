using UnityEngine;
using System.Collections;

public class EnemyAI4 : EnemyBehavior {

	private GameObject player;
	private Vector2 fireDir;

	private float shootTimer;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		fireDir = player.transform.position - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);
		shootTimer = 0.0f;
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);
	}
	
	// Update is called once per frame
	void Update () {
		fireDir = player.transform.position - gameObject.transform.position;
		fireDir.Normalize ();
		fireDir.Set(fireDir.x*4, fireDir.y*4);
		shootTimer += Time.deltaTime;
		if (shootTimer > 2.0f) {
			Shoot(fireDir);
			shootTimer = 0.0f;
		}
	}
}
