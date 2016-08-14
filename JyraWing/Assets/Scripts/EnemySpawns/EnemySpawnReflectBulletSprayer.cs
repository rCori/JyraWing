using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnReflectBulletSprayer : EnemySpawner {

	public Vector2 enemyPosition;

	public int Health;

    public List<Vector2> locations;
    public List<float> times;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

    public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();
		
		GameObject enemy = (GameObject) Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayer");
		enemy.transform.position = enemyPosition;

		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool= bulletPool;
		enemyBehavior.shieldableBulletPool= shieldableBulletPool;
		enemyBehavior.pointIconPool= pointIconPool;
		enemyBehavior.LeftWallException = false;

		enemy = Instantiate (enemy);

		enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		enemyBehavior.SetEnemyHealth(Health);

        enemy.GetComponent<EnemyAIReflectBulletSprayerA>().locations = locations;
        enemy.GetComponent<EnemyAIReflectBulletSprayerA>().times = times;

    }
}
