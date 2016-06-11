using UnityEngine;
using System.Collections;

public class EnemySpawnDiamond: EnemySpawner {

	public Vector2 enemyPosition;

	public Vector2 enemyDirection;

	public float enemyTime;

	public bool enemyRepeat;

	public int enemyHitPoints;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
		enemy1.transform.position = enemyPosition;

		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		if (enemyRepeat) {
			enemyBehavior1.LeftWallException = false;
		}

		EnemyAIDiamondOscillate enemyAI1 = enemy1.GetComponent<EnemyAIDiamondOscillate> ();
		enemyAI1.direction = enemyDirection;
		enemyAI1.time = enemyTime;
		enemyAI1.repeat = enemyRepeat;



		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (enemyHitPoints);

	}
}
