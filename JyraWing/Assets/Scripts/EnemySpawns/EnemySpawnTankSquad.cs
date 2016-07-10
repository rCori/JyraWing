using UnityEngine;
using System.Collections;

public class EnemySpawnTankSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public bool shieldableBullets = false;

	public override void Spawn ()
	{

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		float yOffset = -columns / 2f + yShift;
		float xOffset = 8.0f;
		for (int i = 0; i < columns; i++) {
			for (int j = 0; j < rows; j++) {
				if (!shieldableBullets) {
					GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
					enemy1.transform.position = new Vector2 (xOffset + i * columnSpacing, yOffset + j * rowSpacing);

					//EnemyBehavior enemyBehavior = enemy1.GetComponent<EnemyBehavior>();
					enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
					enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

					EnemyAITank ai1 = enemy1.GetComponent<EnemyAITank> ();
					ai1.direction = EnemyAITank.TankDir.Left;
					enemy1 = Instantiate (enemy1);
					enemy1.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;
				} else {
					GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel2");
					enemy1.transform.position = new Vector2 (xOffset + i * columnSpacing, yOffset + j * rowSpacing);

					//EnemyBehavior enemyBehavior = enemy1.GetComponent<EnemyBehavior>();
					enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
					enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

					EnemyAITankShield ai1 = enemy1.GetComponent<EnemyAITankShield> ();
					ai1.direction = EnemyAITankShield.TankDir.Left;
					enemy1 = Instantiate (enemy1);
					enemy1.GetComponent<EnemyBehavior> ().shieldableBullets = shieldableBullets;
				}
			}
		}
	}

}
