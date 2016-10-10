using UnityEngine;
using System.Collections;

public class EnemySpawn3Turrets2Ships : EnemySpawner {

	public PointIconPool pointIconPool;
	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn(){

		//Top ship
		{
			GameObject shipEnemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			shipEnemy.transform.position = new Vector3 (11.0f, 2.5f, 0f);
			EnemyBehavior enemyBehavior = shipEnemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai = shipEnemy.GetComponent<EnemyAIShipArc> ();
			shipEnemy = Instantiate (shipEnemy);
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBullets = false;
            shipEnemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		//bottom ship enemy
		{
			GameObject shipEnemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			shipEnemy.transform.position = new Vector3 (11.0f, -2.5f, 0f);
			EnemyBehavior enemyBehavior = shipEnemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai = shipEnemy.GetComponent<EnemyAIShipArc> ();
			//shipEnemy.GetComponent<Scroll> ().speed = 0;
			shipEnemy = Instantiate (shipEnemy);
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBullets = true;
            shipEnemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		//Center water turret
		{
			GameObject waterTurretEnemy = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			waterTurretEnemy.transform.position = new Vector3 (8.0f, 0.0f, 0f);
		
			EnemyBehavior enemyBehavior = waterTurretEnemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;

            EnemyAIWaterTurret waterTurretAI = waterTurretEnemy.GetComponent<EnemyAIWaterTurret>();

			waterTurretEnemy = Instantiate (waterTurretEnemy);
            waterTurretEnemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		//bottom standard turret
		{

			GameObject standardTurret = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
			standardTurret.transform.position = new Vector3 (8.0f, 3.0f, 0f);
			EnemyBehavior enemyBehavior = standardTurret.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

            EnemyAITurretLevel1 turretAI = standardTurret.GetComponent<EnemyAITurretLevel1>();

			standardTurret = Instantiate (standardTurret);
			enemyBehavior.shieldableBullets = false;
            enemyBehavior.SetPaused(pauseController.IsPaused);
		}

	}

}
