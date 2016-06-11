using UnityEngine;
using System.Collections;

public class EnemySpawnShip : EnemySpawner {

	public Vector2 enemyPosition;
	public int shipHealth;
	public float speed;
	public float angle;
	public float lifeTime;
	public float fireRate;
	public float bulletSpeed;
	public bool shieldableBullets;
	public bool shootInDirection;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_BasicEnemyShip");
		enemy1.transform.position = enemyPosition;

		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = true;
		enemy1.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;
		EnemyAIBasicShip ai1 = enemy1.GetComponent<EnemyAIBasicShip> ();
		ai1.angle = angle;
		ai1.speed = speed;
		ai1.lifeTime = lifeTime;
		ai1.fireRate = fireRate;
		ai1.bulletSpeed = bulletSpeed;
		ai1.hits = shipHealth;
		ai1.shootInDirection = shootInDirection;
		enemy1.GetComponent<Scroll> ().speed = 1;
		enemy1 = Instantiate (enemy1);
	}
}
