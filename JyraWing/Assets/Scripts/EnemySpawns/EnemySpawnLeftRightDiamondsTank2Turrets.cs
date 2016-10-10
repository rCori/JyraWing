using UnityEngine;
using System.Collections;

public class EnemySpawnLeftRightDiamondsTank2Turrets : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		//Top diamond enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (-7.0f, 2f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (2f, 0f);
			enemyAI.time = 15f;
			enemyAI.repeat = false;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		//Bottom diamond enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (-7.0f, -2f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (2f, 0f);
			enemyAI.time = 15f;
			enemyAI.repeat = false;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		//Top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (7.0f, 3.5f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//Bottom turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			enemy.transform.position = new Vector3 (7.0f, -3.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
		
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//End tank at the end of the screen
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			enemy.transform.position = new Vector3 (24.0f, 0f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;

			EnemyAITank enemyAItank = enemy.GetComponent<EnemyAITank> ();
			enemyAItank.direction = EnemyAITank.TankDir.Left;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
	}
}
