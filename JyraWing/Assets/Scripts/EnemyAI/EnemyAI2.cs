using UnityEngine;
using System.Collections;

public class EnemyAI2 : EnemyBehavior {

	/// <summary>
	/// Timer that will count from 0 to 2pi seconds
	/// </summary>
	float circleTimer;

	// Use this for initialization
	void Start () {
		circleTimer = 0.0f;
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);
	}
	
	// Update is called once per frame
	void Update () {
		circleTimer += Time.deltaTime;
		if (circleTimer > (Mathf.PI*2)) {
			circleTimer = 0.0f;
		}
		//This makes the enemy rotate
		float xVel = Mathf.Cos(circleTimer) - 0.5f;
		float yVel = Mathf.Sin (circleTimer)*0.7f;
		Vector2 newVelocity = new Vector2(xVel,yVel);
		StartNewVelocity(newVelocity,0.1f);
		Movement ();
	}
}
