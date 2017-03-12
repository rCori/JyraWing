using UnityEngine;
using System.Collections;

public class EnemyAIBoss3 : EnemyBehavior {

	public LevelControllerBehavior levelControllerBehavior;

    //private static int BOSS3_HITS = 25;
	private static int BOSS3_HITS = 250;

	private Vector2[] bulletDir;
	private float bulletSpeed;

	private int moveState;

	private IEnumerator introShootRoutine, middleShootRoutine, endShootRoutine, introMoveRoutine, middleMoveRoutine, endMoveRoutine;
	private enum ShootState {intro, mid, end};
	private ShootState currentShootState;

    private float patternSwitchTimer = 0.0f;
    private float pattern1Time = 5.5f;
    private float pattern0Time = 7.0f;

	// Use this for initialization
	void Awake () {
		EnemyDefaults ();
		SetEnemyHealth (BOSS3_HITS);
		HasAnimations animationSettings;
		animationSettings = HasAnimations.Destroy;
		SetAnimations (animationSettings);

		AudioClip explosionClip = Resources.Load ("Audio/SFX/bossExplosion") as AudioClip;
		SetExplosionSfx (explosionClip);

		bulletSpeed = 2.0f;
		bulletDir = new Vector2[14];
		initBulletDirections ();

		moveState = 0;
		introShootRoutine = IntroShootRoutine ();
		middleShootRoutine = MiddleShootRoutine ();
		endShootRoutine = EndShootRoutine ();
        introMoveRoutine = IntroMovementRoutine();
        middleMoveRoutine = MiddleMovementRoutine();
        endMoveRoutine = EndMovementRoutine();

        currentShootState = ShootState.intro;
        PatternShift(ShootState.intro);

        for (int i = 0; i < 7; i++) {
			GivePointObject (3, i*0.1f);
		}
        for (int i = 0; i < 5; i++) {
			GivePointObject (2, i*0.5f);
		}

        GameObject enemyHealthBar = Resources.Load("UIObjects/BossHealthBar") as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        enemyHealthBar = Instantiate(enemyHealthBar);
        enemyHealthBar.transform.SetParent(canvas.transform, false);
        enemyHealthBar.GetComponentInChildren<EnemyHealthBar>().InitEnemyInfo(this);

        destroyEvent += OnBossDestruction;

	}

	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		Movement ();

		if (hitPoints == 166 && currentShootState == ShootState.intro) {
            PatternShift(ShootState.mid);
		} else if (hitPoints == 83 && currentShootState == ShootState.mid) {
			PatternShift(ShootState.end);
		}
	}

    void OnTriggerEnter2D(Collider2D other) {
		DefaultTrigger (other);
        if(hitPoints == 0) {
            //Immediatly stop the current fire pattern
            switch(currentShootState) {
                case ShootState.intro:
                    StopCoroutine (introShootRoutine);
                    break;
                case ShootState.mid:
                    StopCoroutine (middleShootRoutine);
                    break;
                case ShootState.end:
                    StopCoroutine (endShootRoutine);
                    break;
                default:
                    break;
            }
        }
	}

	private void initBulletDirections() {
		bulletDir[0] = new Vector2 (-1f, 1.6f);
		bulletDir[0].Normalize ();
		bulletDir[0] *= bulletSpeed;

		bulletDir[1] = new Vector2 (-1f, 1.3f);
		bulletDir[1].Normalize();
		bulletDir[1] *= bulletSpeed;

		bulletDir[2] = new Vector2 (-1f, 1.0f);
		bulletDir[2].Normalize();
		bulletDir[2] *= bulletSpeed;

		bulletDir[3] = new Vector2 (-1f, 0.7f);
		bulletDir[3].Normalize();
		bulletDir[3] *= bulletSpeed;

		bulletDir[4] = new Vector2 (-1f, 0.4f);
		bulletDir[4].Normalize();
		bulletDir[4] *= bulletSpeed;

        bulletDir[5] = new Vector2 (-1f, 0.2f);
		bulletDir[5].Normalize();
		bulletDir[5] *= bulletSpeed;

		bulletDir[6] = new Vector2 (-1f, 0.0f);
		bulletDir[6].Normalize();
		bulletDir[6] *= bulletSpeed;

        bulletDir[7] = new Vector2 (-1f, -0.2f);
		bulletDir[7].Normalize();
		bulletDir[7] *= bulletSpeed;

		bulletDir[8] = new Vector2 (-1f, -0.4f);
		bulletDir[8].Normalize();
		bulletDir[8] *= bulletSpeed;

		bulletDir[9] = new Vector2 (-1f, -0.7f);
		bulletDir[9].Normalize();
		bulletDir[9] *= bulletSpeed;

		bulletDir[10] = new Vector2 (-1f, -1.0f);
		bulletDir[10].Normalize();
		bulletDir[10] *= bulletSpeed;

		bulletDir[11] = new Vector2 (-1f, -1.0f);
		bulletDir[11].Normalize();
		bulletDir[11] *= bulletSpeed;

		bulletDir[12] = new Vector2 (-1f, -1.3f);
		bulletDir[12].Normalize();
		bulletDir[12] *= bulletSpeed;

		bulletDir[13] = new Vector2 (-1f, -1.6f);
		bulletDir[13].Normalize();
		bulletDir[13] *= bulletSpeed;

	}

	IEnumerator IntroShootRoutine() {
		while (true) {
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], true);
			Shoot (bulletDir[13], true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
		}
	}

	IEnumerator MiddleShootRoutine() {
		while(true) {
            Vector2 bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[1] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
			Shoot (bulletDir[10] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, false);
			Shoot (bulletDir[1], bulletOrigin, false);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[2] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, false);
			Shoot (bulletDir[2], bulletOrigin, false);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[6] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, false);
			Shoot (bulletDir[3], bulletOrigin, false);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[8] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
			Shoot (bulletDir[11] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, false);
			Shoot (bulletDir[4], bulletOrigin, false);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[3] * 3.0f, false);
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, false);
			Shoot (bulletDir[5], bulletOrigin, false);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[0] * 3.0f, false);
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[11] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, false);
			Shoot (bulletDir[6], bulletOrigin, false);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[1] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, false);
			Shoot (bulletDir[7], bulletOrigin, false);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[8] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
			Shoot (bulletDir[10] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, false);
			Shoot (bulletDir[8], bulletOrigin, false);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[2] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[6] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, false);
			Shoot (bulletDir[9], bulletOrigin, false);
			Shoot (bulletDir[10], bulletOrigin, true);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[2] * 3.0f, false);
			Shoot (bulletDir[3] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, false);
			Shoot (bulletDir[10], bulletOrigin, false);
			Shoot (bulletDir[11], bulletOrigin, true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[6] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, true);
			Shoot (bulletDir[3], bulletOrigin, true);
			Shoot (bulletDir[4], bulletOrigin, true);
			Shoot (bulletDir[5], bulletOrigin, true);
			Shoot (bulletDir[6], bulletOrigin, true);
			Shoot (bulletDir[7], bulletOrigin, true);
			Shoot (bulletDir[8], bulletOrigin, true);
			Shoot (bulletDir[9], bulletOrigin, true);
			Shoot (bulletDir[10], bulletOrigin, false);
			Shoot (bulletDir[11], bulletOrigin, false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
		}
	}

	IEnumerator EndShootRoutine() {
        Vector2 bottom, top, middle;
		while(true) {
            Vector2 bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], bulletOrigin, true);
			Shoot (bulletDir[1], bulletOrigin, true);
			Shoot (bulletDir[2], bulletOrigin, false);
			Shoot (bulletDir[3], bulletOrigin, false);
			Shoot (bulletDir[4], bulletOrigin, false);
			Shoot (bulletDir[5], bulletOrigin, false);
			Shoot (bulletDir[6], bulletOrigin, false);
			Shoot (bulletDir[7], bulletOrigin, false);
			Shoot (bulletDir[8], bulletOrigin, false);
			Shoot (bulletDir[9], bulletOrigin, false);
			Shoot (bulletDir[10], bulletOrigin, false);
			Shoot (bulletDir[11], bulletOrigin, false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], true);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], true);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], true);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], true);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], true);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], true);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], true);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], true);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], false);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
            bulletOrigin = new Vector2(0f, Random.Range(-1.5f, 1.5f));
            middle = (gameController.playerPosition - gameObject.transform.position).normalized;
            bottom = new Vector2(middle.y, -middle.x).normalized;
            top = new Vector2(-middle.y, middle.x).normalized;
            Shoot(middle.normalized* 3.5f, true);
            Shoot(middle.normalized* 3.5f, top.normalized*1.2f, true);
            Shoot(middle.normalized* 3.5f, bottom.normalized*1.2f, true);
			Shoot (bulletDir[0], false);
			Shoot (bulletDir[1], false);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], true);
			Shoot (bulletDir[11], true);
            Shoot (bulletDir[12], bulletOrigin, true);
			Shoot (bulletDir[13], bulletOrigin, true);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
		}
	}

    IEnumerator IntroMovementRoutine() {
        while(true) {
            StartNewMovement (new Vector2 (6.0f, 0.0f), 1.0f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
            StartNewVelocity (new Vector2 (0.0f, -2.0f), 0.5f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            StartNewVelocity (new Vector2 (0.0f, 2.0f), 0.5f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            StartNewVelocity (new Vector2 (0.0f, -2.0f), 1.0f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        }
    }

    IEnumerator MiddleMovementRoutine() {
        while(true) {
            StartNewMovement (new Vector2 (6.0f, 0.0f), 1.0f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
            StartNewVelocity (new Vector2 (0.0f, 1.2f), 0.75f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.75f));
            StartArcVelocity (new Vector2 (-0.6f, -1.2f), new Vector2 (0.0f, -1.2f), 0.75f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.75f));
            StartArcVelocity (new Vector2 (0.0f, -1.2f), new Vector2 (0.6f, -1.2f), 0.75f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.75f));
            StartArcVelocity (new Vector2 (-0.6f, 1.2f), new Vector2 (0.0f, 1.2f), 0.75f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.75f));
            StartArcVelocity (new Vector2 (0.0f, 1.2f), new Vector2 (0.6f, 1.2f), 0.75f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.75f));
        }
    }

    IEnumerator EndMovementRoutine() {
        while(true) {
            StartNewMovement (new Vector2 (6.0f, 0.0f), 1.0f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
            StartNewVelocity (new Vector2 (0.0f, -2.0f), 0.5f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(0.5f));
            StartNewVelocity (new Vector2 (0.0f, 2.0f), 1.0f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
            StartNewVelocity (new Vector2 (0.0f, -2.0f), 1.0f);
            yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.0f));
        }
    }

	private void moveRoutine() {
		if (GetIsTimeUp ()) {
			switch (currentShootState) {
			case ShootState.intro:
				switch (moveState) {
				case 0:
					StartNewMovement (new Vector2 (6.0f, -0.75f), 0.75f);
					break;
				case 1:
					StartNewVelocity (new Vector2 (0f, 0.5f), 1.5f);
					break;
				case 2:
					StartNewVelocity (new Vector2 (0f, -0.5f), 1.5f);
					break;
				}
				moveState++;
				if (moveState > 2) {
					moveState = 1;
				}
				break;
			case ShootState.mid:
				switch (moveState) {
				case 0:
					StartNewMovement (new Vector2 (6.0f, 0.0f), 1.0f);
					break;
				case 1:
					StartNewVelocity (new Vector2 (0.0f, 1.2f), 0.75f);
					break;
				case 2:
					StartArcVelocity (new Vector2 (-0.6f, -1.2f), new Vector2 (0.0f, -1.2f), 0.75f);
					break;
				case 3:
					StartArcVelocity (new Vector2 (0.0f, -1.2f), new Vector2 (0.6f, -1.2f), 0.75f);
					break;
				case 4:
					StartArcVelocity (new Vector2 (-0.6f, 1.2f), new Vector2 (0.0f, 1.2f), 0.75f);
					break;
				case 5:
					StartArcVelocity (new Vector2 (0.0f, 1.2f), new Vector2 (0.6f, 1.2f), 0.75f);
					break;
				}
				moveState++;
				if (moveState > 5) {
					moveState = 2;
				}
				break;
			case ShootState.end:
				switch (moveState) {
				case 0:
					StartNewMovement (new Vector2 (6.0f, 0.0f), 1.0f);
					break;
				case 1:
					StartNewVelocity (new Vector2 (0.0f, -2.0f), 0.5f);
					break;
				case 2:
					StartNewVelocity (new Vector2 (0.0f, 2.0f), 1.0f);
					break;
				case 3:
					StartNewVelocity (new Vector2 (0.0f, -2.0f), 1.0f);
					break;
				}
				moveState++;
				if (moveState > 3) {
					moveState = 2;
				}
				break;
			}
		}
	}
		

	void OnBossDestruction(){
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
		if (levelControllerBehavior != null) {
			levelControllerBehavior.HandleLevelFinished ();
		}
        //Then remove this even because there will be no other time to do that.
        destroyEvent -= OnBossDestruction;
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
			if(_paused)
			{
				storedVel = rigidybody2D.velocity;
				rigidybody2D.velocity = new Vector2 (0.0f, 0.0f);
				animator.speed = 0f;
			}
			else{
				rigidybody2D.velocity = storedVel;
				animator.speed = 1f;
			}
		}
	}
    private void PatternShift(ShootState state) {
        switch(currentShootState) {
        case ShootState.intro:
            StopCoroutine(introShootRoutine);
            StopCoroutine(introMoveRoutine);
            break;
        case ShootState.mid:
            StopCoroutine(middleShootRoutine);
            StopCoroutine(middleMoveRoutine);
            break;
        case ShootState.end:
            StopCoroutine(endShootRoutine);
            StopCoroutine(endMoveRoutine);
            break;
        }
        currentShootState = state;
        switch(state) {
        case ShootState.intro:
            introShootRoutine = IntroShootRoutine();
            introMoveRoutine = IntroMovementRoutine();
            StartCoroutine(introShootRoutine);
            StartCoroutine(introMoveRoutine);
            break;
        case ShootState.mid:
            middleShootRoutine = MiddleShootRoutine();
            middleMoveRoutine = MiddleMovementRoutine();
            StartCoroutine(middleShootRoutine);
            StartCoroutine(middleMoveRoutine);
            break;
        case ShootState.end:
            endShootRoutine = EndShootRoutine();
            endMoveRoutine = EndMovementRoutine();
            StartCoroutine(endShootRoutine);
            StartCoroutine(endMoveRoutine);
            break;
        }
    }
}


