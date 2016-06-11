using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn26 : EnemySpawner {

	public bool swapSprayerSide = false;

	public bool ships = false;

	// Use this for initialization
	public override void Spawn () {

		float yFactor = 1f;
		if (swapSprayerSide) {
			yFactor = -1f;
		}

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		//Bullet sprayer going diagonaly through the right half of the screen and then back up
		GameObject enemyBulletSprayer = (GameObject) Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayer");
		enemyBulletSprayer.transform.position = new Vector3 (6.0f, yFactor * 3.5f,0.0f);

		enemyBulletSprayer.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemyBulletSprayer.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

		enemyBulletSprayer = Instantiate (enemyBulletSprayer);

		enemyBulletSprayer.GetComponent<EnemyBehavior>().SetEnemyHealth(3);
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().locations = new List<Vector2> {new Vector2(0.0f, yFactor * -3.5f), new Vector2(-6.0f,  yFactor * 3.5f)};
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().times = new List<float> {1.5f, 1.5f};

		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().fireRate = 0.8f;
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().bulletSpeed = 2.0f;


		if (ships) {
			//Ship coming through from the top
			GameObject topShip = (GameObject) Resources.Load("Enemies/Enemy_F");
			topShip.transform.position = new Vector3 (6.0f, 3.0f,0.0f);

			topShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			topShip.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

			topShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
			topShip.GetComponent<EnemyBehavior> ().shieldableBullets = false;
			EnemyAI6 topShipAI = topShip.GetComponent<EnemyAI6> ();
			topShipAI.angle = 180f;
			topShipAI.speed = 2.5f;
			topShipAI.fireRate = 1.6f;
			topShipAI.bulletSpeed = 2.3f;
			topShipAI.hits = 2;
			topShipAI.lifeTime = 4f;
			topShip.GetComponent<Scroll> ().speed = 1;
			topShip = Instantiate (topShip);

			//Ship coming through from the top
			GameObject bottomShip = (GameObject) Resources.Load("Enemies/Enemy_F");
			bottomShip.transform.position = new Vector3 (6.0f, -3.0f,0.0f);

			bottomShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			bottomShip.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

			bottomShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
			bottomShip.GetComponent<EnemyBehavior> ().shieldableBullets = false;
			EnemyAI6 bottomShipAI = topShip.GetComponent<EnemyAI6> ();
			bottomShipAI.angle = 180f;
			bottomShipAI.speed = 2.5f;
			bottomShipAI.fireRate = 1.6f;
			bottomShipAI.bulletSpeed = 2.3f;
			bottomShipAI.hits = 2;
			bottomShipAI.lifeTime = 4f;
			bottomShip.GetComponent<Scroll> ().speed = 1;
			bottomShip = Instantiate (bottomShip);

		} else {

			//top tank
			GameObject topTank = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			topTank.transform.position = new Vector3 (10.0f, 2f, 0f);

			EnemyBehavior topTankBehavior = topTank.GetComponent<EnemyBehavior> ();
			topTankBehavior.bulletPool = bulletPool;

			EnemyAI5 topTankAI = topTank.GetComponent<EnemyAI5> ();
			topTankAI.direction = EnemyAI5.TankDir.Left;

			topTank = Instantiate (topTank);



			//bottom tank
			GameObject bottomTank = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			bottomTank.transform.position = new Vector3 (10.0f, -2f, 0f);

			EnemyBehavior bottomTankBehavior = topTank.GetComponent<EnemyBehavior> ();
			bottomTankBehavior.bulletPool = bulletPool;

			EnemyAI5 bottomTankAI = topTank.GetComponent<EnemyAI5> ();
			bottomTankAI.direction = EnemyAI5.TankDir.Left;

			bottomTank = Instantiate (bottomTank);
		}

	}
}
