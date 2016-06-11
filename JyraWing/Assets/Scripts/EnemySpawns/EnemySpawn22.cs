using UnityEngine;
using System.Collections;

public class EnemySpawn22 : EnemySpawner {

	public int EnemyHealth = 3;
	public float EnemyFireRate = 0.5f;
	public float EnemyBulletSpeed = 2.0f;

	private EnemyAIWaterTurret.FireDirection direction = EnemyAIWaterTurret.FireDirection.LEFT;

	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		/* second turret */

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
		enemy1.transform.position = new Vector2 (8f, 2f);
		
		enemy1.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;

		EnemyAIWaterTurret enemy1AIWaterTurret = enemy1.GetComponent<EnemyAIWaterTurret> ();
		enemy1AIWaterTurret.BulletSpeed = EnemyBulletSpeed;
		enemy1AIWaterTurret.FireRate = EnemyFireRate;
		enemy1AIWaterTurret.fireDirection = direction;
		enemy1 = Instantiate (enemy1);

		/* bottom turret */

		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
		enemy2.transform.position = new Vector2 (8f, -2f);
		
		enemy2.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy2.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy2.GetComponent<EnemyBehavior> ().LeftWallException = false;

		EnemyAIWaterTurret enemy2AIWaterTurret = enemy2.GetComponent<EnemyAIWaterTurret> ();
		enemy2AIWaterTurret.BulletSpeed = EnemyBulletSpeed;
		enemy2AIWaterTurret.FireRate = EnemyFireRate;
		enemy2AIWaterTurret.fireDirection = direction;
		enemy2 = Instantiate (enemy2);

	}
}
