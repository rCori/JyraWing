using UnityEngine;
using System.Collections;

public class EnemySpawn24 : EnemySpawner {

	public int ShipHealth = 3;
	public int TurretHealth = 3;

	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		//Top ship
		{
			GameObject shipEnemy = (GameObject)Resources.Load ("Enemies/Enemy_F");
			shipEnemy.transform.position = new Vector3 (11.0f, 2.5f, 0f);
			shipEnemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
			EnemyAI6 ai = shipEnemy.GetComponent<EnemyAI6> ();
			ai.angle = 180f;
			ai.speed = 2.0f;
			ai.lifeTime = 7.0f;
			ai.fireRate = 2.5f;
			ai.bulletSpeed = 6f;
			ai.hits = ShipHealth;
			shipEnemy.GetComponent<Scroll> ().speed = 0;
			shipEnemy = Instantiate (shipEnemy);
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBullets = false;
		}

		//bottom ship enemy
		{
			GameObject shipEnemy = (GameObject)Resources.Load ("Enemies/Enemy_F");
			shipEnemy.transform.position = new Vector3 (11.0f, -2.5f, 0f);
			shipEnemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			shipEnemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
			EnemyAI6 ai = shipEnemy.GetComponent<EnemyAI6> ();
			ai.angle = 180f;
			ai.speed = 2.0f;
			ai.lifeTime = 7.0f;
			ai.fireRate = 2.5f;
			ai.bulletSpeed = 6f;
			ai.hits = ShipHealth;
			shipEnemy.GetComponent<Scroll> ().speed = 0;
			shipEnemy = Instantiate (shipEnemy);
			shipEnemy.GetComponent<EnemyBehavior> ().shieldableBullets = true;
		}

		//Center water turret
		{
			GameObject waterTurretEnemy = (GameObject)Resources.Load ("Enemies/Enemy_J");
			waterTurretEnemy.transform.position = new Vector3 (8.0f, 0.0f, 0f);
		
			waterTurretEnemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			waterTurretEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			waterTurretEnemy.GetComponent<EnemyBehavior> ().LeftWallException = false;
		
			waterTurretEnemy.GetComponent<EnemyAI10> ().Health = TurretHealth;
			waterTurretEnemy.GetComponent<EnemyAI10> ().fireDirection = EnemyAI10.FireDirection.LEFT;
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
