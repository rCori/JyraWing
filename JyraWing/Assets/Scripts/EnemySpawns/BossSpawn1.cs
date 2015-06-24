using UnityEngine;
using System.Collections;

public class BossSpawn1 : EnemySpawner {
	
	public override void Spawn(){

		Vector3 spawnPos = gameObject.transform.position;

		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool>();

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_Boss");
		enemy1.transform.position = new Vector3(spawnPos.x - 2f,
			                                    spawnPos.y,
			                                    spawnPos.z);

		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyBoss boss = enemy1.GetComponent<EnemyBoss> ();
		boss.hits = 20;
		Instantiate (enemy1);
	}
}
