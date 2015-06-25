using UnityEngine;
using System.Collections;

public class EnemyAI5B : EnemyBehavior {

	private float shootTimer;
	private int moveState;

	
	// Use this for initialization
	void Start () {
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);
		shootTimer = 0.0f;
		moveState = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		if (GetIsTimeUp ()) {
			switch(moveState){
			case 0:
				moveState = 1;
				StartNewVelocity(new Vector2(-2.5f, 0f), 1f);
				break;
			case 1:
				moveState = 2;
				StartNewVelocity(new Vector2(-1.5f, 0f), 1f);
				break;
			case 2:
				moveState = 0;
				StartStandStill(1f);
				break;
			}
		}
		if (shootTimer > 2.0) {
			shootTimer = 0.0f;
			Shoot ();
		}
		shootTimer += Time.deltaTime;
	}
}
