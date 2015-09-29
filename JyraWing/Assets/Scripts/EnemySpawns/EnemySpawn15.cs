using UnityEngine;
using System.Collections;

public class EnemySpawn15 : EnemySpawner {

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();


		//Enemies coming from the top
		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_I");

		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;

		EnemyAI9 enemyAI1 = enemy1.GetComponent<EnemyAI9> ();
		enemyAI1.startDelay = 0.0f;
		enemyAI1.isReverse = false;
		enemyAI1.fireTimes = new float[]{0.5f, 2.1f};
		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		
		EnemyAI9 enemyAI2 = enemy2.GetComponent<EnemyAI9> ();
		enemyAI2.fireTimes = new float[]{0.75f, 2.1f};
		enemyAI2.startDelay = 0.5f;
		enemyAI2.isReverse = false;
		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_I");
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;

		EnemyAI9 enemyAI3 = enemy3.GetComponent<EnemyAI9> ();
		enemyAI3.startDelay = 1.0f;
		enemyAI3.fireTimes = new float[]{1.0f, 2.1f};
		enemyAI3.isReverse = false;
		enemy3 = Instantiate (enemy3);
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;

		EnemyAI9 enemyAI4 = enemy4.GetComponent<EnemyAI9> ();
		enemyAI4.startDelay = 1.5f;
		enemyAI4.fireTimes = new float[]{1.25f, 2.1f};
		enemyAI4.isReverse = false;
		enemy4 = Instantiate (enemy4);
		enemy4.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);


		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_I");

		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;

		EnemyAI9 enemyAI5 = enemy5.GetComponent<EnemyAI9> ();
		enemyAI5.startDelay = 2.0f;
		enemyAI5.fireTimes = new float[]{1.5f, 2.1f};
		enemyAI5.isReverse = false;
		enemy5 = Instantiate (enemy5);
		enemy5.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);


//		//The enemies coming from the bottom up

		GameObject enemy6 = (GameObject) Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior6 = enemy6.GetComponent<EnemyBehavior> ();
		enemyBehavior6.bulletPool = bulletPool;
		
		EnemyAI9 enemyAI6 = enemy6.GetComponent<EnemyAI9> ();
		enemyAI6.startDelay = 0.0f;
		enemyAI6.fireTimes = new float[]{0.5f, 2.1f};
		enemyAI6.isReverse = true;
		enemy6 = Instantiate (enemy6);
		enemy6.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);
		
		GameObject enemy7 = (GameObject) Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior7 = enemy7.GetComponent<EnemyBehavior> ();
		enemyBehavior7.bulletPool = bulletPool;
		
		EnemyAI9 enemyAI7 = enemy7.GetComponent<EnemyAI9> ();
		enemyAI7.startDelay = 0.5f;
		enemyAI7.fireTimes = new float[]{0.75f, 2.1f};
		enemyAI7.isReverse = true;
		enemy7 = Instantiate (enemy7);
		enemy7.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);
		
		GameObject enemy8 = (GameObject)Resources.Load ("Enemies/Enemy_I");
		EnemyBehavior enemyBehavior8 = enemy8.GetComponent<EnemyBehavior> ();
		enemyBehavior8.bulletPool = bulletPool;
		
		EnemyAI9 enemyAI8 = enemy8.GetComponent<EnemyAI9> ();
		enemyAI8.startDelay = 1.0f;
		enemyAI8.fireTimes = new float[]{1.0f, 2.1f};
		enemyAI8.isReverse = true;
		enemy8 = Instantiate (enemy8);
		enemy8.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);
		
		GameObject enemy9 = (GameObject)Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior9 = enemy9.GetComponent<EnemyBehavior> ();
		enemyBehavior9.bulletPool = bulletPool;
		
		EnemyAI9 enemyAI9 = enemy9.GetComponent<EnemyAI9> ();
		enemyAI9.startDelay = 1.5f;
		enemyAI9.fireTimes = new float[]{1.25f, 2.1f};
		enemyAI9.isReverse = true;
		enemy9 = Instantiate (enemy9);
		enemy9.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);
		
		
		GameObject enemy10 = (GameObject)Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior10 = enemy10.GetComponent<EnemyBehavior> ();
		enemyBehavior10.bulletPool = bulletPool;
		
		EnemyAI9 enemyAI10 = enemy10.GetComponent<EnemyAI9> ();
		enemyAI10.startDelay = 2.0f;
		enemyAI10.fireTimes = new float[]{1.5f, 2.1f};
		enemy10 = Instantiate (enemy10);
		enemy10.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

	}
}
