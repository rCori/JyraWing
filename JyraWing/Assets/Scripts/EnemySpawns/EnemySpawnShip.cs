using UnityEngine;
using System.Collections;

public class EnemySpawnShip : EnemySpawner {

	public Vector2 enemyPosition;
	public float speed;
	public float angle;
	public float lifeTime;
	public float fireRate;
	public float bulletSpeed;
	public bool shieldableBullets;
	public bool shootInDirection;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_BasicEnemyShip");
		enemy.transform.position = enemyPosition;

		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
		enemyBehavior.LeftWallException = true;
		EnemyAIBasicShip ai1 = enemy.GetComponent<EnemyAIBasicShip> ();
		ai1.angle = angle;
		ai1.speed = speed;
		ai1.lifeTime = lifeTime;
		ai1.shootInDirection = shootInDirection;
		enemy.GetComponent<Scroll> ().speed = 1;
		enemy = Instantiate (enemy);
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
	}
}
