using UnityEngine;
using System.Collections;

public class EnemySpawnScreenThirds : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn () {

		for (int i = 0; i < 12; i++) {
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector2 (3f, 4f +(i*1.5f));

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (1f, -3f);
			enemyAI.time = 8f;
			enemyAI.repeat = false;

			enemy = Instantiate (enemy);
		}

		for (int i = 0; i < 12; i++) {
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector2 (-3f, 10f +(i*1.5f));

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (1f, -3f);
			enemyAI.time = 16f;
			enemyAI.repeat = false;

			enemy = Instantiate (enemy);
		}
			



	}

}
