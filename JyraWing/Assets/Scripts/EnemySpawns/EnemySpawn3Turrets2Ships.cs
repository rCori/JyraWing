using UnityEngine;
using System.Collections;

public class EnemySpawn3Turrets2Ships : EnemySpawner {


	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		//Top ship
		{
			GameObject shipEnemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			shipEnemy.transform.position = new Vector3 (11.0f, 2.5f, 0f);
			shipEnemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
			EnemyAIShipArc ai = shipEnemy.GetComponent<EnemyAIShipArc> ();
			shipEnemy.GetComponent<Scroll> ().speed = 0;
			shipEnemy = Instantiate (shipEnemy);
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBullets = false;
		}

		//bottom ship enemy
		{
			GameObject shipEnemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			shipEnemy.transform.position = new Vector3 (11.0f, -2.5f, 0f);
			shipEnemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
			EnemyAIShipArc ai = shipEnemy.GetComponent<EnemyAIShipArc> ();
			shipEnemy.GetComponent<Scroll> ().speed = 0;
			shipEnemy = Instantiate (shipEnemy);
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBullets = true;
		}

		//Center water turret
		{
			GameObject waterTurretEnemy = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			waterTurretEnemy.transform.position = new Vector3 (8.0f, 0.0f, 0f);
		
			waterTurretEnemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			waterTurretEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			waterTurretEnemy.GetComponent<EnemyBehavior> ().LeftWallException = false;
		
			waterTurretEnemy.GetComponent<EnemyAIWaterTurret> ().fireDirection = EnemyAIWaterTurret.FireDirection.LEFT;
			waterTurretEnemy = Instantiate (waterTurretEnemy);
		}

		//bottom standard turret
		{

			GameObject standardTurret = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			standardTurret.transform.position = new Vector3 (8.0f, 3.0f, 0f);
			standardTurret.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			standardTurret.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			standardTurret = Instantiate (standardTurret);
			standardTurret.GetComponent<EnemyBehavior> ().shieldableBullets = false;
		}

	}

}
