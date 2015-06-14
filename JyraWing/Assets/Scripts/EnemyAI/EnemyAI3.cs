using UnityEngine;
using System.Collections;

public class EnemyAI3 : EnemyBehavior{

	int moveState;
	float shootTimer;

	public bool reverse;
	private float modify;
	// Use this for initialization
	void Start () {
		moveState = 0;
		EnemyDefaults ();
		//InitializeBullets (2);
		AudioClip explosionClip = Resources.Load ("Audio/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);
		shootTimer = 0.0f;
		if (reverse) {
			modify = -1.0f;
		} else {
			modify = 1.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(GetIsTimeUp())
		{
			switch (moveState) {
			case 0:
				moveState = 1;
				StartNewMovement(new Vector3(6.0f, -4.0f*modify), 1.0f);
				break;
			case 1:
				moveState = 2;
				StartNewMovement(new Vector3(6.0f, 4.0f*modify), 1.0f);
				break;
			case 2:
				moveState = 3;
				StartNewMovement(new Vector3(0.0f, 4.0f*modify), 1.0f);
				break;
			case 3:
				moveState = 4;
				StartNewMovement(new Vector3(0.0f, -4.0f*modify), 1.0f);
				break;
			case 4:
				moveState = 5;
				StartNewMovement(new Vector3(0.0f, -8.0f*modify), 0.5f);
				break;
			case 5:
				Destroy(gameObject);
				break;
			}
		}
		shootTimer += Time.deltaTime;
		if (shootTimer > 0.8f) {
			shootTimer = 0.0f;
			Shoot ();
		}
		Movement ();
	}
}
