using UnityEngine;
using System.Collections;

public class EnemySpawnShipSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public int shipHealth;
	public float speed;
	public float lifeTime;
	public float fireRate;
	public float bulletSpeed;
	public bool shieldableBullets;

	public override void Spawn ()
	{

		float yOffset = -columns / 2f + yShift;
		float xOffset = 8.0f;

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
				EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

				//Middle row
				GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
				enemy.transform.position = new Vector2 (xOffset + i*rowSpacing, yOffset + j*columnSpacing);

				enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
				enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
				enemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
				enemy.GetComponent<EnemyBehavior> ().shieldableBullets = false;
				EnemyAIBasicShip ai1 = enemy.GetComponent<EnemyAIBasicShip> ();
				ai1.angle = 180;
				ai1.speed = speed;
				ai1.lifeTime = lifeTime + i*speed;
				ai1.fireRate = fireRate;
				ai1.bulletSpeed = bulletSpeed;
				ai1.hits = shipHealth;
				ai1.shootInDirection = true;
				enemy.GetComponent<Scroll> ().speed = 1;
				enemy = Instantiate (enemy);
			}
		}
	}
}
