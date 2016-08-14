using UnityEngine;
using System.Collections;

public class EnemySpawn2DiamondsSwipe : EnemySpawner {
	
	public PointIconPool pointIconPool;
	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;

	public override void Spawn ()
	{

		Vector3 spawnPos = gameObject.transform.position;
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSwipe");
			EnemyAISwipe ai = (EnemyAISwipe)enemy.GetComponent ("EnemyAISwipe");
			ai.reverse = false;
			enemy.transform.position = new Vector3 (spawnPos.x - 3f,
				spawnPos.y - 5.0f,
				spawnPos.z);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			Instantiate (enemy);
		}
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSwipe");
			EnemyAISwipe ai = (EnemyAISwipe)enemy.GetComponent ("EnemyAISwipe");
			ai.reverse = true;
			enemy.transform.position = new Vector3 (spawnPos.x - 3f,
				spawnPos.y + 5.0f,
				spawnPos.z);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			Instantiate (enemy);
		}
	}
}
