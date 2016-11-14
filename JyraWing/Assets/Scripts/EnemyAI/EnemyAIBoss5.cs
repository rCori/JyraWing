﻿using UnityEngine;
using System.Collections;

public class EnemyAIBoss5 : EnemyBehavior
{
    public LevelControllerBehavior levelControllerBehavior;

    private static int BOSS5_HITS = 150;

    private Vector2 downwardShootingAngle;
    private Vector2 upwardShootingAngle;
    private IEnumerator trackingBulletRoutine, coneShootingRoutine, directAtPlayerRoutine, bulletColumnRotuine;

    private float fireWaitTime;
    private float fanningTimer;
    private bool fanningUp;
    private int currentPattern = 0;

    private float patternSwitchTimer = 0.0f;
    private float pattern1Time = 5.5f;
    private float pattern0Time = 7.0f;

    private float directAtPlayerSpeed = 3.0f;
    private float columnBulletWidth = 2.5f;

    void Start()
    {
        EnemyDefaults();
        SetEnemyHealth(BOSS5_HITS);
        downwardShootingAngle = new Vector2(-2.5f, -1.2f);
        upwardShootingAngle = new Vector2(-2.5f, 1.2f);
        trackingBulletRoutine = TrackingBulletRoutine();
        coneShootingRoutine = ConeShootingRoutine();
        directAtPlayerRoutine = DirectAtPlayer();
        bulletColumnRotuine = BulletColumn();
        BulletPatternShift(0);
        HasAnimations animationSettings;
		animationSettings = HasAnimations.Destroy;
		SetAnimations (animationSettings);
        AudioClip explosionClip = Resources.Load("Audio/SFX/bossExplosion") as AudioClip;
        SetExplosionSfx(explosionClip);
        fireWaitTime = 1.0f;
        fanningTimer = -1.0f;
        fanningUp = true;
        StartCoroutine(MoveIntoPosition());

        for (int i = 0; i < 12; i++) {
			GivePointObject (3, i*0.1f);
		}
        for (int i = 0; i < 8; i++) {
			GivePointObject (2, i*0.3f);
		}
        for (int i = 0; i < 8; i++) {
			GivePointObject (1, i*0.5f);
		}
    }
	
	// Update is called once per frame
	void Update () {
        if (_paused) return;

        Movement();

        patternSwitchTimer += Time.deltaTime;
        switch(currentPattern) {
        case 0:
            Pattern0Fanning(Time.deltaTime);
            if(patternSwitchTimer>pattern0Time) {
                patternSwitchTimer = 0.0f;
                BulletPatternShift(1);
            }
            break;
        case 1:
            Pattern1Adjustment();
            if(patternSwitchTimer>pattern1Time) {
                patternSwitchTimer = 0.0f;
                BulletPatternShift(0);
            }
            break;
        default:
            break;
        }

       

	}

    IEnumerator TrackingBulletRoutine()
    {
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        while (true)
        {
            Shoot((gameController.playerPosition-transform.position).normalized * 3.0f, false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(fireWaitTime));
            Shoot((gameController.playerPosition - transform.position).normalized * 3.0f, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(fireWaitTime));
        }
    }

    IEnumerator ConeShootingRoutine()
    {
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        while (true)
        {
            Shoot(upwardShootingAngle);
            Shoot(downwardShootingAngle);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.25f));
        }
    }

    IEnumerator MoveIntoPosition() {
        SetInvuln(true);
        StartNewMovement(new Vector2(5.5f, 0f), 1.0f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        SetInvuln(false);
        yield return null;
    }

    IEnumerator DirectAtPlayer() {
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        while (true)
        {
            Shoot((gameController.playerPosition-transform.position).normalized * directAtPlayerSpeed, false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        }
    }

    IEnumerator BulletColumn() {
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));

        Vector2 speed = new Vector2(-4.0f, 0f);
        while (true)
        {
            Shoot(speed, new Vector2(0f, columnBulletWidth));
            Shoot(speed, new Vector2(0f, -columnBulletWidth));
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.25f));
        }
    }

    void OnDestroy()
    {
        if (levelControllerBehavior != null)
        {
            levelControllerBehavior.HandleLevelFinished();
        }
    }

    public void BulletPatternShift(int patternNum) {
        //Turn off the routines for the current pattern
        switch(currentPattern) {
        case 0:
            StopCoroutine(trackingBulletRoutine);
            StopCoroutine(coneShootingRoutine);
            break;
        case 1:
            StopCoroutine(bulletColumnRotuine);
            StopCoroutine(directAtPlayerRoutine);
            break;
        default:
            break;

        }
        currentPattern = patternNum;
        //Turn on the coroutines for the new pattern
        switch(currentPattern) {
        case 0:
            trackingBulletRoutine = TrackingBulletRoutine();
            coneShootingRoutine = ConeShootingRoutine();
            StartCoroutine(trackingBulletRoutine);
            StartCoroutine(coneShootingRoutine);
            break;
        case 1:
            bulletColumnRotuine = BulletColumn();
            directAtPlayerRoutine = DirectAtPlayer();
            StartCoroutine(bulletColumnRotuine);
            StartCoroutine(directAtPlayerRoutine);
            break;
        default:
            break;

        }
    }

    private void Pattern0Fanning(float deltaTime) {
        if(fanningUp) {
            fanningTimer += Time.deltaTime * 0.3f;
        } else {
            fanningTimer -= Time.deltaTime * 0.3f;
        }


        if(fanningTimer > 0.8f) {
            fanningUp = false;
        } else if(fanningTimer < -0.8f) {
            fanningUp = true;
        }


        if (hitPoints < (51)) {
            downwardShootingAngle = new Vector2(-2.5f, -0.6f + fanningTimer);
            upwardShootingAngle = new Vector2(-2.5f, 0.6f + fanningTimer);
            fireWaitTime = 0.25f;
        } else if(hitPoints < (101)) {
            downwardShootingAngle = new Vector2(-2.5f, -0.9f + fanningTimer);
            upwardShootingAngle = new Vector2(-2.5f, 0.9f + fanningTimer);
            fireWaitTime = 0.5f;
        } else {
            downwardShootingAngle = new Vector2(-2.5f, -1.2f + fanningTimer);
            upwardShootingAngle = new Vector2(-2.5f, 1.2f + fanningTimer);
            fireWaitTime = 0.5f;
        }
    }

    private void Pattern1Adjustment() {
        if(hitPoints <  51) {
            columnBulletWidth = 1.7f;
            directAtPlayerSpeed = 8.0f;
        } else if(hitPoints < 101) {
            columnBulletWidth = 2.0f;
            directAtPlayerSpeed = 7.5f;
        } else {
            columnBulletWidth = 2.5f;
            directAtPlayerSpeed = 7.0f;
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
}
