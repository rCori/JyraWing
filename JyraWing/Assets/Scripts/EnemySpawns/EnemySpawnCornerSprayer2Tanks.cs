﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnCornerSprayer2Tanks : EnemySpawner {

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


		if (ships) {
			//Ship coming through from the top
			GameObject topShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			topShip.transform.position = new Vector3 (6.0f, 3.0f,0.0f);

			topShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			topShip.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

			topShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
			topShip.GetComponent<EnemyBehavior> ().shieldableBullets = false;
			EnemyAIShipArc topShipAI = topShip.GetComponent<EnemyAIShipArc> ();
			topShip.GetComponent<Scroll> ().speed = 1;
			topShip = Instantiate (topShip);

			//Ship coming through from the top
			GameObject bottomShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			bottomShip.transform.position = new Vector3 (6.0f, -3.0f,0.0f);

			bottomShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			bottomShip.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

			bottomShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
			bottomShip.GetComponent<EnemyBehavior> ().shieldableBullets = false;
			EnemyAIShipArc bottomShipAI = topShip.GetComponent<EnemyAIShipArc> ();
			bottomShip.GetComponent<Scroll> ().speed = 1;
			bottomShip = Instantiate (bottomShip);

		} else {

			//top tank
			GameObject topTank = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			topTank.transform.position = new Vector3 (10.0f, 2f, 0f);

			EnemyBehavior topTankBehavior = topTank.GetComponent<EnemyBehavior> ();
			topTankBehavior.bulletPool = bulletPool;

			EnemyAITank topTankAI = topTank.GetComponent<EnemyAITank> ();
			topTankAI.direction = EnemyAITank.TankDir.Left;

			topTank = Instantiate (topTank);



			//bottom tank
			GameObject bottomTank = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
			bottomTank.transform.position = new Vector3 (10.0f, -2f, 0f);

			EnemyBehavior bottomTankBehavior = topTank.GetComponent<EnemyBehavior> ();
			bottomTankBehavior.bulletPool = bulletPool;

			EnemyAITank bottomTankAI = topTank.GetComponent<EnemyAITank> ();
			bottomTankAI.direction = EnemyAITank.TankDir.Left;

			bottomTank = Instantiate (bottomTank);
		}

	}
}
