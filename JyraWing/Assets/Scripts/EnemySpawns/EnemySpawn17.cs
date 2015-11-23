using UnityEngine;
using System.Collections;

public class EnemySpawn17 : EnemySpawner {

	public int turretHealth;

	public bool turretDropsBullet;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//First bottom turret
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy1.transform.position = new Vector3 (7.0f, -3.5f, 0f);
		
		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;

		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);


		//Second bottom turret
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy2.transform.position = new Vector3 (10.0f, -1.5f, 0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;

		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);



		//Second top turret
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy3.transform.position = new Vector3 (10.0f, 1.5f, 0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;

		enemy3 = Instantiate (enemy3);
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);



		//Third top turret
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy4.transform.position = new Vector3 (13.0f, 3.5f, 0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;

		enemy4 = Instantiate (enemy4);
		enemy4.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);


		//Third top turret
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy5.transform.position = new Vector3 (16.0f, 3.5f, 0f);
		
		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;

		enemy5 = Instantiate (enemy5);
		enemy5.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);



		//End tank at the end of the screen
		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy6.transform.position = new Vector3(24.0f, 0f,0f);
		
		EnemyBehavior enemyBehavior6 = enemy6.GetComponent<EnemyBehavior> ();
		enemyBehavior6.bulletPool = bulletPool;
		
		EnemyAI5 enemyAI6 = enemy6.GetComponent<EnemyAI5> ();
		enemyAI6.direction = EnemyAI5.TankDir.Left;

		enemy6 = Instantiate (enemy6);
		//Set the tanks health to 3
		enemy6.GetComponent<EnemyBehavior> ().SetEnemyHealth (3);


		//Turrets will drop a bullet powerup
		if (turretDropsBullet) {
			//GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
			GameControllerRewrite controller2 = GameObject.Find ("GameController").GetComponent<GameControllerRewrite> ();

			//PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
			PowerupGroup group = new PowerupGroup (controller2.GetNextSquadID());

			group.SetPowerupType (PowerupGroup.PowerupType.Bullet);

			group.AddToSquad(enemy1);
			group.AddToSquad(enemy2);
			group.AddToSquad(enemy3);
			group.AddToSquad(enemy4);
			group.AddToSquad(enemy5);

			//controller.AddSquad(group);
			controller2.AddSquad(group);

		}



		//Ship going right
		GameObject enemy7 = (GameObject) Resources.Load ("Enemies/Enemy_F");
		enemy7.transform.position = new Vector2(-15.0f, -1.5f);
		
		enemy7.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy7.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai7 = enemy7.GetComponent<EnemyAI6> ();
		ai7.angle = 0.0f;
		ai7.speed = 3.0f;
		ai7.lifeTime = 15f;
		ai7.fireRate = 0.7f;
		ai7.bulletSpeed = 4f;
		ai7.hits = 1;
		enemy7.GetComponent<Scroll> ().speed = 1;
		enemy7 = Instantiate (enemy7);


		//Ship going left
		GameObject enemy8 = (GameObject) Resources.Load ("Enemies/Enemy_F");
		enemy8.transform.position = new Vector2(28.0f, 1.5f);
		
		enemy8.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy8.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai8 = enemy8.GetComponent<EnemyAI6> ();
		ai8.angle = 180.0f;
		ai8.speed = 2.0f;
		ai8.lifeTime = 12f;
		ai8.fireRate = 0.7f;
		ai8.bulletSpeed = 4f;
		ai8.hits = 1;
		enemy8.GetComponent<Scroll> ().speed = 1;
		enemy8 = Instantiate (enemy8);
	}

}
