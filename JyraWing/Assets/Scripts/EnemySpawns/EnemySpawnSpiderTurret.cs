using UnityEngine;
using System.Collections;

public class EnemySpawnSpiderTurret : EnemySpawner {

	public Vector2 enemyPosition;

	public EnemyAITurretLevel2.FireDirection Direction;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn () {
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_SpiderTurret");
		enemy.transform.position = enemyPosition;

		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
		enemy.GetComponent<EnemyAITurretLevel2> ().fireDirection = Direction;
		enemy = Instantiate (enemy);
	}
}
