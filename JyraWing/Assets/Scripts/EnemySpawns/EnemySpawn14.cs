using UnityEngine;
using System.Collections;

public class EnemySpawn14 : EnemySpawner {


	public int turretHealth;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//Top diamond enemy
		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy1.transform.position = new Vector3(-7.0f, 2f,0f);

		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		enemyBehavior1.LeftWallException = true;

		EnemyAI8 enemyAI1 = enemy1.GetComponent<EnemyAI8> ();
		enemyAI1.direction = new Vector2 (2f, 0f);
		enemyAI1.time = 15f;
		enemyAI1.repeat = false;
		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (5);

		//Bottom diamond enemy
		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy2.transform.position = new Vector3(-7.0f, -2f,0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		enemyBehavior2.LeftWallException = true;

		EnemyAI8 enemyAI2 = enemy2.GetComponent<EnemyAI8> ();
		enemyAI2.direction = new Vector2 (2f, 0f);
		enemyAI2.time = 15f;
		enemyAI2.repeat = false;
		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (5);

		//Top turret
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy3.transform.position = new Vector3(7.0f, 3.5f,0f);

		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;

		enemy3 = Instantiate (enemy3);
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);



		//Bottom turret
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy4.transform.position = new Vector3(7.0f, -3.5f,0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;
		
		enemy4 = Instantiate (enemy4);
		enemy4.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);



		//End tank at the end of the screen
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy5.transform.position = new Vector3(24.0f, 0f,0f);

		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;

		EnemyAI5 enemyAI5 = enemy5.GetComponent<EnemyAI5> ();
		enemyAI5.direction = EnemyAI5.TankDir.Left;

		enemy5 = Instantiate (enemy5);



		GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
		
		PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
		
		group.SetPowerupObject (PowerupGroup.PowerupType.Speed);
		group.AddToSquad (enemy1);
		group.AddToSquad (enemy2);
		
		controller.AddSquad (group);
	}
}
