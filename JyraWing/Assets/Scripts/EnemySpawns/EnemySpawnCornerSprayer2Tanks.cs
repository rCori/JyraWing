using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnCornerSprayer2Tanks : EnemySpawner {

	public bool swapSprayerSide = false;

	public bool ships = false;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	// Use this for initialization
	public override void Spawn () {

		float yFactor = 1f;
		if (swapSprayerSide) {
			yFactor = -1f;
		}

		//Bullet sprayer going diagonaly through the right half of the screen and then back up
		{
			GameObject enemyBulletSprayer = (GameObject)Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayer");
			enemyBulletSprayer.transform.position = new Vector3 (6.0f, yFactor * 3.5f, 0.0f);

			EnemyBehavior enemyBehavior = enemyBulletSprayer.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

            EnemyAIReflectBulletSprayerA reflectBulletAI = enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>();

			enemyBulletSprayer = Instantiate (enemyBulletSprayer);

			enemyBulletSprayer.GetComponent<EnemyBehavior> ().SetEnemyHealth (3);
            enemyBulletSprayer.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA> ().locations = new List<Vector2> {
				new Vector2 (0.0f, yFactor * -3.5f),
				new Vector2 (-6.0f, yFactor * 3.5f)
			};
			enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA> ().times = new List<float> { 1.5f, 1.5f };
		}

		if (ships) {
			//Ship coming through from the top
			{
				GameObject ship = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
				ship.transform.position = new Vector3 (6.0f, 3.0f, 0.0f);

				EnemyBehavior enemyBehavior = ship.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;

				enemyBehavior.LeftWallException = true;
				enemyBehavior.shieldableBullets = false;
				ship.GetComponent<Scroll> ().speed = 1;
				ship = Instantiate (ship);
                ship.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}

			{
				//Ship coming through from the top
				GameObject ship = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
				ship.transform.position = new Vector3 (6.0f, -3.0f, 0.0f);

				EnemyBehavior enemyBehavior = ship.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;

				enemyBehavior.LeftWallException = true;
				enemyBehavior.shieldableBullets = false;
				ship.GetComponent<Scroll> ().speed = 1;

                EnemyAIShipArc shipAI = enemyBehavior.GetComponent<EnemyAIShipArc>();

				ship = Instantiate (ship);
                ship.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		} else {

			//top tank
			{
				GameObject tank = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
				tank.transform.position = new Vector3 (10.0f, 2f, 0f);

				EnemyBehavior enemyBehavior = tank.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.pointIconPool = pointIconPool;

				EnemyAITank tankAI = tank.GetComponent<EnemyAITank> ();
				tankAI.direction = EnemyAITank.TankDir.Left;

				tank = Instantiate (tank);
                tank.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}


			//bottom tank
			{
				GameObject tank = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
				tank.transform.position = new Vector3 (10.0f, -2f, 0f);

				EnemyBehavior enemyBehavior = tank.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.pointIconPool = pointIconPool;

				EnemyAITank bottomTankAI = tank.GetComponent<EnemyAITank> ();
				bottomTankAI.direction = EnemyAITank.TankDir.Left;

				tank = Instantiate (tank);
                tank.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}

	}
}
