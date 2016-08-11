using UnityEngine;
using System.Collections;

public class EnemySpawnSpiderTurret : EnemySpawner {

	public Vector2 enemyPosition;

	public EnemyAITurretLevel2.FireDirection Direction;

	public override void Spawn () {
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_SpiderTurret");
		enemy1.transform.position = enemyPosition;

		enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy1.GetComponent<EnemyAITurretLevel2> ().fireDirection = Direction;
		enemy1 = Instantiate (enemy1);
	}
}
