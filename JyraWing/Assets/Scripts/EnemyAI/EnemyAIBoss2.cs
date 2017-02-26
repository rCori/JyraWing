using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAIBoss2 : EnemyBehavior {

	public LevelControllerBehavior levelControllerBehavior;

    private static int BOSS_HEALTH = 200;
	//Animator animator;
	float fireTimer;
	float fireTimeLimit;
	//which state in any given attack pattern the boss is in
	int moveState;

	//which attack pattern the boss is currently in
	int currentPattern;
	//Keep count how far we are in a pattern.
	int patternCounter;

	int shuffleBagCounter;

	//Shuffle Bag to for selecting patterns
	ShuffleBag bag;
	
	/// <summary>
	/// Enemy is in the chargin animation.
	/// </summary>
	bool isCharging;
	/// <summary>
	/// Used for all effects this enemy has
	/// </summary>
	private AudioClip extraSFX;

    private Vector2[] sprayShotDirections;

    private IEnumerator straightShotMove, straightShotFirePattern, sprayShot, spreadShot;

	// Use this for initialization
	void Awake () {
		moveState = 0;
		currentPattern = 0;
		patternCounter = 0;
		isDestroyed = false;
		EnemyDefaults ();
		SetEnemyHealth (BOSS_HEALTH);
		HasAnimations animationSettings;
		animationSettings = HasAnimations.Destroy;
		SetAnimations (animationSettings);
		//InitializeBullets (20);
		AudioClip explosionClip = Resources.Load ("Audio/SFX/bossExplosion") as AudioClip;
		SetExplosionSfx (explosionClip);

		//Is the boss paused or not
		_paused = false;

		for (int i = 0; i < 10; i++) {
			GivePointObject (3, i*0.1f);
		}

        GameObject enemyHealthBar = Resources.Load("UIObjects/BossHealthBar") as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        enemyHealthBar = Instantiate(enemyHealthBar);
        enemyHealthBar.transform.SetParent(canvas.transform, false);
        enemyHealthBar.GetComponentInChildren<EnemyHealthBar>().InitEnemyInfo(this);

        destroyEvent += OnBossDestruction;

        sprayShotDirections = initSprayShotDirections();

        straightShotMove = straightShotMoveRoutine();
        straightShotFirePattern = straightShotFireRoutine();
        sprayShot = sprayShotRoutine();
        spreadShot = spreadShotRoutine();

        //Set up shuffle bag
		createShuffleBag ();
        StartCoroutine(enterStage());
	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
        if(hitPoints == 0) {
            //Immediatly stop the current fire pattern
            switch(currentPattern) {
                case 0:
                    StopCoroutine(straightShotMove);
                    StopCoroutine(straightShotFirePattern);
                    break;
                case 1:
                    StopCoroutine(sprayShot);
                    break;
                case 2:
                    StopCoroutine(spreadShot);
                    break;
                default:
                    break;
            }
        }
	}

    IEnumerator enterStage() {
        StartNewMovement (new Vector3 (5f, 0f, 0f), 0.8f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.8f));
        changePattern();
        yield return null;
    }

    IEnumerator spreadShotRoutine() {
        animator.SetInteger("animState", 0);
		isCharging = false;

		StartStandStill(2.0f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(2.0f));

        for(int i = 0; i < 3; i++) {
            StartNewMovement (new Vector3 (5f, -3f, 0f), 0.8f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.8f));

            StartStandStill (0.2f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.2f));
		    Shoot (new Vector2 (-6f, 2f),true);
		    Shoot (new Vector2 (-6f, 3f),true);
		    Shoot (new Vector2 (-6f, 4f),true);
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 3.0f, false);
            StartNewMovement (new Vector3 (5f, 0f, 0f), 0.5f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));

            StartStandStill (0.2f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.2f));
		    Shoot (new Vector2 (-6f, -1f), true);
		    Shoot (new Vector2 (-6f, 0f), true);
		    Shoot (new Vector2 (-6f, 1f), true);

            StartNewMovement (new Vector3 (5f, 3f, 0f), 0.5f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));

            StartStandStill (0.2f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.2f));
		    Shoot (new Vector2 (-6f, -2f),true);
		    Shoot (new Vector2 (-6f, -3f),true);
		    Shoot (new Vector2 (-6f, -4f),true);
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 3.0f, false);
        }
        StartNewMovement (new Vector3 (5f, 0f, 0f), 0.5f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
        changePattern();
    }

    IEnumerator straightShotMoveRoutine() {
        animator.SetInteger("animState", 0);
		isCharging = false;

        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(2.0f));
        for(int i = 0; i < 3; i++) {
            StartNewMovement (new Vector3 (5f, -3, 0f), 0.8f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.8f));
            StartNewMovement (new Vector3 (5f, 3f, 0f), 0.8f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.8f));
        }
        StartNewMovement (new Vector3 (5f, 0f, 0f), 0.8f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.8f));
        changePattern();
    }

    IEnumerator straightShotFireRoutine() {

        while(true) {
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 3.5f, true);
            Shoot (new Vector2 (-8f, 0f), true);
            Shoot(new Vector2(-6f, 0f), new Vector2 (0f, -0.75f));
            Shoot(new Vector2(-6f, 0f), new Vector2 (0f, 0.75f));
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(Random.Range(0.7f, 1.0f)));
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 3.5f, true);
            Shoot (new Vector2 (-8f, 0f));
            Shoot(new Vector2(-6f, 0f), new Vector2 (0f, -0.75f), true);
            Shoot(new Vector2(-6f, 0f), new Vector2 (0f, 0.75f));
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(Random.Range(0.7f, 1.0f)));
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 3.5f, true);
            Shoot (new Vector2 (-8f, 0f), true);
            Shoot(new Vector2(-6f, 0f), new Vector2 (0f, -0.75f));
            Shoot(new Vector2(-6f, 0f), new Vector2 (0f, 0.75f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(Random.Range(0.7f, 1.0f)));
        }
    }

    IEnumerator sprayShotRoutine() {
        for(int i = 0; i<sprayShotDirections.Length; i++) {
            Shoot(sprayShotDirections[i]);
            if(i%4 == 0) {
                 Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 3.5f, true);
            }
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
        }
        changePattern();
       
    }




    private Vector2[] initSprayShotDirections() {
        Vector2[] dir = new Vector2[9];
        float bulletSpeed = 4.0f;
        dir[0] = new Vector2(-0.5f, 0.2f).normalized * bulletSpeed;
        dir[1] = new Vector2(-0.5f, 0.1f).normalized * bulletSpeed;
        dir[2] = new Vector2(-0.5f, 0.0f).normalized * bulletSpeed;
        dir[3] = new Vector2(-0.5f, -0.1f).normalized * bulletSpeed;
        dir[4] = new Vector2(-0.5f, -0.2f).normalized * bulletSpeed;
        dir[5] = new Vector2(-0.5f, -0.15f).normalized * bulletSpeed;
        dir[6] = new Vector2(-0.5f, -0.05f).normalized * bulletSpeed;
        dir[7] = new Vector2(-0.5f, 0.05f).normalized * bulletSpeed;
        dir[8] = new Vector2(-0.5f, 0.15f).normalized * bulletSpeed;
        return dir;
    }

	/// <summary>
	/// Increments the pattern and resets counters used in any partiuclar pattern.
	/// </summary>
	void changePattern(){
		StartNewMovement (new Vector3 (5f, 0f, 0f), 0.8f);
		shuffleBagCounter++;
		if (shuffleBagCounter > 2) {
			createShuffleBag ();
		}
		patternCounter = 0;
		moveState = 0;
		fireTimer = 0;
		fireTimeLimit = 0;
		int patternNum = bag.Next ();
        BulletPatternShift(patternNum);
	}

    public void BulletPatternShift(int patternNum) {
        //Turn off the routines for the current pattern
        switch(currentPattern) {
        case 0:
            StopCoroutine(straightShotMove);
            StopCoroutine(straightShotFirePattern);
            break;
        case 1:
            StopCoroutine(sprayShot);
            break;
        case 2:
            StopCoroutine(spreadShot);
            break;
        default:
            break;

        }
        currentPattern = patternNum;
        //Turn on the coroutines for the new pattern
        switch(currentPattern) {
        
        case 0:
            straightShotMove = straightShotMoveRoutine();
            straightShotFirePattern = straightShotFireRoutine();
            StartCoroutine(straightShotMove);
            StartCoroutine(straightShotFirePattern);
            break;
        case 1:
            sprayShot = sprayShotRoutine();
            StartCoroutine(sprayShot);
            break;
        case 2:
            spreadShot = spreadShotRoutine();
            StartCoroutine(spreadShot);
            break;
        default:
            break;
        }
    }


	void createShuffleBag(){
		shuffleBagCounter = 0;
		bag = new ShuffleBag (3);
		bag.Add (0, 1);
		bag.Add (1, 1);
		bag.Add (2, 1);
	}


    void OnBossDestruction(){
		//animator.SetInteger ("animState", 3);
		GameObject obj = GameObject.Find ("GameController");
		//The boss object could be destoryed on account of the level ending.
		//If that happens this object could be null so we check for that.
		if (obj) {
			//Use the new gameController now
			GameController controller = obj.GetComponent<GameControllerBehaviour>().GetGameController();
			levelControllerBehavior.HandleLevelFinished ();
		}
        //Then remove this even because there will be no other time to do that.
	    destroyEvent -= OnBossDestruction;
	}
		
}

