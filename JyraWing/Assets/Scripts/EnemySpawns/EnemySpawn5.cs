using UnityEngine;
using System.Collections;

public class EnemySpawn5 : EnemySpawner {

	public bool extraEnemies;
	public bool spawnSpeedPowerup;
	public int enemyHealth;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();

		Vector3 spawnPos = gameObject.transform.position;
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy1.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y,
		                                        spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (enemyHealth);



		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy2.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y-2.5f,
		                                        spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (enemyHealth);



		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy3.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y+2.5f,
		                                        spawnPos.z);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3 = Instantiate (enemy3);
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (enemyHealth);


		if (spawnSpeedPowerup) {
			GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();

			//hardcoding groupID, in the future I cannot do that.
			PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());

			group.SetPowerupObject (PowerupGroup.PowerupType.Speed);

			group.AddToSquad (enemy1);
			group.AddToSquad (enemy2);
			group.AddToSquad (enemy3);

			controller.AddSquad (group);
		}

		if (extraEnemies) {
			GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy4.transform.position = new Vector3 (spawnPos.x + 0.5f,
		                                        spawnPos.y + 3.5f,
		                                        spawnPos.z);
			enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			Instantiate (enemy4);
			enemy4.GetComponent<EnemyBehavior> ().SetEnemyHealth (enemyHealth);



			GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy5.transform.position = new Vector3 (spawnPos.x + 0.5f,
			                                         spawnPos.y - 3.5f,
			                                         spawnPos.z);
			enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			Instantiate (enemy5);
			enemy5.GetComponent<EnemyBehavior> ().SetEnemyHealth (enemyHealth);

		}
	}
}
