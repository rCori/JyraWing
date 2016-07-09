using UnityEngine;
using System.Collections;

public class EnemySpawnTank : EnemySpawner {

	public Vector2 enemyPosition;
	public EnemyAITank.TankDir direction;
    public bool shieldableBullets = false;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
        EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		if (shieldableBullets) {
			GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel2");
			enemy1.transform.position = enemyPosition;

			enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

			EnemyAITankShield ai1 = enemy1.GetComponent<EnemyAITankShield> ();
			enemy1 = Instantiate (enemy1);
			//enemy1.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;
		} else {

			GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			enemy1.transform.position = enemyPosition;

			enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

			EnemyAITank ai1 = enemy1.GetComponent<EnemyAITank> ();
			ai1.direction = direction;
			enemy1 = Instantiate (enemy1);
			//enemy1.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;
		}
    }
}
