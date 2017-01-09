﻿using UnityEngine;
using System.Collections;

public class EnemyAIBoss1 : EnemyBehavior {

    public LevelControllerBehavior levelControllerBehavior;

    private int currentPattern = 0;

    private IEnumerator firePattern1, streamShieldableBullets;

    private int BOSS1_HITS = 100;
    private int patternValSet;

	void Awake(){
		EnemyDefaults ();
        SetEnemyHealth (BOSS1_HITS);
        firePattern1 = FirePattern1();
        streamShieldableBullets = StreamShieldableBullets();
        BulletPatternShift(0);
        HasAnimations animationSettings;
		animationSettings = HasAnimations.Destroy;
		SetAnimations (animationSettings);

        AudioClip explosionClip = Resources.Load ("Audio/SFX/bossExplosion") as AudioClip;
		SetExplosionSfx (explosionClip);

        StartCoroutine(MoveIntoPosition());

        patternValSet = -1;

        for (int i = 0; i < 5; i++) {
			GivePointObject (0, i*0.1f);
		}
        for (int i = 0; i < 2; i++) {
			GivePointObject (1, i*0.5f);
		}

        GameObject enemyHealthBar = Resources.Load("UIObjects/BossHealthBar") as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        enemyHealthBar = Instantiate(enemyHealthBar);
        enemyHealthBar.transform.SetParent(canvas.transform, false);
        enemyHealthBar.GetComponentInChildren<EnemyHealthBar>().InitEnemyInfo(this);

        destroyEvent += OnBossDestruction;

	}
	
    // Update is called once per frame
	void Update () {
		if (_paused) {
			return;
		}
		Movement();

        switch(hitPoints) {
        case 50:
            if(patternValSet != hitPoints) { 
                BulletPatternShift(1);
                patternValSet = hitPoints;
            }      
            break;
        default:
            break;
        }
	}

    public void BulletPatternShift(int patternNum) {
        //Turn off the routines for the current pattern
        switch(currentPattern) {
        case 0:
            StopCoroutine(firePattern1);
            break;
        case 1:
            StopCoroutine(streamShieldableBullets);
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
        case 1:
            streamShieldableBullets = StreamShieldableBullets();
            StartCoroutine(streamShieldableBullets);
            break;
        default:
            break;

        }
        patternValSet = hitPoints;
    }

    IEnumerator MoveIntoPosition() {
        SetInvuln(true);
        StartNewMovement(new Vector2(6f, 0f), 1.0f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
        SetInvuln(false);
        yield return null;
    }

    IEnumerator FirePattern1() {
        SetInvuln(true);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
        SetInvuln(false);
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

    IEnumerator StreamShieldableBullets() {
        SetInvuln(true);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.7f));
        SetInvuln(false);

        while(true) {
            Shoot(new Vector2(-2.0f, 0.0f), new Vector2(0f, -1.5f), true);
            Shoot(new Vector2(-2.2f, 0.1f), new Vector2(0f, -1.4f), true);
            Shoot(new Vector2(-2.4f, 0.2f), new Vector2(0f, -1.3f), true);
            Shoot(new Vector2(-2.6f, 0.3f), new Vector2(0f, -1.3f), true);
            Shoot(new Vector2(-2.9f, 0.4f), new Vector2(0f, -1.3f), true);
            Shoot(new Vector2(-3.2f, 0.5f), new Vector2(0f, -1.2f), true);
            Shoot(new Vector2(-3.5f, 0.6f), new Vector2(0f, -1.0f), true);
            Shoot(new Vector2(-4.0f, 0.7f), new Vector2(0f, -0.8f), true);

            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(2.0f));

            Shoot(new Vector2(-2.5f, 0.0f), new Vector2(0f, 0f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.15f));
            Shoot(new Vector2(-2.5f, 0.1f), new Vector2(0f, -0.1f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.15f));
            Shoot(new Vector2(-2.5f, -0.1f), new Vector2(0f, -0.2f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.15f));
            Shoot(new Vector2(-2.5f, -0.15f), new Vector2(0f, 0.3f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.15f));
            Shoot(new Vector2(-2.5f, 0.2f), new Vector2(0f, -0.5f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.15f));
            Shoot(new Vector2(-2.5f, -0.13f), new Vector2(0f, 0.2f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.15f));
            Shoot(new Vector2(-2.5f, 0.0f), new Vector2(0f, -0.1f), true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.15f));
            Shoot(new Vector2(-2.5f, 0.0f), new Vector2(0f, 0f), true);

            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(2.0f));

            Shoot(new Vector2(-2.0f, 0.0f), new Vector2(0f, 1.5f), true);
            Shoot(new Vector2(-2.2f, -0.1f), new Vector2(0f, 1.4f), true);
            Shoot(new Vector2(-2.4f, -0.2f), new Vector2(0f, 1.3f), true);
            Shoot(new Vector2(-2.6f, -0.3f), new Vector2(0f, 1.3f), true);
            Shoot(new Vector2(-2.9f, -0.4f), new Vector2(0f, 1.3f), true);
            Shoot(new Vector2(-3.2f, -0.5f), new Vector2(0f, 1.2f), true);
            Shoot(new Vector2(-3.5f, -0.6f), new Vector2(0f, 1.0f), true);
            Shoot(new Vector2(-4.0f, -0.7f), new Vector2(0f, 0.8f), true);
            Shoot((gameController.playerPosition - gameObject.transform.position).normalized* 2.5f);

            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(2.0f));
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

    void OnBossDestruction()
    {
        if (levelControllerBehavior != null)
        {
            Debug.Log("Handle level finished");
            levelControllerBehavior.HandleLevelFinished();
        }
        //Then remove this even because there will be no other time to do that.
        destroyEvent -= OnBossDestruction;
    }

}
