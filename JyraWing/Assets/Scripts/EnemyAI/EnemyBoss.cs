using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBoss : EnemyBehavior {

	public int hits;
	Animator animator;
	float fireTimer;
	float fireTimeLimit;
	int moveState;


	// Use this for initialization
	void Start () {
		moveState = 0;
		EnemyDefaults ();
		SetEnemyHealth (hits);
		//InitializeBullets (20);
		animator = gameObject.GetComponent<Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);
	}
	
	// Update is called once per frame
	void Update () {
		if (GetIsTimeUp ()) {
			switch (moveState) {
			case 0:
				StartNewMovement (new Vector3 (5f, -3, 0f), 0.5f);
				moveState++;
				break;
			case 1:
				StartStandStill (0.2f);
				Shoot(new Vector2(-6f, 2f));
				Shoot(new Vector2(-6f, 3f));
				Shoot(new Vector2(-6f, 4f));
				moveState++;
				break;
			case 2:
				StartNewMovement (new Vector3 (5f, 3f, 0f), 0.5f);
				moveState++;
				break;
			case 3:
				StartStandStill (0.2f);
				Shoot(new Vector2(-6f, -2f));
				Shoot(new Vector2(-6f, -3f));
				Shoot(new Vector2(-6f, -4f));
				moveState = 0;
				break;
			}
		}
		Movement ();
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("bossHit")) {
			Debug.Log ("End Animation");
			animator.SetInteger("animState", 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
		//Additional behavior

		if (other.tag == "Bullet") {
			animator.SetInteger("animState", 1);
		}
	}

	void OnDestroy(){
		GameObject obj = GameObject.Find ("GameController");
		//The boss object could be destoryed on account of the level ending.
		//If that happens this object could be null so we check for that.
		if (obj) {
			GameController controller = obj.GetComponent<GameController> ();
			controller.LevelFinished ();
		}
	}

}
