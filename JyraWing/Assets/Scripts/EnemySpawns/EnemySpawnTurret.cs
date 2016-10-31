using UnityEngine;
using System.Collections;

public class EnemySpawnTurret : EnemySpawner {

	public Vector2 position;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;


	public override void Spawn ()
	{
		GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
		enemy.transform.position = position;
		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
		enemyBehavior.LeftWallException = false;
		enemy = Instantiate (enemy);
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
	}
}
