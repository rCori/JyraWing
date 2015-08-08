using UnityEngine;
using System.Collections;

public class EnemySpawn1 : EnemySpawner {

	public float VerticalShift;

	public bool SpawnSpeedPowerup;

	public override void Spawn(){

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();


		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_A");
		enemy1.transform.position = new Vector3(6f,
		                                        VerticalShift + 0.5f,
		                                        0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1 = Instantiate (enemy1);

		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy2.transform.position = new Vector3(7f,
		                                        VerticalShift - 0.5f,
		                                        0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2 = Instantiate (enemy2);		

		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy3.transform.position = new Vector3(8f,
		                                        VerticalShift + 0.5f,
		                                        0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3 = Instantiate (enemy3);		

		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy4.transform.position = new Vector3(9f,
		                                        VerticalShift - 0.5f,
		                                        0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy4 = Instantiate (enemy4);

		
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy5.transform.position = new Vector3(10f,
		                                        VerticalShift + 0.5f,
		                                        0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5 = Instantiate (enemy5);

		if(SpawnSpeedPowerup){

			GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();

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

}
