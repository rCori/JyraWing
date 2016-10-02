using UnityEngine;
using System.Collections;

public class EnemySpawnWaterTurret : EnemySpawner {

	public Vector2 enemyPosition;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{
		GameObject enemy = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
		enemy.transform.position = enemyPosition;
		
		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
		enemyBehavior.LeftWallException = false;
		enemy = Instantiate (enemy);
	}
}
