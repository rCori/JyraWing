using UnityEngine;
using System.Collections;

public class EnemySpawnTurretSpread1Tank1Ship : EnemySpawner {

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//First bottom turret
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy1.transform.position = new Vector3 (7.0f, -3.5f, 0f);
		
		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;

		enemy1 = Instantiate (enemy1);


		//Second bottom turret
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy2.transform.position = new Vector3 (10.0f, -1.5f, 0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;

		enemy2 = Instantiate (enemy2);



		//Second top turret
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy3.transform.position = new Vector3 (10.0f, 1.5f, 0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;

		enemy3 = Instantiate (enemy3);



		//Third top turret
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy4.transform.position = new Vector3 (13.0f, 3.5f, 0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;

		enemy4 = Instantiate (enemy4);


		//Third top turret
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy5.transform.position = new Vector3 (16.0f, 3.5f, 0f);
		
		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;

		enemy5 = Instantiate (enemy5);



		//End tank at the end of the screen
		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy6.transform.position = new Vector3(24.0f, 0f,0f);
		
		EnemyBehavior enemyBehavior6 = enemy6.GetComponent<EnemyBehavior> ();
		enemyBehavior6.bulletPool = bulletPool;
		
		EnemyAITank enemyAI6 = enemy6.GetComponent<EnemyAITank> ();
		enemyAI6.direction = EnemyAITank.TankDir.Left;

		enemy6 = Instantiate (enemy6);
		//Set the tanks health to 3


//		//Turrets will drop a bullet powerup
//		if (turretDropsBullet) {
//			//GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
//			GameController controller = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController();
//
//			//PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
//			PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
//
//			group.SetPowerupType (PowerupGroup.PowerupType.Bullet);
//
//			group.AddToSquad(enemy1);
//			group.AddToSquad(enemy2);
//			group.AddToSquad(enemy3);
//			group.AddToSquad(enemy4);
//			group.AddToSquad(enemy5);
//
//			//controller.AddSquad(group);
//			controller.AddSquad(group);
//
//		}


		GameObject enemy7 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy7.transform.position = new Vector2(28.0f, 1.5f);
		
		enemy7.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy7.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAIShipArc ai7 = enemy7.GetComponent<EnemyAIShipArc> ();
		ai7.angle = 180.0f;
		ai7.speed = 2.0f;
		ai7.lifeTime = 12f;
		ai7.fireRate = 0.7f;
		ai7.bulletSpeed = 4f;
		ai7.hits = 1;
		enemy7.GetComponent<Scroll> ().speed = 1;
		enemy7 = Instantiate (enemy7);
	}

}
