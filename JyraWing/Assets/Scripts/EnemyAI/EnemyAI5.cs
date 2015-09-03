using UnityEngine;
using System.Collections;


/// <summary>
/// The AI for the tank enemy
/// Moves at two different speeds in a single direction
/// Starts fast, then slow, then after stops and fires in a 3 bullet spread.
/// By setting TankDir direction, the enemy can do this in any of the 4 cardinal directions
/// </summary>
public class EnemyAI5 : EnemyBehavior {
	
	private int moveState;

	public enum TankDir {Left = 0, Right, Up, Down};
	public TankDir direction;

	//public float fireRate;

	/// <summary>
	/// Fast speed vector
	/// </summary>
	private Vector2 fastVec;

	/// <summary>
	/// Slow speed vector
	/// </summary>
	private Vector2 slowVec; 

	/// <summary>
	/// Vector for straight bullet movement
	/// </summary>
	private Vector2 straightBul;


	/// <summary>
	/// Vector for upward bullet movement
	/// </summary>
	private Vector2 upBul;


	/// <summary>
	/// Vector for downward bullet movement
	/// </summary>
	private Vector2 downBul;


	void Awake(){
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion2") as AudioClip;
		SetExplosionSfx (explosionClip);
		moveState = 0;
		//Set the direction vectors for any direction.
		switch (direction) {
		case TankDir.Left:
			fastVec = new Vector2(-1.5f, 0f);
			slowVec = new Vector2( -0.7f, 0f);
			
			straightBul = new Vector2 (-2f, 0);
			
			upBul = new Vector2(-1f,1f);
			upBul.Normalize();
			upBul *= 2;
			
			downBul = new Vector2(-1f,-1f);
			downBul.Normalize();
			downBul *= 2;
			LeftWallException = false;
			break;
		case TankDir.Right:
			fastVec = new Vector2(2.5f, 0f);
			slowVec = new Vector2(1.5f, 0f);
			
			straightBul = new Vector2 (-2f, 0);
			
			upBul = new Vector2(1f,1f);
			upBul.Normalize();
			upBul *= 2;
			
			downBul = new Vector2(1f,-1f);
			downBul.Normalize();
			downBul *= 2;
			transform.Rotate(0f,0f,180f);
			LeftWallException = true;
			break;
		case TankDir.Up:
			fastVec = new Vector2(0f, 1.5f);
			slowVec = new Vector2(0f, 0.5f);
			
			straightBul = new Vector2(0, 2f);
			
			upBul = new Vector2(1f,1f);
			upBul.Normalize();
			upBul *= 2;
			
			downBul = new Vector2(-1f,1f);
			downBul.Normalize();
			downBul *= 2;
			transform.Rotate(0f,0f,-90f);
			LeftWallException = true;
			break;
		case TankDir.Down:
			fastVec = new Vector2(0f, -1.5f);
			slowVec = new Vector2(0f, -0.5f);
			
			straightBul = new Vector2(0, -2f);
			
			upBul = new Vector2(1f,-1f);
			upBul.Normalize();
			upBul *= 2;
			
			downBul = new Vector2(-1f,-1f);
			downBul.Normalize();
			downBul *= 2;
			
			transform.Rotate(0f,0f,90f);
			LeftWallException = true;
			break;
		}
		HasAnimations animationsOwned;
		animationsOwned = HasAnimations.Hit | HasAnimations.Destroy;
		
		SetAnimations (animationsOwned);
		SetHitAnimationName ("tank_hit");
	}
	

	// Update is called once per frame
	void Update () {
		if (isDestroyed) {
			return;
		}
		Movement ();
		selfDestruct ();
		if (GetIsTimeUp ()) {
			switch(moveState){
			case 0:
				//Fast movement of selected direction for 1 second
				moveState = 1;
				StartNewVelocity(slowVec, 2.5f);
				break;
			case 1:
				//slow movement of selected direciton for one second.
				moveState = 2;
				StartNewVelocity(fastVec, 0.5f);
				break;
			case 2:
				//Stand still for 1 second.
				moveState = 0;
				directionalFire();
				StartStandStill(1f);
				break;
			}
		}
		HandleHitAnimation ();
	}

	void directionalFire()
	{
		Shoot (straightBul);
		Shoot (upBul);
		Shoot (downBul);
	}

	//Should only be needed for the cases where direction is right, down, or up.
	void selfDestruct()
	{
		switch(direction)
		{
		case TankDir.Right:
			if(transform.position.x > 7.0f){
				Destroy (gameObject);
			}

			break;
		case TankDir.Up:
			if(transform.position.y > 4.5f){
				Destroy (gameObject);
			}
			break;
		case TankDir.Down:
			if(transform.position.y < -4.5f){
				Destroy (gameObject);
			}
			break;
		}
	}

}
