using UnityEngine;
using System.Collections;

public class EnemySpawnLevel1SpecialShipCrossingEncounter : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		//Enemies coming from the top
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 0.0f;
			enemyAI.isReverse = false;
			enemyAI.fireTimes = new float[]{ 0.5f, 2.1f };
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.fireTimes = new float[]{ 0.75f, 2.1f };
			enemyAI.startDelay = 0.5f;
			enemyAI.isReverse = false;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 1.0f;
			enemyAI.fireTimes = new float[]{ 1.0f, 2.1f };
			enemyAI.isReverse = false;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 1.5f;
			enemyAI.fireTimes = new float[]{ 1.25f, 2.1f };
			enemyAI.isReverse = false;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 2.0f;
			enemyAI.fireTimes = new float[]{ 1.5f, 2.1f };
			enemyAI.isReverse = false;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

//		//The enemies coming from the bottom up
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 0.0f;
			enemyAI.fireTimes = new float[]{ 0.5f, 2.1f };
			enemyAI.isReverse = true;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 0.5f;
			enemyAI.fireTimes = new float[]{ 0.75f, 2.1f };
			enemyAI.isReverse = true;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 1.0f;
			enemyAI.fireTimes = new float[]{ 1.0f, 2.1f };
			enemyAI.isReverse = true;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 1.5f;
			enemyAI.fireTimes = new float[]{ 1.25f, 2.1f };
			enemyAI.isReverse = true;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
		
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipLevel1SpecialEncounter");
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
		
			EnemyAIShipLevel1SpecialEncounter enemyAI = enemy.GetComponent<EnemyAIShipLevel1SpecialEncounter> ();
			enemyAI.startDelay = 2.0f;
			enemyAI.fireTimes = new float[]{ 1.5f, 2.1f };
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
	}
}
