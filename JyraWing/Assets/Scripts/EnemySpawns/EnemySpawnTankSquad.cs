using UnityEngine;
using System.Collections;

public class EnemySpawnTankSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public bool shieldableBullets = false;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		float yOffset = -columns / 2f + yShift;
		float xOffset = 8.0f;
		for (int i = 0; i < columns; i++) {
			for (int j = 0; j < rows; j++) {
				if (!shieldableBullets) {
					GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
					enemy.transform.position = new Vector2 (xOffset + i * columnSpacing, yOffset + j * rowSpacing);

					EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
					enemyBehavior.bulletPool = bulletPool;
					enemyBehavior.shieldableBulletPool = shieldableBulletPool;
					enemyBehavior.pointIconPool = pointIconPool;

					EnemyAITank ai1 = enemy.GetComponent<EnemyAITank> ();
					ai1.direction = EnemyAITank.TankDir.Left;
					enemy = Instantiate (enemy);
                    enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
				} else {
					GameObject enemy = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel2");
					enemy.transform.position = new Vector2 (xOffset + i * columnSpacing, yOffset + j * rowSpacing);

					EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
					enemyBehavior.bulletPool = bulletPool;
					enemyBehavior.shieldableBulletPool = shieldableBulletPool;
					enemyBehavior.pointIconPool = pointIconPool;

					EnemyAITankShield ai1 = enemy.GetComponent<EnemyAITankShield> ();
					ai1.direction = EnemyAITankShield.TankDir.Left;
					enemy = Instantiate (enemy);
                    enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
				}
			}
		}
	}

}
