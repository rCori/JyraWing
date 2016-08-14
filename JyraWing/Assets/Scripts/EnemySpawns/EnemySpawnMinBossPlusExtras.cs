using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnMinBossPlusExtras : EnemySpawner {

	public bool turrets = false;
	public bool sprayer = false;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BossEnemies/Enemy_MiniBoss1");
			enemy.transform.position = new Vector3 (9.0f, 0f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.LeftWallException = false;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;

			EnemyAIMiniBoss1 enemyAI = enemy.GetComponent<EnemyAIMiniBoss1> ();
			enemyAI.bulletSpeed = 3.5f;
			enemyAI.shotTime = 0.5f;
			enemyAI.health = 40;
			enemy = Instantiate (enemy);
		}
		if (turrets) {
			
			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
				enemy.transform.position = new Vector3 (9.0f, 2.5f, 0f);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = false;

				enemy.GetComponent<EnemyAIWaterTurret> ().fireDirection = EnemyAIWaterTurret.FireDirection.LEFT;
				enemy = Instantiate (enemy);
			}

			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
				enemy.transform.position = new Vector3 (9.0f, -2.5f, 0f);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = false;

				enemy.GetComponent<EnemyAIWaterTurret> ().fireDirection = EnemyAIWaterTurret.FireDirection.LEFT;
				enemy = Instantiate (enemy);
			}
		}

		if (sprayer) {
			{
				GameObject sprayerEnemy = (GameObject)Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayer");
				sprayerEnemy.transform.position = new Vector3 (11.0f, 0f, 0f);

				EnemyBehavior enemyBehavior = sprayerEnemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.LeftWallException = false;

				sprayerEnemy = Instantiate (sprayerEnemy);

				EnemyAIReflectBulletSprayerA enemyAI = sprayerEnemy.GetComponent<EnemyAIReflectBulletSprayerA> ();
				enemyAI.locations = new List<Vector2> {
					new Vector2 (6.0f, 3.0f), 
					new Vector2 (-6.0f, 3.0f),
					new Vector2 (-6.0f, -3.0f), 
					new Vector2 (11.0f, -3.0f),
				};
				enemyAI.times = new List<float> { 1.5f, 3.0f, 3.0f, 1.7f };
			}
		}
	}
}
