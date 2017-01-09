using UnityEngine;
using System.Collections;

public class EnemyAIBoss3 : EnemyBehavior {

	public LevelControllerBehavior levelControllerBehavior;

	private static int BOSS2_HITS = 90;

	private Vector2[] bulletDir;
	private float bulletSpeed;

	private int moveState;

	private IEnumerator introShootRoutine, middleShootRoutine, endShootRoutine;
	private enum ShootState {intro, mid, end};
	private ShootState shootState;

    private float patternSwitchTimer = 0.0f;
    private float pattern1Time = 5.5f;
    private float pattern0Time = 7.0f;

	// Use this for initialization
	void Awake () {
		EnemyDefaults ();
		SetEnemyHealth (BOSS2_HITS);
		HasAnimations animationSettings;
		animationSettings = HasAnimations.Destroy;
		SetAnimations (animationSettings);

		AudioClip explosionClip = Resources.Load ("Audio/SFX/bossExplosion") as AudioClip;
		SetExplosionSfx (explosionClip);

		bulletSpeed = 2.0f;
		bulletDir = new Vector2[12];
		initBulletDirections ();

		moveState = 0;
		introShootRoutine = IntroShootRoutine ();
		StartCoroutine (introShootRoutine);
		middleShootRoutine = MiddleShootRoutine ();
		endShootRoutine = EndShootRoutine ();
		shootState = ShootState.intro;

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
		moveRoutine ();
		Movement ();

		if (hitPoints == 60 && shootState == ShootState.intro) {
			StopCoroutine (introShootRoutine);
			StartCoroutine (middleShootRoutine);
			shootState = ShootState.mid;
			moveState = 0;
		} else if (hitPoints == 30 && shootState == ShootState.mid) {
			StopCoroutine (middleShootRoutine);
			StartCoroutine (endShootRoutine);
			shootState = ShootState.end;
			moveState = 0;
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

		bulletDir[5] = new Vector2 (-1f, 0.0f);
		bulletDir[5].Normalize();
		bulletDir[5] *= bulletSpeed;

		bulletDir[6] = new Vector2 (-1f, -0.4f);
		bulletDir[6].Normalize();
		bulletDir[6] *= bulletSpeed;

		bulletDir[7] = new Vector2 (-1f, -0.7f);
		bulletDir[7].Normalize();
		bulletDir[7] *= bulletSpeed;

		bulletDir[8] = new Vector2 (-1f, -1.0f);
		bulletDir[8].Normalize();
		bulletDir[8] *= bulletSpeed;

		bulletDir[9] = new Vector2 (-1f, -1.0f);
		bulletDir[9].Normalize();
		bulletDir[9] *= bulletSpeed;

		bulletDir[10] = new Vector2 (-1f, -1.3f);
		bulletDir[10].Normalize();
		bulletDir[10] *= bulletSpeed;

		bulletDir[11] = new Vector2 (-1f, -1.6f);
		bulletDir[11].Normalize();
		bulletDir[11] *= bulletSpeed;

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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
		}
	}

	IEnumerator MiddleShootRoutine() {
		while(true) {
			Shoot (bulletDir[1] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
			Shoot (bulletDir[10] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[2] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[6] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[8] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
			Shoot (bulletDir[11] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[3] * 3.0f, false);
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[0] * 3.0f, false);
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[11] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[1] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[8] * 3.0f, false);
			Shoot (bulletDir[9] * 3.0f, false);
			Shoot (bulletDir[10] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[2] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
			Shoot (bulletDir[6] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[2] * 3.0f, false);
			Shoot (bulletDir[3] * 3.0f, false);
			Shoot (bulletDir[4] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
			Shoot (bulletDir[5] * 3.0f, false);
			Shoot (bulletDir[6] * 3.0f, false);
			Shoot (bulletDir[7] * 3.0f, false);
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
		}
	}

	IEnumerator EndShootRoutine() {
		while(true) {
			Shoot (bulletDir[0], true);
			Shoot (bulletDir[1], true);
			Shoot (bulletDir[2], false);
			Shoot (bulletDir[3], false);
			Shoot (bulletDir[4], false);
			Shoot (bulletDir[5], false);
			Shoot (bulletDir[6], false);
			Shoot (bulletDir[7], false);
			Shoot (bulletDir[8], false);
			Shoot (bulletDir[9], false);
			Shoot (bulletDir[10], false);
			Shoot (bulletDir[11], false);
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
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
			yield return StartCoroutine(PauseControllerBehavior.WaitForPauseSeconds(1.5f));
		}
	}

	private void moveRoutine() {
		if (GetIsTimeUp ()) {
			switch (shootState) {
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

}
