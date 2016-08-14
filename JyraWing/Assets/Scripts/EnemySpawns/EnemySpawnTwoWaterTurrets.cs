using UnityEngine;
using System.Collections;

public class EnemySpawnTwoWaterTurrets : EnemySpawner {


	private EnemyAIWaterTurret.FireDirection direction = EnemyAIWaterTurret.FireDirection.LEFT;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn(){
		/* second turret */
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			enemy.transform.position = new Vector2 (8f, 2f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;

			EnemyAIWaterTurret enemyAI = enemy.GetComponent<EnemyAIWaterTurret> ();
			enemyAI.fireDirection = direction;
			enemy = Instantiate (enemy);
		}
		/* bottom turret */
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			enemy.transform.position = new Vector2 (8f, -2f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;

			EnemyAIWaterTurret enemyAI = enemy.GetComponent<EnemyAIWaterTurret> ();
			enemyAI.fireDirection = direction;
			enemy = Instantiate (enemy);
		}
	}
}
