using UnityEngine;
using System.Collections;

public class EnemySpawn16 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();

		//Top diamond enemy
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy1.transform.position = new Vector3 (-7.0f, 3.5f, 0f);

		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		enemyBehavior1.LeftWallException = true;

		EnemyAI8 enemyAI1 = enemy1.GetComponent<EnemyAI8> ();
		enemyAI1.direction = new Vector2 (4f, 0f);
		enemyAI1.time = 15f;
		enemyAI1.repeat = false;
		enemy1 = Instantiate (enemy1);


		//Bottom diamond enemy
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy2.transform.position = new Vector3 (-7.0f, -3.5f, 0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		enemyBehavior2.LeftWallException = true;
		
		EnemyAI8 enemyAI2 = enemy2.GetComponent<EnemyAI8> ();
		enemyAI2.direction = new Vector2 (4f, 0f);
		enemyAI2.time = 15f;
		enemyAI2.repeat = false;
		enemy2 = Instantiate (enemy2);


		//top-mid diamond enemy
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy3.transform.position = new Vector3 (-9.0f, 2.0f, 0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;
		enemyBehavior3.LeftWallException = true;
		
		EnemyAI8 enemyAI3 = enemy3.GetComponent<EnemyAI8> ();
		enemyAI3.direction = new Vector2 (4f, 0f);
		enemyAI3.time = 20f;
		enemyAI3.repeat = false;
		enemy3 = Instantiate (enemy3);
	

		//bottom-mid diamond enemy
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy3.transform.position = new Vector3 (-9.0f, -2.0f, 0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;
		enemyBehavior4.LeftWallException = true;
		
		EnemyAI8 enemyAI4 = enemy4.GetComponent<EnemyAI8> ();
		enemyAI4.direction = new Vector2 (4f, 0f);
		enemyAI4.time = 20f;
		enemyAI4.repeat = false;
		enemy4 = Instantiate (enemy4);


		//middle diamon enemy
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy5.transform.position = new Vector3 (-11.0f, 0f, 0f);
		
		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;
		enemyBehavior5.LeftWallException = true;
		
		EnemyAI8 enemyAI5 = enemy5.GetComponent<EnemyAI8> ();
		enemyAI5.direction = new Vector2 (4f, 0f);
		enemyAI5.time = 25f;
		enemyAI5.repeat = false;
		enemy5 = Instantiate (enemy5);


		//Top turret
		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy6.transform.position = new Vector3 (7.0f, 3.5f, 0f);

		EnemyBehavior enemyBehavior6 = enemy6.GetComponent<EnemyBehavior> ();
		enemyBehavior6.bulletPool = bulletPool;

		enemy6 = Instantiate (enemy6);


		//Bottom turret
		GameObject enemy7 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy7.transform.position = new Vector3 (7.0f, -3.5f, 0f);
		
		EnemyBehavior enemyBehavior7 = enemy7.GetComponent<EnemyBehavior> ();
		enemyBehavior7.bulletPool = bulletPool;
		
		enemy7 = Instantiate (enemy7);
	}

}
