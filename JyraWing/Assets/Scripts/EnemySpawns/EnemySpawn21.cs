﻿using UnityEngine;
using System.Collections;

public class EnemySpawn21 : EnemySpawner {
	

	public override void Spawn(){

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		//Middle tank
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy1.transform.position = new Vector3(10.0f, 0f,0f);
		
		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;

		EnemyAITank enemyAI1 = enemy1.GetComponent<EnemyAITank> ();
		enemyAI1.direction = EnemyAITank.TankDir.Left;
		
		enemy1 = Instantiate (enemy1);



		//Top tank
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy2.transform.position = new Vector3(10.0f, -2.0f,0f);

		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;

		EnemyAITank enemyAI2 = enemy2.GetComponent<EnemyAITank> ();
		enemyAI2.direction = EnemyAITank.TankDir.Left;
		
		enemy2 = Instantiate (enemy2);



		//Bottom tank
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy3.transform.position = new Vector3(10.0f, 2.0f,0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;

		EnemyAITank enemyAI3 = enemy3.GetComponent<EnemyAITank> ();
		enemyAI3.direction = EnemyAITank.TankDir.Left;
		
		enemy3 = Instantiate (enemy3);

		
		//GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
		GameController controller = GameObject.Find ("GameController").GetComponent<GameControllerBehaviour>().GetGameController();

		//hardcoding groupID, in the future I cannot do that.
		//PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
		PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());

		group.SetPowerupType (PowerupGroup.PowerupType.Speed);

		group.AddToSquad (enemy1);
		group.AddToSquad (enemy2);
		group.AddToSquad (enemy3);

		//controller.AddSquad (group);
		controller.AddSquad (group);
	}
}
