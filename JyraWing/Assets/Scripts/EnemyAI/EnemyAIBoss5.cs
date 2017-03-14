using UnityEngine;
using System.Collections;

public class EnemyAIBoss5 : EnemyBehavior
{
    public LevelControllerBehavior levelControllerBehavior;

    private static int BOSS5_HITS = 280;
    //private static int BOSS5_HITS = 10;

    private Vector2 downwardShootingAngle;
    private Vector2 upwardShootingAngle;
    private IEnumerator threeWayShooting, directAtPlayerRoutine, bulletColumnRotuine,scatteredProlongedStream, diamondPatternStream;

    private float fireWaitTime;
    private float fanningTimer;
    private bool fanningUp;
    private int currentPattern = 0;

    private float patternSwitchTimer = 0.0f;
    private float pattern1Time = 5.5f;
    private float pattern0Time = 7.0f;

    private float directAtPlayerSpeed = 3.0f;
    private float columnBulletWidth = 2.5f;

    private int patternValSet;

    void Start()
    {
        EnemyDefaults();
        SetEnemyHealth(BOSS5_HITS);
        downwardShootingAngle = new Vector2(-2.5f, -1.2f);
        upwardShootingAngle = new Vector2(-2.5f, 1.2f);
        threeWayShooting = ThreeWayShooting();
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

        GameObject enemyHealthBar = Resources.Load("UIObjects/BossHealthBar") as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        enemyHealthBar = Instantiate(enemyHealthBar);
        enemyHealthBar.transform.SetParent(canvas.transform, false);
        enemyHealthBar.GetComponentInChildren<EnemyHealthBar>().InitEnemyInfo(this);

        destroyEvent += OnBossDestruction;
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
            StopCoroutine(threeWayShooting);
            break;
        case 1:
            StopCoroutine(scatteredProlongedStream);
            break;
        case 2:
            StopCoroutine(diamondPatternStream);
            break;
        default:
            break;

        }
        currentPattern = patternNum;
        //Turn on the coroutines for the new pattern
        switch(currentPattern) {
        case 0:
            threeWayShooting = ThreeWayShooting();
            StartCoroutine(threeWayShooting);
            break;
        case 1:
            scatteredProlongedStream = ScatteredProlongedStream();
            StartCoroutine(scatteredProlongedStream);
            break;
        case 2:
            diamondPatternStream = DiamondPattern();
            StartCoroutine(diamondPatternStream);
            break;
        default:
            break;

        }
    }

    void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
        if(hitPoints == 0) {
            //Immediatly stop the current fire pattern
            switch(currentPattern) {
                case 0:
                    StopCoroutine(threeWayShooting);
                    break;
                case 1:
                    StopCoroutine(scatteredProlongedStream);
                    break;
                case 2:
                    StopCoroutine(diamondPatternStream);
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator ThreeWayShooting() {
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        float bulletSpeed = 3.5f;
        Vector2 direction = new Vector2(0f, 0f);
        Vector2 bottom = new Vector2(0f, 0f);
        Vector2 top = new Vector2(0f, 0f);
        // while(true) {
            direction = new Vector2(-4f, 1.5f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, 1.0f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, 0.5f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, 0.0f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, -0.5f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, -1.0f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, -1.5f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, -1.0f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, -0.5f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, 0.0f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, 0.5f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, 1.0f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            direction = new Vector2(-4f, 1.5f);
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            Shoot(direction.normalized * bulletSpeed, false);
            Shoot(direction.normalized * bulletSpeed, top, true);
            Shoot(direction.normalized * bulletSpeed, bottom, true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
        //}
        BulletPatternShift(1);
    }

    IEnumerator MoveIntoPosition() {
        SetInvuln(true);
        StartNewMovement(new Vector2(5.5f, -0.5f), 1.0f);
        yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        SetInvuln(false);
        yield return null;
    }

    /*
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
    */

    IEnumerator ScatteredProlongedStream() {
        float bulletSpeed = 5.0f;
        Vector2 direction = new Vector2(0f, 0f);
        Vector2 bottom,top = new Vector2(0f, 0f);
        for(int j = 0; j<6;j++) {
            switch(j) {
            case 0:
                direction = new Vector2(-2.5f, 0.7f).normalized;
                break;
            case 1:
                direction = new Vector2(-2.7f, 0.3f).normalized;
                break;
            case 2:
                direction = new Vector2(-2.0f, -0.6f).normalized;
                break;
            case 3:
                direction = new Vector2(-3.0f, 0.1f).normalized;
                break;
            case 4:
                direction = new Vector2(-1.5f, 0.5f).normalized;
                break;
            case 5:
                direction = new Vector2(-2.5f, -0.5f).normalized;
                break;
            }
            bottom = new Vector2(direction.y, -direction.x).normalized;
            top = new Vector2(-direction.y, direction.x).normalized;
            for(int i = 0; i < 5; i++) {
                if(i%3 == 0) {
                    Shoot(direction * bulletSpeed, false);
                    Shoot(direction * bulletSpeed, top*0.5f, false);
                    Shoot(direction * bulletSpeed, top*0.9f, false);
                    Shoot(direction * bulletSpeed, top*1.3f, false);
                    Shoot(direction * bulletSpeed, bottom*0.5f, false);
                    Shoot(direction * bulletSpeed, bottom*0.9f, false);
                    Shoot(direction * bulletSpeed, bottom*1.3f, false);
                } else {
                    Shoot(direction * bulletSpeed, true);
                    Shoot(direction * bulletSpeed, top*0.5f, true);
                    Shoot(direction * bulletSpeed, top*0.9f, true);
                    Shoot(direction * bulletSpeed, top*1.3f, true);
                    Shoot(direction * bulletSpeed, bottom*0.5f, true);
                    Shoot(direction * bulletSpeed, bottom*0.9f, true);
                    Shoot(direction * bulletSpeed, bottom*1.3f, true);
                }
                yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.1f));
            }
        }
        BulletPatternShift(2);
    }

    IEnumerator DiamondPattern() {
        float bulletSpeed = 3.5f;
        float timeBetween = 0.1f;
        Vector2 direction = new Vector2(-1f, 0f);
        bool shielding = true;
        for(int i = 0; i < 4; i++) {
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed, !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.3f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.3f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.5f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.5f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.7f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.7f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.9f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.9f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.1f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.1f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.3f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.3f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.5f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.5f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.7f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.7f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.9f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.9f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-2.1f), !shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,2.1f), shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.9f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.9f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.7f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.7f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.5f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.5f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.3f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.3f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.1f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,1.1f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.9f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.9f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.7f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.7f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.5f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.5f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.3f), shielding);
            Shoot(direction * bulletSpeed, new Vector2(0f,0.3f), !shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed, shielding);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            shielding = !shielding;


            Shoot(direction * bulletSpeed,new Vector2(0f,-1.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.1f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.9f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.1f), true);

            Shoot(direction * bulletSpeed,new Vector2(0f, 1.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 1.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 1.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 1.1f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.9f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.1f), true);

            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween * 1.3f));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween * 1.3f));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween * 1.3f));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween * 1.3f));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween * 1.3f));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));
            Shoot(direction * bulletSpeed,new Vector2(0f, 2.2f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.0f), false);
            Shoot(direction * bulletSpeed,new Vector2(0f, -2.2f), false);
            

            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(timeBetween));

            Shoot(direction * bulletSpeed,new Vector2(0f,-1.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-1.1f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.9f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f,-0.1f), true);

            Shoot(direction * bulletSpeed,new Vector2(0f, 1.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 1.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 1.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 1.1f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.9f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.7f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.5f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.3f), true);
            Shoot(direction * bulletSpeed,new Vector2(0f, 0.1f), true);

        }
        BulletPatternShift(0);
        yield return null;
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

    void OnBossDestruction()
    {
        if (levelControllerBehavior != null)
        {
            levelControllerBehavior.HandleLevelFinished();
        }
        //Then remove this even because there will be no other time to do that.
        destroyEvent -= OnBossDestruction;
    }
}
