using UnityEngine;
using System.Collections;

public class EnemySpawnShipSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public float lifeTime;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{

		float yOffset = -(rows / 2f) + yShift;
		float xOffset = 9.0f;

		for (int i = 0; i < columns; i++) {
			for (int j = 0; j < rows; j++) {
				//Middle row
				GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_BasicEnemyShip");
				enemy.transform.position = new Vector2 (xOffset + i*columnSpacing, yOffset + j*rowSpacing);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = true;
				enemyBehavior.shieldableBullets = false;
				EnemyAIBasicShip ai = enemy.GetComponent<EnemyAIBasicShip> ();
				ai.angle = 180;
                ai.lifeTime = lifeTime;
				ai.shootInDirection = true;
				enemy.GetComponent<Scroll> ().speed = 1;
				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}
	}
}
