using UnityEngine;
using System.Collections;

public class EnemySpawnShieldTank : EnemySpawner {

	public Vector2 enemyPosition;
	public EnemyAITankShield.TankDir direction;
    public bool shieldableBullets = false;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
        EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel2");
		enemy1.transform.position = enemyPosition;

        enemy1.GetComponent<EnemyBehavior>().bulletPool = bulletPool;
        enemy1.GetComponent<EnemyBehavior>().shieldableBulletPool = shieldableBulletPool;

		EnemyAITankShield ai1 = enemy1.GetComponent<EnemyAITankShield> ();
		ai1.direction = direction;
		enemy1 = Instantiate (enemy1);
        enemy1.GetComponent<EnemyBehavior>().shieldableBullets = shieldableBullets;
    }
}
