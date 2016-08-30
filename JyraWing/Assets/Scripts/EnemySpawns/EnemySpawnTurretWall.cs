using UnityEngine;
using System.Collections;

public class EnemySpawnTurretWall : EnemySpawner {

	public bool extraEnemies;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{
		Vector3 spawnPos = gameObject.transform.position;
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (spawnPos.x + 0.5f,
				spawnPos.y,
				spawnPos.z);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (spawnPos.x + 0.5f,
				spawnPos.y - 2.5f,
				spawnPos.z);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (spawnPos.x + 0.5f,
				spawnPos.y + 2.5f,
				spawnPos.z);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		if (extraEnemies) {
			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
				enemy.transform.position = new Vector3 (spawnPos.x + 0.5f,
					spawnPos.y + 3.5f,
					spawnPos.z);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				Instantiate (enemy);
			}

			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
				enemy.transform.position = new Vector3 (spawnPos.x + 0.5f,
					spawnPos.y - 3.5f,
					spawnPos.z);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				Instantiate (enemy);
			}
		}
	}
}
