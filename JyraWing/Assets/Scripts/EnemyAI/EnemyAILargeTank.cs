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

    private float bulletSpeed = 3.0f;

	private int TANK_HEALTH = 20;

	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/enemyHit") as AudioClip;
		SetExplosionSfx (explosionClip);
		moveState = 0;
		//Set the direction vectors for any direction.
		fastVec = new Vector2(-1.5f, 0f);
		slowVec = new Vector2( -1.0f, 0f);

        upBul = new Vector2(-1.0f, 0.15f).normalized * bulletSpeed*0.8f;
        upMiddleBul = new Vector2(0f, 0.3f);
		middleBul = new Vector2 (-1.0f, 0).normalized * bulletSpeed;
        downMiddleBul = new Vector2(0f, -0.3f);
        downBul = new Vector2(-1.0f, -0.15f).normalized * bulletSpeed*0.8f;
        
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

        GameObject enemyHealthBar = Resources.Load("UIObjects/EnemyHealthBar") as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        enemyHealthBar = Instantiate(enemyHealthBar);
        enemyHealthBar.transform.SetParent(canvas.transform);
        enemyHealthBar.transform.localPosition = new Vector2(0f, 0f);
        enemyHealthBar.GetComponent<EnemyHealthBar>().InitEnemyInfo(this);
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
		
		Shoot (upBul, false);
        Shoot (middleBul, upMiddleBul, false);
        Shoot (middleBul, false);
        Shoot (middleBul, downMiddleBul, false);
		Shoot (downBul,false);
	}

}
