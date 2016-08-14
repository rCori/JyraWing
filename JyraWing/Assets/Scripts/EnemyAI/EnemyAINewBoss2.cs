using UnityEngine;
using System.Collections;

public class EnemyAINewBoss2 : EnemyBehavior {

	public LevelControllerBehavior levelControllerBehavior;

	private static int BOSS2_HITS = 30;

	private Vector2 bulletDir1,bulletDir2,bulletDir3,bulletDir4,bulletDir5,bulletDir6,bulletDir7,bulletDir8,bulletDir9;
	private float bulletSpeed;

	private int moveState;

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
		initBulletDirections ();

		moveState = 0;

		StartCoroutine (ShootRoutine());
	}

	void Update () {
		if (isDestroyed || _paused) {
			return;
		}
		moveRoutine ();
		Movement ();
	}

	private void initBulletDirections() {
		bulletDir1 = new Vector2 (-1f, 1.6f);
		bulletDir1.Normalize ();
		bulletDir1 *= bulletSpeed;

		bulletDir2 = new Vector2 (-1f, 1.2f);
		bulletDir2.Normalize();
		bulletDir2 *= bulletSpeed;

		bulletDir3 = new Vector2 (-1f, 0.7f);
		bulletDir3.Normalize();
		bulletDir3 *= bulletSpeed;

		bulletDir4 = new Vector2 (-1f, 0.3f);
		bulletDir4.Normalize();
		bulletDir4 *= bulletSpeed;

		bulletDir5 = new Vector2 (-1f, 0f);
		bulletDir5.Normalize();
		bulletDir5 *= bulletSpeed;

		bulletDir6 = new Vector2 (-1f, -0.3f);
		bulletDir6.Normalize();
		bulletDir6 *= bulletSpeed;

		bulletDir7 = new Vector2 (-1f, -0.7f);
		bulletDir7.Normalize();
		bulletDir7 *= bulletSpeed;

		bulletDir8 = new Vector2 (-1f, -1.2f);
		bulletDir8.Normalize();
		bulletDir8 *= bulletSpeed;

		bulletDir9 = new Vector2 (-1f, -1.6f);
		bulletDir9.Normalize();
		bulletDir9 *= bulletSpeed;

	}

	IEnumerator ShootRoutine() {
		for (int i = 0; i < 10; i++) {
			Shoot (bulletDir1, false);
			Shoot (bulletDir2, false);
			Shoot (bulletDir3, true);
			Shoot (bulletDir4, true);
			Shoot (bulletDir5, true);
			Shoot (bulletDir6, true);
			Shoot (bulletDir7, true);
			Shoot (bulletDir8, true);
			Shoot (bulletDir9, true);
			yield return new WaitForSeconds (1.5f);
			Shoot (bulletDir1, true);
			Shoot (bulletDir2, false);
			Shoot (bulletDir3, false);
			Shoot (bulletDir4, true);
			Shoot (bulletDir5, true);
			Shoot (bulletDir6, true);
			Shoot (bulletDir7, true);
			Shoot (bulletDir8, true);
			Shoot (bulletDir9, true);
			yield return new WaitForSeconds (1.5f);
			Shoot (bulletDir1, true);
			Shoot (bulletDir2, true);
			Shoot (bulletDir3, false);
			Shoot (bulletDir4, false);
			Shoot (bulletDir5, true);
			Shoot (bulletDir6, true);
			Shoot (bulletDir7, true);
			Shoot (bulletDir8, true);
			Shoot (bulletDir9, true);
			yield return new WaitForSeconds (1.5f);
			Shoot (bulletDir1, true);
			Shoot (bulletDir2, true);
			Shoot (bulletDir3, true);
			Shoot (bulletDir4, false);
			Shoot (bulletDir5, false);
			Shoot (bulletDir6, true);
			Shoot (bulletDir7, true);
			Shoot (bulletDir8, true);
			Shoot (bulletDir9, true);
			yield return new WaitForSeconds (1.5f);
			Shoot (bulletDir1, true);
			Shoot (bulletDir2, true);
			Shoot (bulletDir3, true);
			Shoot (bulletDir4, true);
			Shoot (bulletDir5, false);
			Shoot (bulletDir6, false);
			Shoot (bulletDir7, true);
			Shoot (bulletDir8, true);
			Shoot (bulletDir9, true);
			yield return new WaitForSeconds (1.5f);
			Shoot (bulletDir1, true);
			Shoot (bulletDir2, true);
			Shoot (bulletDir3, true);
			Shoot (bulletDir4, true);
			Shoot (bulletDir5, true);
			Shoot (bulletDir6, false);
			Shoot (bulletDir7, false);
			Shoot (bulletDir8, true);
			Shoot (bulletDir9, true);
			yield return new WaitForSeconds (1.5f);
			Shoot (bulletDir1, true);
			Shoot (bulletDir2, true);
			Shoot (bulletDir3, true);
			Shoot (bulletDir4, true);
			Shoot (bulletDir5, true);
			Shoot (bulletDir6, true);
			Shoot (bulletDir7, false);
			Shoot (bulletDir8, false);
			Shoot (bulletDir9, true);
			yield return new WaitForSeconds (1.5f);
			Shoot (bulletDir1, true);
			Shoot (bulletDir2, true);
			Shoot (bulletDir3, true);
			Shoot (bulletDir4, true);
			Shoot (bulletDir5, true);
			Shoot (bulletDir6, true);
			Shoot (bulletDir7, true);
			Shoot (bulletDir8, false);
			Shoot (bulletDir9, false);
			yield return new WaitForSeconds (1.5f);
		}
	}

	private void moveRoutine() {
		if (GetIsTimeUp ()) {
			moveState++;
			if (moveState > 1) {
				moveState = 0;
			}
			switch (moveState) {
				case 0:
					StartNewVelocity (new Vector2(0f, 0.5f), 1.5f);
					break;
				case 1:
					StartNewVelocity (new Vector2(0f, -0.5f), 1.5f);
					break;
			}
		}
	}

	void OnDestroy(){
		levelControllerBehavior.HandleLevelFinished ();
	}

}
