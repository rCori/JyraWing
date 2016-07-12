using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIDiamondOscillate : EnemyBehavior {

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
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("enemy3_hit");

		GameObject pointIcon = Resources.Load ("Pickups/PointIcons/PointIcon0_0") as GameObject;
		EnemyBehavior.PointObjectRelative origin1PointObject = new EnemyBehavior.PointObjectRelative ();
		origin1PointObject.pointObject = pointIcon;
		origin1PointObject.relativePos = new Vector2 (0.0f, 0.0f);

		List<EnemyBehavior.PointObjectRelative> pointSpawns = new List<EnemyBehavior.PointObjectRelative> ();
		pointSpawns.Add (origin1PointObject);
		SetPointObject (pointSpawns);
	}
	

	// Update is called once per frame
	void Update () {
		if (_paused) {
			return;
		}
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
		HandleHitAnimation ();
	}
}
