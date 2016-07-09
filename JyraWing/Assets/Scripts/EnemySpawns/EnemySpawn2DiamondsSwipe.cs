using UnityEngine;
using System.Collections;

public class EnemySpawn2DiamondsSwipe : EnemySpawner {

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();

		Vector3 spawnPos = gameObject.transform.position;

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSwipe");
		EnemyAISwipe ai1 = (EnemyAISwipe)enemy1.GetComponent("EnemyAISwipe");
		ai1.reverse = false;
		enemy1.transform.position = new Vector3(spawnPos.x-3f,
		                                        spawnPos.y-5.0f,
		                                        spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy1);
		
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSwipe");
		EnemyAISwipe ai2 = (EnemyAISwipe)enemy2.GetComponent("EnemyAISwipe");
		ai2.reverse = true;
		enemy2.transform.position = new Vector3(spawnPos.x-3f,
		                                        spawnPos.y+5.0f,
		                                        spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		Instantiate (enemy2);		
	}
}
