using UnityEngine;
using System.Collections;

public class EnemySpawn16 : EnemySpawner {

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//Top diamond enemy
		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
		enemy1.transform.position = new Vector3 (-7.0f, 3.5f, 0f);

		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		enemyBehavior1.LeftWallException = true;

		EnemyAIDiamondOscillate enemyAI1 = enemy1.GetComponent<EnemyAIDiamondOscillate> ();
		enemyAI1.direction = new Vector2 (4f, 0f);
		enemyAI1.time = 7f;
		enemyAI1.repeat = false;
		enemy1 = Instantiate (enemy1);


		//Bottom diamond enemy
		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
		enemy2.transform.position = new Vector3 (-7.0f, -3.5f, 0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		enemyBehavior2.LeftWallException = true;
		
		EnemyAIDiamondOscillate enemyAI2 = enemy2.GetComponent<EnemyAIDiamondOscillate> ();
		enemyAI2.direction = new Vector2 (4f, 0f);
		enemyAI2.time = 7f;
		enemyAI2.repeat = false;
		enemy2 = Instantiate (enemy2);


		//bottom left diamond enemy
		GameObject enemy3 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
		enemy3.transform.position = new Vector3 (-2.0f, -4.0f, 0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;
		enemyBehavior3.LeftWallException = true;
		
		EnemyAIDiamondOscillate enemyAI3 = enemy3.GetComponent<EnemyAIDiamondOscillate> ();
		enemyAI3.direction = new Vector2 (0f, 4f);
		enemyAI3.time = 7f;
		enemyAI3.repeat = false;
		enemy3 = Instantiate (enemy3);
		
		
		//bottom right diamond enemy
		GameObject enemy4 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
		enemy3.transform.position = new Vector3 (2.0f, -4.0f, 0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;
		enemyBehavior4.LeftWallException = true;
		
		EnemyAIDiamondOscillate enemyAI4 = enemy4.GetComponent<EnemyAIDiamondOscillate> ();
		enemyAI4.direction = new Vector2 (0f, 4f);
		enemyAI4.time = 7f;
		enemyAI4.repeat = false;
		enemy4 = Instantiate (enemy4);


		//middle diamond enemy
		GameObject enemy5 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
		enemy5.transform.position = new Vector3 (-7.0f, 0f, 0f);
		
		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;
		enemyBehavior5.LeftWallException = true;
		
		EnemyAIDiamondOscillate enemyAI5 = enemy5.GetComponent<EnemyAIDiamondOscillate> ();
		enemyAI5.direction = new Vector2 (4f, 0f);
		enemyAI5.time = 7f;
		enemyAI5.repeat = false;
		enemy5 = Instantiate (enemy5);

		//Top turret
		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy6.transform.position = new Vector3 (7.0f, 3.0f, 0f);

		EnemyBehavior enemyBehavior6 = enemy6.GetComponent<EnemyBehavior> ();
		enemyBehavior6.bulletPool = bulletPool;

		enemy6 = Instantiate (enemy6);


		//Bottom turret
		GameObject enemy7 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy7.transform.position = new Vector3 (7.0f, -3.0f, 0f);
		
		EnemyBehavior enemyBehavior7 = enemy7.GetComponent<EnemyBehavior> ();
		enemyBehavior7.bulletPool = bulletPool;
		
		enemy7 = Instantiate (enemy7);
	}

}
