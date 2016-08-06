using UnityEngine;
using System.Collections;

public class BossNew2Spawn : EnemySpawner {
	
	public override void Spawn(){

		Vector3 spawnPos = gameObject.transform.position;

		LevelControllerBehavior levelControllerBehavior = GameObject.Find ("LevelController").GetComponent<LevelControllerBehavior> ();
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		GameObject enemy = (GameObject) Resources.Load ("Enemies/BossEnemies/Enemy_NewBoss2");
		enemy.transform.position = new Vector3(4.0f,0f,0f);
		
		enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

		enemy.GetComponent<EnemyAINewBoss2>().levelControllerBehavior = levelControllerBehavior;

		Instantiate (enemy);
	}
}
