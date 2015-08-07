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

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_F");
		enemy1.transform.position = enemyPosition;

		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai1 = enemy1.GetComponent<EnemyAI6> ();
		ai1.angle = angle;
		ai1.speed = speed;
		ai1.lifeTime = lifeTime;
		ai1.fireRate = fireRate;
		ai1.bulletSpeed = bulletSpeed;
		ai1.hits = shipHealth;
		enemy1.GetComponent<Scroll> ().speed = 1;
		enemy1 = Instantiate (enemy1);
	}
}
