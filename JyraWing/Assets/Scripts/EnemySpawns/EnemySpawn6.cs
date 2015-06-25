using UnityEngine;
using System.Collections;

public class EnemySpawn6 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool>();
		
		Vector3 spawnPos = gameObject.transform.position;
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_G");
		enemy1.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y,
		                                        spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Left;
		Instantiate (enemy1);
		
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_G");
		enemy2.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y-1.5f,
		                                        spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Left;
		Instantiate (enemy2);
		
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy3.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y+1.5f,
		                                        spawnPos.z);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy3);
	}
}
