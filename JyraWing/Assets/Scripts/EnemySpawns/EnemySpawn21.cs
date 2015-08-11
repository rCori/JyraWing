using UnityEngine;
using System.Collections;

public class EnemySpawn21 : EnemySpawner {
	

	public override void Spawn(){

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//Middle tank
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy1.transform.position = new Vector3(10.0f, 0f,0f);
		
		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		
		EnemyAI5 enemyAI1 = enemy1.GetComponent<EnemyAI5> ();
		enemyAI1.direction = EnemyAI5.TankDir.Left;
		
		enemy1 = Instantiate (enemy1);
		//Set the tanks health to 3
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (3);



		//Top tank
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy2.transform.position = new Vector3(10.0f, -2.0f,0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		
		EnemyAI5 enemyAI2 = enemy2.GetComponent<EnemyAI5> ();
		enemyAI2.direction = EnemyAI5.TankDir.Left;
		
		enemy2 = Instantiate (enemy2);
		//Set the tanks health to 3
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (3);



		//Bottom tank
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy3.transform.position = new Vector3(10.0f, 2.0f,0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;
		
		EnemyAI5 enemyAI3 = enemy3.GetComponent<EnemyAI5> ();
		enemyAI3.direction = EnemyAI5.TankDir.Left;
		
		enemy3 = Instantiate (enemy3);
		//Set the tanks health to 3
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (3);




		GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
		
		//hardcoding groupID, in the future I cannot do that.
		PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());

		group.SetPowerupObject (PowerupGroup.PowerupType.Bullet);

		group.AddToSquad (enemy1);
		group.AddToSquad (enemy2);
		group.AddToSquad (enemy3);

		controller.AddSquad (group);
	}
}
