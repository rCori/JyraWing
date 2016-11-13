using UnityEngine;
using System.Collections;

public class EnemySpawnShipSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
    public Vector2 initLocation;

	public float lifeTime;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{

		float yOffset = (-((rows-1) * rowSpacing) / 2.0f) + initLocation.y;
        float xOffset = initLocation.x;

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
