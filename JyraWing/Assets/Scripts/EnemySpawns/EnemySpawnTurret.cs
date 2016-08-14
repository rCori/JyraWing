using UnityEngine;
using System.Collections;

public class EnemySpawnTurret : EnemySpawner {

	public Vector2 position;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{
		GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy.transform.position = position;
		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
		enemy = Instantiate (enemy);
		enemyBehavior = enemy.GetComponent<EnemyBehavior>();
		enemyBehavior.LeftWallException = false;
	}
}
