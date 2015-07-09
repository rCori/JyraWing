using UnityEngine;
using System.Collections;

public class EnemySpawn10 : EnemySpawner {

	public bool spawnBulletPowerup;

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();
		
		//top
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy1.transform.position = new Vector3 (5.5f, 3.5f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1 = Instantiate (enemy1);

		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy2.transform.position = new Vector3 (6.5f, 1.8f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2 = Instantiate (enemy2);

		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy3.transform.position = new Vector3 (7.5f, 0.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3 = Instantiate (enemy3);


		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy4.transform.position = new Vector3 (8.0f, -1.8f, 0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy4 = Instantiate (enemy4);
		
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy5.transform.position = new Vector3 (8.5f, -3.5f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5 = Instantiate (enemy5);



		if (spawnBulletPowerup) {
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
}
