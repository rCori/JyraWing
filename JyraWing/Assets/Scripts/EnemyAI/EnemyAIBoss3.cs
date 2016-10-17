using UnityEngine;
using System.Collections;

public class EnemyAIBoss3 : EnemyBehavior
{
    public LevelControllerBehavior levelControllerBehavior;

    private static int BOSS3_HITS = 150;

    private Vector2 downwardShootingAngle;
    private Vector2 upwardShootingAngle;
    private IEnumerator trackingBulletRoutine, coneShootingRoutine, directAtPlayerRoutine, bulletColumnRotuine;

    private float fireWaitTime;
    private float fanningTimer;
    private bool fanningUp;
    private int currentPattern = 0;

    void Start()
    {
        EnemyDefaults();
        SetEnemyHealth(BOSS3_HITS);
        downwardShootingAngle = new Vector2(-2.5f, -1.2f);
        upwardShootingAngle = new Vector2(-2.5f, 1.2f);
        trackingBulletRoutine = TrackingBulletRoutine();
        coneShootingRoutine = ConeShootingRoutine();
        directAtPlayerRoutine = DirectAtPlayer();
        bulletColumnRotuine = BulletColumn();
        BulletPatternShift(1);
        AudioClip explosionClip = Resources.Load("Audio/SFX/bossExplosion") as AudioClip;
        SetExplosionSfx(explosionClip);
        fireWaitTime = 1.0f;
        fanningTimer = -1.0f;
        fanningUp = true;
        StartCoroutine(MoveIntoPosition());
    }
	
	// Update is called once per frame
	void Update () {
        if (_paused) return;

        Movement();

        /*
        if(fanningUp) {
            fanningTimer += Time.deltaTime * 0.5f;
        } else {
            fanningTimer -= Time.deltaTime * 0.5f;
        }


        if(fanningTimer > 1.2f) {
            fanningUp = false;
        } else if(fanningTimer < -1.2f) {
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
        */
	}

    IEnumerator TrackingBulletRoutine()
    {
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
        while (true)
        {
            Shoot(upwardShootingAngle);
            Shoot(downwardShootingAngle);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.25f));
        }
    }

    IEnumerator MoveIntoPosition() {
        StartNewMovement(new Vector2(7f, 0f), 0.5f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
        yield return null;
    }

    IEnumerator DirectAtPlayer() {
        while (true)
        {
            Shoot((gameController.playerPosition-transform.position).normalized * 7.0f, false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        }
    }

    IEnumerator BulletColumn() {
        Vector2 speed = new Vector2(-4f, 0f);
        Vector2 topOffset = new Vector2(0f, 2f);
        Vector2 bottomOffset = new Vector2(0f, -2f);
        while (true)
        {
            Shoot(speed, topOffset);
            Shoot(speed, bottomOffset);
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
            StartCoroutine(trackingBulletRoutine);
            StartCoroutine(coneShootingRoutine);
            break;
        case 1:
            StartCoroutine(bulletColumnRotuine);
            StartCoroutine(directAtPlayerRoutine);
            break;
        default:
            break;

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
