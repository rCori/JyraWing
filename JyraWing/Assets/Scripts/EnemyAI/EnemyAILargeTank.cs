using UnityEngine;
using System.Collections;

public class EnemyAILargeTank : EnemyBehavior {

private int moveState;


	/// <summary>
	/// Fast speed vector
	/// </summary>
	private Vector2 fastVec;

	/// <summary>
	/// Slow speed vector
	/// </summary>
	private Vector2 slowVec; 



	private Vector2 upBul;
    private Vector2 upMiddleBul;
    private Vector2 middleBul;
    private Vector2 downMiddleBul;
	private Vector2 downBul;

    private float bulletSpeed = 2.3f;

	private int TANK_HEALTH = 20;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);
		moveState = 0;
		//Set the direction vectors for any direction.
		fastVec = new Vector2(-1.5f, 0f);
		slowVec = new Vector2( -1.0f, 0f);

        upBul = new Vector2(-1.5f, 0.6f);
        upMiddleBul = new Vector2(-1.7f, 0.2f);
		middleBul = new Vector2 (-1.85f, 0);
        downMiddleBul = new Vector2(-1.7f, -0.2f);
        downBul = new Vector2(-1.5f, -0.6f);
        
        LeftWallException = false;
			
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		//SetHitAnimationName ("tank_hit");
		SetEnemyHealth (TANK_HEALTH);

		GivePointObject (2, 0.2f);
		GivePointObject (1, 0.6f);
        GivePointObject (1, 0.3f);
        directionalFire();
	}
	

	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement ();
		if (GetIsTimeUp ()) {
			switch(moveState){
			case 0:
				//Fast movement of selected direction for 1 second
				moveState = 1;
                directionalFire();
				StartNewVelocity(slowVec, 2.5f);
				break;
			case 1:
				//slow movement of selected direciton for one second.
				moveState = 0;
                directionalFire();
				StartNewVelocity(fastVec, 1.5f);
				break;
			}
		}
		HandleHitAnimation ();
	}

	void directionalFire()
	{
		
		Shoot (upBul);
        Shoot (upMiddleBul);
        Shoot (middleBul);
        Shoot (downMiddleBul);
		Shoot (downBul);
	}

}
