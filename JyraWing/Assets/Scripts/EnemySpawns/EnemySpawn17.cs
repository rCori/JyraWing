using UnityEngine;
using System.Collections;

public class EnemySpawn17 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();

		//First bottom turret
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy1.transform.position = new Vector3 (7.0f, -3.5f, 0f);
		
		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		
		enemy1 = Instantiate (enemy1);



		//Second bottom turret
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy2.transform.position = new Vector3 (10.0f, -1.5f, 0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		
		enemy2 = Instantiate (enemy2);



		//Second top turret
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy3.transform.position = new Vector3 (10.0f, 1.5f, 0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;
		
		enemy3 = Instantiate (enemy3);


		//Third top turret
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy4.transform.position = new Vector3 (13.0f, 3.5f, 0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;
		
		enemy4 = Instantiate (enemy4);


		//Third top turret
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy5.transform.position = new Vector3 (16.0f, 3.5f, 0f);
		
		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;
		
		enemy5 = Instantiate (enemy5);

		//End tank at the end of the screen
		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy6.transform.position = new Vector3(24.0f, 0f,0f);
		
		EnemyBehavior enemyBehavior6 = enemy6.GetComponent<EnemyBehavior> ();
		enemyBehavior6.bulletPool = bulletPool;
		
		EnemyAI5 enemyAI6 = enemy6.GetComponent<EnemyAI5> ();
		enemyAI6.direction = EnemyAI5.TankDir.Left;
		
		enemy6 = Instantiate (enemy6);
	}

}
