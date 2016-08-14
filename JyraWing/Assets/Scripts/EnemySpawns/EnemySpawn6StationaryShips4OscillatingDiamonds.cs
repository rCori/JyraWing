using UnityEngine;
using System.Collections;

public class EnemySpawn6StationaryShips4OscillatingDiamonds : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{

		//first diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (4.0f, -4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, 4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;
			enemy = Instantiate (enemy);
		}

		//second diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (8.0f, 4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, -4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;
			enemy = Instantiate (enemy);
		}

	
		//third diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (12.0f, -4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, 4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;
			enemy = Instantiate (enemy);
		}


		//fourth diamond
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
			enemy.transform.position = new Vector3 (16.0f, 4.5f, 0f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBullets = false;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
			enemyAI.direction = new Vector2 (0f, -4f);
			enemyAI.time = 1.5f;
			enemyAI.repeat = true;
			enemy = Instantiate (enemy);
		}


		//First ship enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (8.0f, 0.0f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai5 = enemy.GetComponent<EnemyAIShipArc> ();
			enemy = Instantiate (enemy);
			enemyBehavior.shieldableBullets = true;
		}


		//Second ship enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (11.0f, 0.0f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai = enemy.GetComponent<EnemyAIShipArc> ();
			enemy = Instantiate (enemy);
			enemyBehavior.shieldableBullets = true;
		}


		//First ship enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (8.0f, 2.5f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai7 = enemy.GetComponent<EnemyAIShipArc> ();
			enemy = Instantiate (enemy);
			enemyBehavior.shieldableBullets = true;
		}

		
		//Second ship enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (11.0f, 2.5f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai8 = enemy.GetComponent<EnemyAIShipArc> ();
			enemy = Instantiate (enemy);
			enemyBehavior.shieldableBullets = true;
		}


		//First ship enemy
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (8.0f, -2.5f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai9 = enemy.GetComponent<EnemyAIShipArc> ();
			enemy = Instantiate (enemy);
			enemyBehavior.shieldableBullets = true;
		}


		
		//Second ship enemy
		{
			GameObject enemy10 = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy10.transform.position = new Vector3 (11.0f, -2.5f, 0f);
			EnemyBehavior enemyBehavior10 = enemy10.GetComponent<EnemyBehavior> ();
			enemyBehavior10.bulletPool = bulletPool;
			enemyBehavior10.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior10.pointIconPool = pointIconPool;
			enemyBehavior10.LeftWallException = true;
			EnemyAIShipArc ai10 = enemy10.GetComponent<EnemyAIShipArc> ();
			enemy10 = Instantiate (enemy10);
			enemyBehavior10.shieldableBullets = true;
		}
	}
}
