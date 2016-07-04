﻿using UnityEngine;
using System.Collections;

public class EnemySpawnLevel1IntroPart2 : EnemySpawner {

	public int turretHealth;
	public int shipHealth;

	public override void Spawn ()
	{

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy1.transform.position = new Vector3 (8.5f, 3.3f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1 = Instantiate (enemy1);


		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
		enemy2.transform.position = new Vector3 (8.5f, -3.3f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2 = Instantiate (enemy2);


		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy3.transform.position = new Vector3 (14.0f, 0.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAIShipArc ai3 = enemy3.GetComponent<EnemyAIShipArc> ();
		enemy3.GetComponent<Scroll> ().speed = 0;
		enemy3 = Instantiate (enemy3);

		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy4.transform.position = new Vector3 (23.0f, 2.0f, 0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy4.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAIShipArc ai4 = enemy4.GetComponent<EnemyAIShipArc> ();
		enemy4.GetComponent<Scroll> ().speed = 0;
		enemy4 = Instantiate (enemy4);

		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy5.transform.position = new Vector3 (19.0f, -2.0f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAIShipArc ai5 = enemy5.GetComponent<EnemyAIShipArc> ();
		enemy5.GetComponent<Scroll> ().speed = 0;
		enemy5 = Instantiate (enemy5);

		//GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
		GameController controller = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController();

		//PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
		PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());

		group.SetPowerupType (PowerupGroup.PowerupType.Speed);

		group.AddToSquad (enemy3);
		group.AddToSquad (enemy4);
		group.AddToSquad (enemy5);
		
		//controller.AddSquad (group);
		controller.AddSquad (group);

	}
}
