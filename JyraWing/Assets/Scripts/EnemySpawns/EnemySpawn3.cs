using UnityEngine;
using System.Collections;

public class EnemySpawn3 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool>();

		Vector3 spawnPos = gameObject.transform.position;

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		EnemyAI3 ai1 = (EnemyAI3)enemy1.GetComponent("EnemyAI3");
		ai1.reverse = false;
		enemy1.transform.position = new Vector3(spawnPos.x-3f,
		                                        spawnPos.y-5.0f,
		                                        spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy1);
		
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		EnemyAI3 ai2 = (EnemyAI3)enemy2.GetComponent("EnemyAI3");
		ai2.reverse = true;
		enemy2.transform.position = new Vector3(spawnPos.x-3f,
		                                        spawnPos.y+5.0f,
		                                        spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy2);		
	}
}
