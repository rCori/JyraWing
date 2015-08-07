using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBoss : EnemyBehavior {
	

	public int hits;
	Animator animator;
	float fireTimer;
	float fireTimeLimit;
	//which state in any given attack pattern the boss is in
	int moveState;

	//which attack pattern the boss is currently in
	int pattern;
	//Keep count how far we are in a pattern.
	int patternCounter;

	int shuffleBagCounter;

	//Shuffle Bag to for selecting patterns
	ShuffleBag bag;

	// Use this for initialization
	void Start () {
		moveState = 0;
		pattern = 0;
		patternCounter = 0;
		EnemyDefaults ();
		SetEnemyHealth (hits);
		//InitializeBullets (20);
		animator = gameObject.GetComponent<Animator> ();
		AudioClip explosionClip = Resources.Load ("Audio/explosion1") as AudioClip;
		SetExplosionSfx (explosionClip);

		//Set up shuffle bag
		createShuffleBag ();
		incrementPattern ();
	}
	
	// Update is called once per frame
	void Update () {
		//Do any of the 4 patterns.
		if (pattern == 0) {
			spreadShot ();
		} else if (pattern == 1) {
			straightShot ();
		} else if (pattern == 2) {
			trackAndRam();
		}
		else if (pattern == 3){
			sprayShot ();
		}

		Movement ();
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("bossHit")) {
			animator.SetInteger("animState", 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
		//Additional behavior

		if (other.tag == "Bullet") {
			animator.SetInteger("animState", 1);
		}
	}

	void OnDestroy(){
		GameObject obj = GameObject.Find ("GameController");
		//The boss object could be destoryed on account of the level ending.
		//If that happens this object could be null so we check for that.
		if (obj) {
			GameController controller = obj.GetComponent<GameController> ();
			controller.LevelFinished ();
		}
	}

	/// <summary>
	/// Moves up and down shooting in a three way spread 
	/// shot every time when stopping to go the other way
	/// </summary>
	void spreadShot(){
		if (GetIsTimeUp ()) {
			switch (moveState) {
			case 0:
				StartStandStill(2.0f);
				moveState++;
				break;
			case 1:
				StartNewMovement (new Vector3 (5f, -3, 0f), 0.5f);
				moveState++;
				break;
			case 2:
				StartStandStill (0.2f);
				Shoot (new Vector2 (-6f, 2f));
				Shoot (new Vector2 (-6f, 3f));
				Shoot (new Vector2 (-6f, 4f));
				moveState++;
				break;
			case 3:
				StartNewMovement (new Vector3 (5f, 3f, 0f), 0.5f);
				moveState++;
				break;
			case 4:
				StartStandStill (0.2f);
				Shoot (new Vector2 (-6f, -2f));
				Shoot (new Vector2 (-6f, -3f));
				Shoot (new Vector2 (-6f, -4f));
				moveState = 1;
				patternCounter++;
				break;
			}
		}

		if (patternCounter > 3) {
			incrementPattern();
		}
	}

	/// <summary>
	/// Moves up and down shooting three bullet straight out
	/// from the middle, top and bottom of the sprite when stopiing to 
	/// turn around.
	/// </summary>
	void straightShot(){
		if (GetIsTimeUp ()) {
			switch (moveState) {
			case 0:
				StartStandStill(2.0f);
				fireTimeLimit = Random.Range(0.7f,1.0f);
				fireTimer = 0.0f;
				moveState++;
				break;
			case 1:
				StartNewMovement (new Vector3 (5f, -3, 0f), 0.8f);
				moveState++;
				break;
			case 2:
				StartStandStill (0.2f);
				moveState++;
				break;
			case 3:
				StartNewMovement (new Vector3 (5f, 3f, 0f), 0.8f);
				moveState++;
				break;
			case 4:
				StartStandStill (0.2f);
				moveState = 1;
				patternCounter++;
				break;
			}
		}

		if (patternCounter > 3) {
			incrementPattern();
		}

		fireTimer += Time.deltaTime;
		if (fireTimer > fireTimeLimit) {
			straightShotFire();
			fireTimeLimit = Random.Range(0.7f,1.0f);
			fireTimer = 0.0f;
		}

	}

	/// <summary>
	/// The actual shooting for the straight shot pattern.
	/// </summary>
	void straightShotFire()
	{
		GameObject bulletObjTop;
		GameObject bulletObjBottom;
		EnemyBullet bulletTop;
		EnemyBullet bulletBottom;
		Shoot (new Vector2 (-8f, 0f));
		bulletObjTop = bulletPool.GetBullet ();
		//We check if the bullet is valid, if it is then shoot it.
		if (bulletObjTop) {
			bulletTop = bulletObjTop.GetComponent<EnemyBullet> ();
			bulletObjTop.transform.position = transform.position + new Vector3 (0f, -0.75f, 0f);
			bulletTop.Shoot (new Vector2 (-6f, 0f));
			
		}
		bulletObjBottom = bulletPool.GetBullet ();
		if (bulletObjBottom) {
			bulletBottom = bulletObjBottom.GetComponent<EnemyBullet> ();
			bulletObjBottom.transform.position = transform.position + new Vector3 (0f, 0.75f, 0f);
			bulletBottom.Shoot (new Vector2 (-6f, 0f));
		}
	}


	/// <summary>
	/// pattern for boss to track the player vertically and the ram towards them
	/// </summary>
	void trackAndRam(){
		if (GetIsTimeUp()) {
			switch(moveState)
			{
			case 0:
				fireTimer = 0.0f;
				fireTimeLimit = 2.5f;
				//Return to original position.
				StartStandStill(2.0f);

				moveState++;
				break;
			case 1:
				StartStandStill(2.0f);
				moveState++;
				patternCounter++;
				break;
			case 2:
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, 0f);
				StartNewVelocity(new Vector2(-10.0f, 0f), 1.1f);
				moveState++;
				break;
			case 3:
				StartNewMovement (new Vector3 (5f, gameObject.transform.position.y, 0f), 0.5f);
				moveState = 1;
				break;
			}
		}

		// Increment the pattern counter
		// This pattern happens twice.
		if (patternCounter > 3) {
			incrementPattern();
			moveState = 0;
		}

		// Move during the stand still.
		if (moveState == 2) {
			float bossY = gameObject.transform.position.y;
			float playerY = gameController.GetPlayerPosition().y;
			if(bossY>playerY){
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, -1.2f);
			}
			else if(bossY<playerY){
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, 1.2f);
			}
		}

		fireTimer += Time.deltaTime;
		if (fireTimer > fireTimeLimit) {
			Shoot (new Vector2(-3f, -1f));
			Shoot (new Vector2(-3f, 1f));
			fireTimeLimit = Random.Range(0.7f,1.0f);
			fireTimer = 0.0f;
		}
	}

	void sprayShot(){
		if (GetIsTimeUp ()) {
			float bulletSpeed = 4f;
			Vector2 dir;
			switch (moveState) {
			case 0:
				//Return to original position.
				StartStandStill(2.0f);
				break;
			case 1:
				dir = new Vector2(-0.5f, 0.2f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 2:
				dir = new Vector2(-0.5f, 0.1f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 3:
				dir = new Vector2(-0.5f, 0f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 4:
				dir = new Vector2(-0.5f, -0.1f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 5:
				dir = new Vector2(-0.5f, -0.2f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 6:
				dir = new Vector2(-0.5f, -0.15f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 7:
				dir = new Vector2(-0.5f, -0.05f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 8:
				dir = new Vector2(-0.5f, 0.05f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			case 9:
				dir = new Vector2(-0.5f, 0.15f);
				dir.Normalize();
				Shoot (dir*bulletSpeed);
				break;
			}
			moveState++;
			if(moveState > 9){
				moveState = 1;
				patternCounter++;
			}

			// Increment the pattern counter
			// This pattern happens twice.
			if (patternCounter > 3) {
				incrementPattern();
				moveState = 0;
			}
			StartStandStill(0.5f);	

		}
	}

	/// <summary>
	/// Increments the pattern and resets counters used in any partiucalr pattern.
	/// </summary>
	void incrementPattern(){
		StartNewMovement (new Vector3 (5f, 0f, 0f), 0.8f);
		shuffleBagCounter++;
		if (shuffleBagCounter > 3) {
			createShuffleBag();
		}
		patternCounter = 0;
		moveState = 0;
		fireTimer = 0;
		fireTimeLimit = 0;
		int patternNum = bag.Next ();
		pattern = patternNum;
	}


	void createShuffleBag(){
		shuffleBagCounter = 0;
		bag = new ShuffleBag (4);
		bag.Add (0, 1);
		bag.Add (1, 1);
		bag.Add (2, 1);
		bag.Add (3, 1);
	}
}
