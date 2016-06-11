using UnityEngine;
using System.Collections;

public class EnemySpawnTank : EnemySpawner {

	public Vector2 enemyPosition;
	public int tankHealth;
	public EnemyAI5.TankDir direction;
    public bool shieldableBullets = false;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
        EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy1.transform.position = enemyPosition;

        //EnemyBehavior enemyBehavior = enemy1.GetComponent<EnemyBehavior>();
        enemy1.GetComponent<EnemyBehavior>().bulletPool = bulletPool;
        enemy1.GetComponent<EnemyBehavior>().shieldableBulletPool = shieldableBulletPool;

        EnemyAI5 ai1 = enemy1.GetComponent<EnemyAI5> ();
		ai1.direction = direction;
		enemy1 = Instantiate (enemy1);
        enemy1.GetComponent<EnemyBehavior>().shieldableBullets = shieldableBullets;
    }
}
