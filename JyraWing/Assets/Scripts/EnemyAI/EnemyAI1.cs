using UnityEngine;
using System.Collections;

public class EnemyAI1 : EnemyBehavior {

	int moveState;
	int bulletCounter;
	

	void Awake(){
		moveState = 0;
		bulletCounter++;
		EnemyDefaults ();
		//InitializeBullets (2);
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(GetIsTimeUp())
		{
			switch (moveState) {
			case 0:
				moveState = 1;
				StartNewVelocity(new Vector2(-0.75f,-1f) ,0.5f);
				break;
			case 1:
				moveState = 0;
				StartNewVelocity(new Vector2(-0.75f,1f), 0.5f);
				break;
			}
//			bulletCounter++;
//			if (bulletCounter > 3) {
//				bulletCounter = 0;
//				Shoot();
//			}
		}
		Movement ();
	}
}
