using UnityEngine;
using System.Collections;

public class EnemySpawnDiamond: EnemySpawner {

	public Vector2 enemyPosition;

	public Vector2 enemyDirection;

	public float enemyTime;

	public bool enemyRepeat;

	public EnemyBulletPool bulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		GameObject enemy = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
		enemy.transform.position = enemyPosition;

		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
		if (enemyRepeat) {
			enemyBehavior.LeftWallException = false;
		}

		EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
		enemyAI.direction = enemyDirection;
		enemyAI.time = enemyTime;
		enemyAI.repeat = enemyRepeat;

		enemy = Instantiate (enemy);
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
	}
}
