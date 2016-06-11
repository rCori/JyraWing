using UnityEngine;
using System.Collections;

public class EnemySpawn2 : EnemySpawner {

	public int shipHealth;

	public override void Spawn(){

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy1.transform.position = new Vector3 (10.0f, -2.5f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;
		EnemyAIShipArc ai1 = enemy1.GetComponent<EnemyAIShipArc> ();
		ai1.angle = 180f;
		ai1.speed = 2.0f;
		ai1.lifeTime = 9.0f;
		ai1.fireRate = 2.5f;
		ai1.bulletSpeed = 2.0f;
		ai1.hits = shipHealth;
		Instantiate (enemy1);
		
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy2.transform.position = new Vector3 (8.0f, -1.25f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2.GetComponent<EnemyBehavior> ().LeftWallException = false;
		EnemyAIShipArc ai2 = enemy2.GetComponent<EnemyAIShipArc> ();
		ai2.angle = 180f;
		ai2.speed = 2.0f;
		ai2.lifeTime = 9.0f;
		ai2.fireRate = 2.5f;
		ai2.bulletSpeed = 2.0f;
		ai2.hits = shipHealth;
		Instantiate (enemy2);	
		
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy3.transform.position = new Vector3 (10.0f, 0.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3.GetComponent<EnemyBehavior> ().LeftWallException = false;
		EnemyAIShipArc ai3 = enemy3.GetComponent<EnemyAIShipArc> ();
		ai3.angle = 180f;
		ai3.speed = 2.0f;
		ai3.lifeTime = 9.0f;
		ai3.fireRate = 2.5f;
		ai3.bulletSpeed = 2.0f;
		ai3.hits = shipHealth;
		Instantiate (enemy3);

		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy4.transform.position = new Vector3 (8.0f, 1.25f, 0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy4.GetComponent<EnemyBehavior> ().LeftWallException = false;
		EnemyAIShipArc ai4 = enemy4.GetComponent<EnemyAIShipArc> ();
		ai4.angle = 180f;
		ai4.speed = 2.0f;
		ai4.lifeTime = 9.0f;
		ai4.fireRate = 2.5f;
		ai4.bulletSpeed = 2.0f;
		ai4.hits = shipHealth;
		Instantiate (enemy4);

		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy5.transform.position = new Vector3 (10.0f, 2.5f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5.GetComponent<EnemyBehavior> ().LeftWallException = false;
		EnemyAIShipArc ai5 = enemy5.GetComponent<EnemyAIShipArc> ();
		ai5.angle = 180f;
		ai5.speed = 2.0f;
		ai5.lifeTime = 9.0f;
		ai5.fireRate = 2.5f;
		ai5.bulletSpeed = 2.0f;
		ai5.hits = shipHealth;
		Instantiate (enemy5);
		
	}
}
