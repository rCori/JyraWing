using UnityEngine;
using System.Collections;

public class EnemySpawnDiamondAmbush2Turrets : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{
		//Top diamond enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (-7.0f, 3.5f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.LeftWallException = true;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (4f, 0f);
			enemyAI.time = 7f;
			enemyAI.repeat = false;
			enemy = Instantiate (enemy);
		}


		//Bottom diamond enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (-7.0f, -3.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.LeftWallException = true;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (4f, 0f);
			enemyAI.time = 7f;
			enemyAI.repeat = false;
			enemy = Instantiate (enemy);
		}


		//bottom left diamond enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (-2.0f, -4.0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.LeftWallException = true;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, 4f);
			enemyAI.time = 7f;
			enemyAI.repeat = false;
			enemy = Instantiate (enemy);
		}

		
		//bottom right diamond enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (2.0f, -4.0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.LeftWallException = true;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, 4f);
			enemyAI.time = 7f;
			enemyAI.repeat = false;
			enemy = Instantiate (enemy);
		}

		//middle diamond enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (-7.0f, 0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.LeftWallException = true;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (4f, 0f);
			enemyAI.time = 7f;
			enemyAI.repeat = false;
			enemy = Instantiate (enemy);
		}

		//Top turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (7.0f, 3.0f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;

			enemy = Instantiate (enemy);
		}

		//Bottom turret
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (7.0f, -3.0f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
		
			enemy = Instantiate (enemy);
		}
	}

}
