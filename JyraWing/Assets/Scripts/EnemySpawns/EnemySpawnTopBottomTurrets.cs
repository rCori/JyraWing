using UnityEngine;
using System.Collections;

public class EnemySpawnTopBottomTurrets : EnemySpawner {

	public bool top;
	public bool bottom;
	public int turretHealth;

	public bool shieldableBullets;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		if (top) {
			//top
			GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy1.transform.position = new Vector3 (5.5f, 3.7f, 0f);
			enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy1 = Instantiate (enemy1);
			enemy1.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;

			GameObject enemy2 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy2.transform.position = new Vector3 (8.5f, 3.7f, 0f);
			enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy2.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy2 = Instantiate (enemy2);
			enemy2.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;

			GameObject enemy3 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy3.transform.position = new Vector3 (11.5f, 3.7f, 0f);
			enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy3.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy3 = Instantiate (enemy3);
			enemy3.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;
			enemy3.GetComponent<EnemyBehavior>().SetEnemyHealth(turretHealth);
		}

		if (bottom) {
			GameObject enemy4 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy4.transform.position = new Vector3 (5.5f, -3.7f, 0f);
			enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy4.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy4 = Instantiate (enemy4);
			enemy4.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;

			GameObject enemy5 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy5.transform.position = new Vector3 (8.5f, -3.7f, 0f);
			enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy5.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy5 = Instantiate (enemy5);
			enemy5.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;

			GameObject enemy6 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy6.transform.position = new Vector3 (11.5f, -3.7f, 0f);
			enemy6.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy6.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy6 = Instantiate (enemy6);
			enemy6.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;
		}

	}
}
