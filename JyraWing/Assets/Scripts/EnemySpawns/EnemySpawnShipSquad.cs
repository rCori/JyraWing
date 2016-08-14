using UnityEngine;
using System.Collections;

public class EnemySpawnShipSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public float speed;
	public float lifeTime;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{

		float yOffset = -columns / 2f + yShift;
		float xOffset = 8.0f;

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				//Middle row
				GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_BasicEnemyShip");
				enemy.transform.position = new Vector2 (xOffset + i*rowSpacing, yOffset + j*columnSpacing);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = true;
				enemyBehavior.shieldableBullets = false;
				EnemyAIBasicShip ai = enemy.GetComponent<EnemyAIBasicShip> ();
				ai.angle = 180;
				ai.speed = speed;
				ai.lifeTime = lifeTime + i*speed;
				ai.shootInDirection = true;
				enemy.GetComponent<Scroll> ().speed = 1;
				enemy = Instantiate (enemy);
			}
		}
	}
}
