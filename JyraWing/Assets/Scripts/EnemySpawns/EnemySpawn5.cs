using UnityEngine;
using System.Collections;

public class EnemySpawn5 : EnemySpawner {

	public bool extraEnemies;

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool>();

		Vector3 spawnPos = gameObject.transform.position;
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy1.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y,
		                                        spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy1);

		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy2.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y-2.5f,
		                                        spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy2);

		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy3.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y+2.5f,
		                                        spawnPos.z);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy3);

		if (extraEnemies) {
			GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_E");
			enemy4.transform.position = new Vector3 (spawnPos.x + 0.5f,
		                                        spawnPos.y + 3.5f,
		                                        spawnPos.z);
			enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			Instantiate (enemy4);

			GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_E");
			enemy5.transform.position = new Vector3 (spawnPos.x + 0.5f,
			                                         spawnPos.y - 3.5f,
			                                         spawnPos.z);
			enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			Instantiate (enemy5);

		}
	}
}
