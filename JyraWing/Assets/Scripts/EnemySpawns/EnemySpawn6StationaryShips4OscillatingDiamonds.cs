using UnityEngine;
using System.Collections;

public class EnemySpawn6StationaryShips4OscillatingDiamonds : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{

		//first diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (4.0f, -4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, 4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyAIDiamondOscillate>().SetPaused(pauseController.IsPaused);
		}

		//second diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (8.0f, 4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, -4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyAIDiamondOscillate>().SetPaused(pauseController.IsPaused);
		}

	
		//third diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (12.0f, -4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, 4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyAIDiamondOscillate>().SetPaused(pauseController.IsPaused);
		}


		//fourth diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (16.0f, 4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, -4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyAIDiamondOscillate>().SetPaused(pauseController.IsPaused);
		}
	}
}
