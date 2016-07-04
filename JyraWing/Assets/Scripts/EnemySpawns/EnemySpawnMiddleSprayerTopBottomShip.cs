using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnMiddleSprayerTopBottomShip : EnemySpawner {

	// Use this for initialization
	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		//Bullet sprayer going right down the middle
		GameObject enemyBulletSprayer = (GameObject) Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayer");
		enemyBulletSprayer.transform.position = new Vector3 (6.0f, 0.0f,0.0f);

		enemyBulletSprayer.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemyBulletSprayer.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

		enemyBulletSprayer = Instantiate (enemyBulletSprayer);

		enemyBulletSprayer.GetComponent<EnemyBehavior>().SetEnemyHealth(3);
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().locations = new List<Vector2> {new Vector2(-6.0f, 0.0f)};
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().times = new List<float> {3.5f};



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



		//Ship coming through from the bottom
		GameObject bottomShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		bottomShip.transform.position = new Vector3 (6.0f, -3.0f,0.0f);

		bottomShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bottomShip.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

		bottomShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
		bottomShip.GetComponent<EnemyBehavior> ().shieldableBullets = false;
		EnemyAIShipArc bottomShipAI = bottomShip.GetComponent<EnemyAIShipArc> ();
		bottomShip.GetComponent<Scroll> ().speed = 1;
		bottomShip = Instantiate (bottomShip);
	}

}
