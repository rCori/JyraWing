using UnityEngine;
using System.Collections;

public class EnemySpawnShieldTank : EnemySpawner {

	public Vector2 enemyPosition;
	public EnemyAITankShield.TankDir direction;
    public bool shieldableBullets = false;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{

		GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel2");
		enemy.transform.position = enemyPosition;

		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool= pointIconPool;

		EnemyAITankShield ai1 = enemy.GetComponent<EnemyAITankShield> ();
		ai1.direction = direction;
		enemy = Instantiate (enemy);
		enemy.GetComponent<EnemyBehavior>().shieldableBullets = shieldableBullets;
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
    }
}
