using UnityEngine;
using System.Collections;

public class EnemySpawnTank : EnemySpawner {

	public Vector2 enemyPosition;
	public EnemyAITank.TankDir direction;
    public bool shieldableBullets = false;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
        EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		if (shieldableBullets) {
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel2");
			enemy.transform.position = enemyPosition;

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAITankShield ai1 = enemy.GetComponent<EnemyAITankShield> ();
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		} else {

			GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			enemy.transform.position = enemyPosition;

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAITank ai1 = enemy.GetComponent<EnemyAITank> ();
			ai1.direction = direction;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
    }
}
