using UnityEngine;
using System.Collections;

public class EnemySpawn13 : EnemySpawner {

	public int turretHealth;

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();
		
		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_A");
		enemy1.transform.position = new Vector3(10f, 1f,
		                                        0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1 = Instantiate (enemy1);
		
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy2.transform.position = new Vector3(11f,
		                                        0f,
		                                        0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2 = Instantiate (enemy2);		
		
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy3.transform.position = new Vector3(12f,
		                                        1f,
		                                        0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3 = Instantiate (enemy3);		
		
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy4.transform.position = new Vector3(13f,
		                                         0f,
		                                        0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy4 = Instantiate (enemy4);
		
		
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy5.transform.position = new Vector3(14f,
		                                         1f,
		                                        0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5 = Instantiate (enemy5);

		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy6.transform.position = new Vector3 (5.5f, 3.7f, 0f);
		enemy6.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy6 = Instantiate (enemy6);
		enemy6.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);


		GameObject enemy7 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy7.transform.position = new Vector3 (5.5f, -3.7f, 0f);
		enemy7.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy7 = Instantiate (enemy7);
		enemy7.GetComponent<EnemyBehavior> ().SetEnemyHealth (turretHealth);


		GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
			
		//hardcoding groupID, in the future I cannot do that.
		PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
			
		group.SetPowerupObject (PowerupGroup.PowerupType.Bullet);
			
		group.AddToSquad (enemy1);
		group.AddToSquad (enemy2);
		group.AddToSquad (enemy3);
		group.AddToSquad (enemy4);
		group.AddToSquad (enemy5);
			
		controller.AddSquad (group);
		
	}
}
