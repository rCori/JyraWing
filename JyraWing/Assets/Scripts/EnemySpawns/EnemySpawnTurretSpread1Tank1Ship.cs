using UnityEngine;
using System.Collections;

public class EnemySpawnTurretSpread1Tank1Ship : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//First bottom turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (9.0f, -3.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//Second bottom turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (12.0f, -1.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//Third top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (12.0f, 1.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//Fourth top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (15.0f, 3.0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		//Fifth top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (18.0f, 3.0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//End tank at the end of the screen
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			enemy.transform.position = new Vector3 (25.0f, 0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAITank enemyAI = enemy.GetComponent<EnemyAITank> ();
			enemyAI.direction = EnemyAITank.TankDir.Left;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector2 (29.0f, 1.5f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAIShipArc ai7 = enemy.GetComponent<EnemyAIShipArc> ();

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
	}

}
