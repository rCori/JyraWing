using UnityEngine;
using System.Collections;

public class EnemySpawn12 : EnemySpawner {


	public int turretHealth;
	public int shipHealth;

	public override void Spawn ()
	{

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy1.transform.position = new Vector3 (8.5f, 3.3f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);


		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy2.transform.position = new Vector3 (8.5f, -3.3f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);



		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy3.transform.position = new Vector3 (14.0f, 0.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai3 = enemy3.GetComponent<EnemyAI6> ();
		ai3.angle = 180f;
		ai3.speed = 1.5f;
		ai3.lifeTime = 20.0f;
		ai3.fireRate = 2.5f;
		ai3.bulletSpeed = 2f;
		ai3.hits = shipHealth;
		enemy3.GetComponent<Scroll> ().speed = 0;
		enemy3 = Instantiate (enemy3);

		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy4.transform.position = new Vector3 (23.0f, 2.0f, 0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy4.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai4 = enemy4.GetComponent<EnemyAI6> ();
		ai4.angle = 180f;
		ai4.speed = 1.5f;
		ai4.lifeTime = 30.0f;
		ai4.fireRate = 2.5f;
		ai4.bulletSpeed = 2f;
		ai4.hits = shipHealth;
		enemy4.GetComponent<Scroll> ().speed = 0;
		enemy4 = Instantiate (enemy4);

		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy5.transform.position = new Vector3 (19.0f, -2.0f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai5 = enemy5.GetComponent<EnemyAI6> ();
		ai5.angle = 180f;
		ai5.speed = 1.5f;
		ai5.lifeTime = 20.0f;
		ai5.fireRate = 2.5f;
		ai5.bulletSpeed = 2f;
		ai5.hits = shipHealth;
		enemy5.GetComponent<Scroll> ().speed = 0;
		enemy5 = Instantiate (enemy5);

		//GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
		GameController controller = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController();

		//PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
		PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());

		group.SetPowerupType (PowerupGroup.PowerupType.Speed);

		group.AddToSquad (enemy3);
		group.AddToSquad (enemy4);
		group.AddToSquad (enemy5);
		
		//controller.AddSquad (group);
		controller.AddSquad (group);

	}
}
