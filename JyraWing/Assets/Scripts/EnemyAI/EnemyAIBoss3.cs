using UnityEngine;
using System.Collections;

public class EnemyAIBoss3 : EnemyBehavior
{
    public LevelControllerBehavior levelControllerBehavior;

    private static int BOSS3_HITS = 150;

    private Vector2 downwardShootingAngle;
    private Vector2 upwardShootingAngle;
    private IEnumerator trackingBulletRoutine, coneShootingRoutine, movementRoutine;

    private float fireWaitTime;

    void Start()
    {
        EnemyDefaults();
        SetEnemyHealth(BOSS3_HITS);
        downwardShootingAngle = new Vector2(-1.0f, -1.8f);
        upwardShootingAngle = new Vector2(-1.0f, 1.8f);
        trackingBulletRoutine = TrackingBulletRoutine();
        coneShootingRoutine = ConeShootingRoutine();
        movementRoutine = MovementRoutine();
        StartCoroutine(movementRoutine);
        AudioClip explosionClip = Resources.Load("Audio/SFX/bossExplosion") as AudioClip;
        SetExplosionSfx(explosionClip);
        fireWaitTime = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
	    if(hitPoints == (100)) {
            downwardShootingAngle = new Vector2(-1.0f, -1.2f);
            upwardShootingAngle = new Vector2(-1.0f, 1.2f);
            fireWaitTime = 0.5f;
        } else if(hitPoints == (50)) {
            downwardShootingAngle = new Vector2(-1.0f, -0.8f);
            upwardShootingAngle = new Vector2(-1.0f, 0.8f);
            fireWaitTime = 0.25f;
        }
	}

    IEnumerator TrackingBulletRoutine()
    {
        while (true)
        {
            Shoot((gameController.playerPosition-transform.position).normalized * 3.0f, false);
            yield return new WaitForSeconds(fireWaitTime);
            Shoot((gameController.playerPosition - transform.position).normalized * 3.0f, true);
            yield return new WaitForSeconds(fireWaitTime);
        }
    }

    IEnumerator ConeShootingRoutine()
    {
        while (true)
        {
            Shoot(upwardShootingAngle);
            Shoot(downwardShootingAngle);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator MovementRoutine()
    {
        StartNewMovement(new Vector3(5.0f, 0.0f, 0f), 1.0f);
        yield return new WaitForSeconds(2.5f);

        while (true)
        {
            StartNewMovement(new Vector3(5.0f, -1.0f, 0f), 1.0f);
            StopCoroutine(coneShootingRoutine);
            StopCoroutine(trackingBulletRoutine);
            yield return new WaitForSeconds(2.5f);

            StartStandStill(1.5f);
            StartCoroutine(coneShootingRoutine);
            StartCoroutine(trackingBulletRoutine);
            yield return new WaitForSeconds(1.5f);

            StartNewMovement(new Vector3(5.0f, 1.0f, 0f), 1.0f);
            StopCoroutine(coneShootingRoutine);
            StopCoroutine(trackingBulletRoutine);
            yield return new WaitForSeconds(2.5f);

            StartStandStill(1.5f);
            StartCoroutine(coneShootingRoutine);
            StartCoroutine(trackingBulletRoutine);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void OnDestroy()
    {
        if (levelControllerBehavior != null)
        {
            levelControllerBehavior.HandleLevelFinished();
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
                StopCoroutine(trackingBulletRoutine);
                StopCoroutine(coneShootingRoutine);
                StopCoroutine(movementRoutine);
            }
            else
            {
                rigidybody2D.velocity = storedVel;
                animator.speed = 1f;
                StartCoroutine(trackingBulletRoutine);
                StartCoroutine(coneShootingRoutine);
                StartCoroutine(movementRoutine);
            }
        }
    }
}
