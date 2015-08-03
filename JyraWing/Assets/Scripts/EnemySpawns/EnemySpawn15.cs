using UnityEngine;
using System.Collections;

public class EnemySpawn15 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_I");

		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;

		EnemyAI9 enemyAI1 = enemy1.GetComponent<EnemyAI9> ();
		enemyAI1.fireRate = 1.4f;
		enemyAI1.startDelay = 0.5f;
		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		
		EnemyAI9 enemyAI2 = enemy2.GetComponent<EnemyAI9> ();
		enemyAI2.fireRate = 1.1f;
		enemyAI2.fireDelay = 0.3f;
		enemyAI2.startDelay = 1.0f;
		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_I");
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;

		EnemyAI9 enemyAI3 = enemy3.GetComponent<EnemyAI9> ();
		enemyAI3.fireRate = 0.7f;
		enemyAI3.fireDelay = 0.6f;
		enemyAI3.startDelay = 1.5f;
		enemy3 = Instantiate (enemy3);
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_I");
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;

		EnemyAI9 enemyAI4 = enemy3.GetComponent<EnemyAI9> ();
		enemyAI4.fireRate = 0.7f;
		enemyAI4.fireDelay = 0.6f;
		enemyAI4.startDelay = 2.0f;
		enemy4 = Instantiate (enemy4);
		enemy4.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);


		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_I");

		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;

		EnemyAI9 enemyAI5 = enemy5.GetComponent<EnemyAI9> ();
		enemyAI5.fireRate = 1.3f;
		enemyAI5.fireDelay = 0.9f;
		enemyAI5.startDelay = 2.5f;
		enemy5 = Instantiate (enemy5);
		enemy5.GetComponent<EnemyBehavior> ().SetEnemyHealth (2);

		GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();

		PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
		
		group.SetPowerupObject (PowerupGroup.PowerupType.Speed);
		group.AddToSquad (enemy1);
		group.AddToSquad (enemy2);
		group.AddToSquad (enemy3);
		group.AddToSquad (enemy4);
		group.AddToSquad (enemy5);
		
		controller.AddSquad (group);
	}
}
