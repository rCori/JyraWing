using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnReflectBulletSprayer : EnemySpawner {

	public Vector2 enemyPosition;

	public int Health;

    public List<Vector2> locations;
    public List<float> times;

    public float fireRate;
    public float bulletSpeed;

    public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();
		
		GameObject enemy = (GameObject) Resources.Load ("Enemies/Enemy_ReflectBulletSprayer");
		enemy.transform.position = enemyPosition;
		
		enemy.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy.GetComponent<EnemyBehavior> ().LeftWallException = false;

		enemy = Instantiate (enemy);

        enemy.GetComponent<EnemyBehavior>().SetEnemyHealth(Health);
        enemy.GetComponent<EnemyAIReflectBulletSprayerA>().locations = locations;
        enemy.GetComponent<EnemyAIReflectBulletSprayerA>().times = times;

        enemy.GetComponent<EnemyAIReflectBulletSprayerA>().fireRate = fireRate;
        enemy.GetComponent<EnemyAIReflectBulletSprayerA>().bulletSpeed = bulletSpeed;

    }
}
