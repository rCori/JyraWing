using UnityEngine;
using System.Collections;

public class EnemySpawnLevel1Intro : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public bool shieldableBullets;

	public override void Spawn ()
	{
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (10f, 1f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (11f,
				0f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);		
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (12f,
				1f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);	
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (13f,
				0f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (14f,
				1f,
				0f);
			enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (7.0f, 3.3f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (7.0f, -3.3f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}
		
	}
}
