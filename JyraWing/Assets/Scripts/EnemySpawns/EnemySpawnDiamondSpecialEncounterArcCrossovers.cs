using UnityEngine;
using System.Collections;

public class EnemySpawnDiamondSpecialEncounterArcCrossovers : EnemySpawner {

	public int EnemyHealth = 3;

	public float vertShift = 5;
	public float oscillation = -1.5f;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	// Use this for initialization
	public override void Spawn(){

		{
			//first enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, 5f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;

			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 0f;
			enemyAI.ySpeed = -2.0f;
			enemyAI.fireTimeLimit = 0.8f;
			enemy = Instantiate (enemy);
		}

		{
			//second enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, 5f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 1.0f;
			enemyAI.ySpeed = -2.0f;
			enemyAI.fireTimeLimit = 1.5f;
			enemy = Instantiate (enemy);
		}

		{
			//third enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, 5f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 2.0f;
			enemyAI.ySpeed = -2.0f;
			enemyAI.fireTimeLimit = 1.1f;
			enemy = Instantiate (enemy);
		}

		{
			//second enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, 5f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;
		
			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 3.0f;
			enemyAI.ySpeed = -2.0f;
			enemyAI.fireTimeLimit = 0.9f;
			enemy = Instantiate (enemy);
		}

		{
			//second enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, -5f);
			
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;
			
			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 0.5f;
			enemyAI.ySpeed = 2.0f;
			enemyAI.fireTimeLimit = 1.8f;
			enemy = Instantiate (enemy);
		}

		{
			//second enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, -5f);
			
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;
			
			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 1.5f;
			enemyAI.ySpeed = 2.0f;
			enemyAI.fireTimeLimit = 1.8f;
			enemy = Instantiate (enemy);
		}

		{
			//second enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, -5f);
			
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;
			
			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 2.5f;
			enemyAI.ySpeed = 2.0f;
			enemyAI.fireTimeLimit = 1.3f;
			enemy = Instantiate (enemy);
		}

		{
			//second enemy from the bottom
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondSpecialEncounterArcCrossover");
			enemy.transform.position = new Vector2 (vertShift, -5f);
			
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;
			
			EnemyAIDiamondSpecialEncounterArcCrossovers enemyAI = enemy.GetComponent<EnemyAIDiamondSpecialEncounterArcCrossovers> ();
			enemyAI.oscillationFactor = oscillation;
			enemyAI.delayTimer = 3.5f;
			enemyAI.ySpeed = 2.0f;
			enemyAI.fireTimeLimit = 1.0f;
			enemy = Instantiate (enemy);
		}


	}

}
