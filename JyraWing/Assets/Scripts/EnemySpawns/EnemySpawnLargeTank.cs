using UnityEngine;
using System.Collections;

public class EnemySpawnLargeTank : EnemySpawner {

    public Vector2 enemyPosition;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/LargeBlueTank");
		enemy.transform.position = enemyPosition;

		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;

		EnemyAITank ai1 = enemy.GetComponent<EnemyAITank> ();
		enemy = Instantiate (enemy);
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
    }
}
