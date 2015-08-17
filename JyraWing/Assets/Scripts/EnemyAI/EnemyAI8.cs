using UnityEngine;
using System.Collections;

public class EnemyAI8 : EnemyBehavior {

	public Vector2 direction;
	public float time;
	public bool repeat;

	bool dir;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		dir = true;
		StartNewVelocity (direction, time);
	}
	

	// Update is called once per frame
	void Update () {
		Movement ();
		if (GetIsTimeUp ()) {
			if(repeat){
				if(dir){
					StartNewVelocity (-direction, time);
				}
				else{
					StartNewVelocity (direction, time);
				}

				dir = ! dir;
			}
			else{
				Destroy(gameObject);
			}
		}
	}
}
