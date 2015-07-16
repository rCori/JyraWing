using UnityEngine;
using System.Collections;

public class EnemySpawn2 : EnemySpawner {

	public override void Spawn(){
		
		Vector3 spawnPos = gameObject.transform.position;

		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool>();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy1.transform.position = new Vector3(spawnPos.x,
		                                        spawnPos.y+3f,
		                                        spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy1);
		
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_A");
		enemy2.transform.position = new Vector3(spawnPos.x,
		                                        spawnPos.y-3f,
		                                        spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy2);		
		
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy3.transform.position = new Vector3(spawnPos.x+2f,
		                                        spawnPos.y-1f,
		                                        spawnPos.z);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy3);		

		
	}
}
