using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn25 : EnemySpawner {

	// Use this for initialization
	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		//Bullet sprayer going right down the middle
		GameObject enemyBulletSprayer = (GameObject) Resources.Load ("Enemies/Enemy_ReflectBulletSprayer");
		enemyBulletSprayer.transform.position = new Vector3 (6.0f, 0.0f,0.0f);

		enemyBulletSprayer.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemyBulletSprayer.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

		enemyBulletSprayer = Instantiate (enemyBulletSprayer);

		enemyBulletSprayer.GetComponent<EnemyBehavior>().SetEnemyHealth(3);
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().locations = new List<Vector2> {new Vector2(-6.0f, 0.0f)};
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().times = new List<float> {1.5f};

		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().fireRate = 0.2f;
		enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA>().bulletSpeed = 3.0f;



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



		//Ship coming through from the bottom
		GameObject bottomShip = (GameObject) Resources.Load("Enemies/Enemy_F");
		bottomShip.transform.position = new Vector3 (6.0f, -3.0f,0.0f);

		bottomShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		bottomShip.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

		bottomShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
		bottomShip.GetComponent<EnemyBehavior> ().shieldableBullets = false;
		EnemyAI6 bottomShipAI = bottomShip.GetComponent<EnemyAI6> ();
		bottomShipAI.angle = 180f;
		bottomShipAI.speed = 2.5f;
		bottomShipAI.fireRate = 1.2f;
		bottomShipAI.bulletSpeed = 2.3f;
		bottomShipAI.hits = 2;
		bottomShipAI.lifeTime = 4f;
		bottomShip.GetComponent<Scroll> ().speed = 1;
		bottomShip = Instantiate (bottomShip);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
