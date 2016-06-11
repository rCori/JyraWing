using UnityEngine;
using System.Collections;

public class EnemySpawn4 : EnemySpawner {


	public override void Spawn(){

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();

		Vector3 spawnPos = gameObject.transform.position;
	
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
		enemy1.transform.position = new Vector3 (spawnPos.x,
	                                        	 spawnPos.y,
	                                       		 spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy1);
	
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy2.transform.position = new Vector3 (spawnPos.x,
	                                        	 spawnPos.y,
	                                       		 spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy2);		
	
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_B");
		enemy3.transform.position = new Vector3 (spawnPos.x,
	                                        	 spawnPos.y ,
	                                        	 spawnPos.z);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy3);	
	}
}
