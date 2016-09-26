using UnityEngine;
using System.Collections;

public class EnemySpawnTurretSpread1Tank1Ship : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//First bottom turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (8.0f, -3.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
		}


		//Second bottom turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (11.0f, -1.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
		}


		//Third top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (11.0f, 1.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
		}


		//Fourth top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (14.0f, 3.0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
		}

		//Fifth top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (17.0f, 3.0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
		}


		//End tank at the end of the screen
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			enemy.transform.position = new Vector3 (24.0f, 0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAITank enemyAI = enemy.GetComponent<EnemyAITank> ();
			enemyAI.direction = EnemyAITank.TankDir.Left;

			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector2 (28.0f, 1.5f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAIShipArc ai7 = enemy.GetComponent<EnemyAIShipArc> ();

			enemy = Instantiate (enemy);
		}
	}

}
