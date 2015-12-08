using UnityEngine;
using System.Collections;

public class EnemySpawn22 : EnemySpawner {

	public int EnemyHealth = 3;
	public float EnemyFireRate = 0.5f;
	public float EnemyBulletSpeed = 2.0f;

	private EnemyAI10.FireDirection direction = EnemyAI10.FireDirection.LEFT;

	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		/* second turret */

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_J");
		enemy1.transform.position = new Vector2 (8f, 2f);
		
		enemy1.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;

		EnemyAI10 enemy1AI10 = enemy1.GetComponent<EnemyAI10> ();
		enemy1AI10.Health = EnemyHealth;
		enemy1AI10.BulletSpeed = EnemyBulletSpeed;
		enemy1AI10.FireRate = EnemyFireRate;
		enemy1AI10.fireDirection = direction;
		enemy1 = Instantiate (enemy1);

		/* bottom turret */

		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/Enemy_J");
		enemy2.transform.position = new Vector2 (8f, -2f);
		
		enemy2.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy2.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy2.GetComponent<EnemyBehavior> ().LeftWallException = false;

		EnemyAI10 enemy2AI10 = enemy2.GetComponent<EnemyAI10> ();
		enemy2AI10.Health = EnemyHealth;
		enemy2AI10.BulletSpeed = EnemyBulletSpeed;
		enemy2AI10.FireRate = EnemyFireRate;
		enemy2AI10.fireDirection = direction;
		enemy2 = Instantiate (enemy2);

	}
}
