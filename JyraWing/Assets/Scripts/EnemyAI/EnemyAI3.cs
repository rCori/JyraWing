using UnityEngine;
using System.Collections;

public class EnemyAI3 : EnemyBehavior{

	int moveState;
	//float shootTimer;

	public bool reverse;
	private float modify;

	float incrementX;
	// Use this for initialization
	void Start () {
		moveState = 0;
		EnemyDefaults ();
		//InitializeBullets (2);
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		//shootTimer = 0.0f;
		if (reverse) {
			modify = -1.0f;
		} else {
			modify = 1.0f;
		}
		incrementX = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(GetIsTimeUp())
		{
			switch (moveState) {
			case 0:
				moveState = 1;
				StartNewMovement(new Vector3(5.0f - incrementX, -3.5f*modify), 0.5f);
				break;
			case 1:
				moveState = 0;
				StartNewMovement(new Vector3(5.0f - incrementX, 3.5f*modify), 1.5f);
				incrementX += 3.0f;
				modify = -modify;
				if(incrementX > 12.0f)
				{
					Destroy (gameObject);
				}
				break;
			}
		}
//		shootTimer += Time.deltaTime;
//		if (shootTimer > 0.8f) {
//			shootTimer = 0.0f;
//			Shoot ();
//		}
		Movement ();
	}
}
