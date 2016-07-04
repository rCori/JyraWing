using UnityEngine;
using System.Collections;

public class EnemySpawnTurret : EnemySpawner {

	public Vector2 position;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy1.transform.position = position;
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;
		enemy1 = Instantiate (enemy1);


	}
}
