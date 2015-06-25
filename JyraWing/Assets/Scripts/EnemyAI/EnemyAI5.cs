using UnityEngine;
using System.Collections;

public class EnemyAI5 : EnemyBehavior {

	//Expermienting with not having a fire timer.
	//private float shootTimer;
	private int moveState;

	public enum TankDir {Left =0, Right, Up, Down};
	public TankDir direction;

	//public float fireRate;

	private Vector2 fastVec;
	private Vector2 slowVec;
	// Use this for initialization
	void Start () {
		EnemyDefaults ();
		AudioClip explosionClip = Resources.Load ("Audio/SFX/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);
		//shootTimer = 0.0f;
		moveState = 0;
		//Set the direction vectors for each and any direction.
		switch (direction) {
		case TankDir.Left:
			fastVec = new Vector2(-2.5f, 0f);
			slowVec = new Vector2( -1.5f, 0f);
			break;
		case TankDir.Right:
			fastVec = new Vector2(2.5f, 0f);
			slowVec = new Vector2(1.5f, 0f);
			transform.Rotate(0f,0f,180f);
			break;
		case TankDir.Up:
			fastVec = new Vector2(0f, 1.5f);
			slowVec = new Vector2(0f, 0.5f);
			transform.Rotate(0f,0f,-90f);
			break;
		case TankDir.Down:
			fastVec = new Vector2(0f, -1.5f);
			slowVec = new Vector2(0f, -0.5f);
			transform.Rotate(0f,0f,90f);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		selfDestruct ();
		if (GetIsTimeUp ()) {
			switch(moveState){
			case 0:
				//Fast movement of selectged direction for 1 second
				moveState = 1;
				StartNewVelocity(fastVec, 1f);
				break;
			case 1:
				//slow movement of selected direciton for one second.
				moveState = 2;
				StartNewVelocity(slowVec, 1f);
				break;
			case 2:
				//Stand still for 1 second.
				moveState = 0;
				directionalFire();
				StartStandStill(1f);
				break;
			}
		}
	}

	void directionalFire()
	{
		switch(direction)
		{
		case TankDir.Left:
			Shoot (new Vector2(-2f,0f));
			Shoot (new Vector2(-2f,0.5f));
			Shoot (new Vector2(-2f,-0.5f));
			break;
		case TankDir.Right:
			Shoot (new Vector2(2f,0f));
			Shoot (new Vector2(2f,0.5f));
			Shoot (new Vector2(2f,-0.5f));
			break;
		case TankDir.Up:
			Shoot (new Vector2(0f,2f));
			Shoot (new Vector2(-0.5f,2f));
			Shoot (new Vector2(0.5f,2f));
			break;
		case TankDir.Down:
			Shoot (new Vector2(0f,-2f));
			Shoot (new Vector2(-0.5f,-2f));
			Shoot (new Vector2(0.5f,-2f));
			break;
		}
	}

	//Should only be needed for the cases where direction is left, down, or up.
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
