using UnityEngine;
using System.Collections;

public class EnemyAIBoss1 : EnemyBehavior {

    public LevelControllerBehavior levelControllerBehavior;

    private int currentPattern = 0;

    private IEnumerator firePattern1;

    private int BOSS1_HITS = 50;

	void Awake(){
		EnemyDefaults ();
        SetEnemyHealth (BOSS1_HITS);
        firePattern1 = FirePattern1();
        BulletPatternShift(0);
        HasAnimations animationSettings;
		animationSettings = HasAnimations.Destroy;
		SetAnimations (animationSettings);

        AudioClip explosionClip = Resources.Load ("Audio/SFX/bossExplosion") as AudioClip;
		SetExplosionSfx (explosionClip);

        for (int i = 0; i < 5; i++) {
			GivePointObject (0, i*0.1f);
		}
        for (int i = 0; i < 2; i++) {
			GivePointObject (1, i*0.5f);
		}

	}
	
    // Update is called once per frame
	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement();
	}

    public void BulletPatternShift(int patternNum) {
        //Turn off the routines for the current pattern
        switch(currentPattern) {
        case 0:
            StopCoroutine(firePattern1);
            break;
        default:
            break;

        }
        currentPattern = patternNum;
        //Turn on the coroutines for the new pattern
        switch(currentPattern) {
        case 0:
            firePattern1 = FirePattern1();
            StartCoroutine(firePattern1);
            break;
        default:
            break;

        }
    }

    IEnumerator FirePattern1() {
        while(true) {
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized * 2.8f, new Vector2(0f, 1.5f));
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 2.8f, new Vector2(0f, -1.5f));
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
            Shoot(new Vector2(-2f,0f));
            Shoot(new Vector2(-2f,0f), new Vector2(0f,-0.5f));
            Shoot(new Vector2(-2f,0f), new Vector2(0f,0.5f));
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 2.8f, new Vector2(0f, 1.5f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 2.8f, new Vector2(0f, -1.5f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
            Shoot(new Vector2(-2f,0f), true);
            Shoot(new Vector2(-2f,0f), new Vector2(0f,-0.5f), true);
            Shoot(new Vector2(-2f,0f), new Vector2(0f,0.5f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
        }
    }

    public override bool paused
    {
        get
        {
            return _paused;
        }

        set
        {
            _paused = value;
            if (_paused)
            {
                storedVel = rigidybody2D.velocity;
                rigidybody2D.velocity = new Vector2(0.0f, 0.0f);
                animator.speed = 0f;
            }
            else
            {
                rigidybody2D.velocity = storedVel;
                animator.speed = 1f;
            }
        }
    }

    void OnDestroy()
    {
        if (levelControllerBehavior != null)
        {
            levelControllerBehavior.HandleLevelFinished();
        }
    }

}
