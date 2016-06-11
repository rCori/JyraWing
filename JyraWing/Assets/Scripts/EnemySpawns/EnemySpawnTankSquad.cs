using UnityEngine;
using System.Collections;

public class EnemySpawnTankSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public bool shieldableBullets = false;
	public int tankHealth;


	public override void Spawn ()
	{

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool>();

		float yOffset = -columns / 2f + yShift;
		float xOffset = 8.0f;

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
				enemy1.transform.position = new Vector2 (xOffset + i*rowSpacing, yOffset + j*columnSpacing);

				//EnemyBehavior enemyBehavior = enemy1.GetComponent<EnemyBehavior>();
				enemy1.GetComponent<EnemyBehavior>().bulletPool = bulletPool;
				enemy1.GetComponent<EnemyBehavior>().shieldableBulletPool = shieldableBulletPool;

				EnemyAI5 ai1 = enemy1.GetComponent<EnemyAI5> ();
				ai1.direction = EnemyAI5.TankDir.Left;
				enemy1 = Instantiate (enemy1);
				enemy1.GetComponent<EnemyBehavior>().shieldableBullets = shieldableBullets;
			}
		}
	}

}
