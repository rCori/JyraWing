using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnMinBossPlusExtras : EnemySpawner {

	public bool turrets = false;
	public bool sprayer = false;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/BossEnemies/Enemy_MiniBoss1");
		enemy1.transform.position = new Vector3 (9.0f, 0f, 0f);

		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		enemyBehavior1.LeftWallException = false;

		EnemyAIMiniBoss1 enemyAI1 = enemy1.GetComponent<EnemyAIMiniBoss1> ();
		enemyAI1.bulletSpeed = 3.5f;
		enemyAI1.shotTime = 0.5f;
		enemyAI1.health = 40;
		enemy1 = Instantiate (enemy1);

		if (turrets) {
			GameObject enemy2 = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			enemy2.transform.position = new Vector3 (9.0f, 2.5f, 0f);

			enemy2.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
			enemy2.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
			enemy2.GetComponent<EnemyBehavior> ().LeftWallException = false;

			enemy2.GetComponent<EnemyAIWaterTurret> ().fireDirection = EnemyAIWaterTurret.FireDirection.LEFT;
			enemy2 = Instantiate (enemy2);



			GameObject enemy3 = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			enemy3.transform.position = new Vector3 (9.0f, -2.5f, 0f);

			enemy3.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
			enemy3.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
			enemy3.GetComponent<EnemyBehavior> ().LeftWallException = false;

			enemy3.GetComponent<EnemyAIWaterTurret> ().fireDirection = EnemyAIWaterTurret.FireDirection.LEFT;
			enemy3 = Instantiate (enemy3);

		}

		if (sprayer) {
			GameObject sprayerEnemy = (GameObject) Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayer");
			sprayerEnemy.transform.position = new Vector3(11.0f,0f,0f);

			sprayerEnemy.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
			sprayerEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
			sprayerEnemy.GetComponent<EnemyBehavior> ().LeftWallException = false;

			sprayerEnemy = Instantiate (sprayerEnemy);

			sprayerEnemy.GetComponent<EnemyBehavior>().SetEnemyHealth(5);
			sprayerEnemy.GetComponent<EnemyAIReflectBulletSprayerA>().locations = new List<Vector2> {
				new Vector2(6.0f, 3.0f), 
				new Vector2(-6.0f, 3.0f),
				new Vector2(-6.0f, -3.0f), 
				new Vector2(11.0f, -3.0f),
			};
			sprayerEnemy.GetComponent<EnemyAIReflectBulletSprayerA>().times = new List<float> {1.5f,3.0f,3.0f,1.7f};

			sprayerEnemy.GetComponent<EnemyAIReflectBulletSprayerA>().fireRate = 1.3f;
			sprayerEnemy.GetComponent<EnemyAIReflectBulletSprayerA>().bulletSpeed = 1.2f;

		}
	}
}
