using UnityEngine;
using System.Collections;

public class EnemySpawnLevel1IntroPart2 : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public override void Spawn ()
	{

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (8.5f, 3.3f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBullets = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/TurretEnemyLevel1");
			enemy.transform.position = new Vector3 (8.5f, -3.3f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBullets = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemy = Instantiate (enemy);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (14.0f, 0.0f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBullets = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai = enemy.GetComponent<EnemyAIShipArc> ();
			enemy = Instantiate (enemy);
		}

		EnemyAIShipArc.MoveInstruction moveLeft = new EnemyAIShipArc.MoveInstruction();
		moveLeft.type = EnemyBehavior.MovementStatus.Velocity;
		moveLeft.startVelocity = new Vector2 (-2f, 0f);
		moveLeft.time = 20f;


		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (23.0f, 2.0f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBullets = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai = enemy.GetComponent<EnemyAIShipArc> ();
			ai.MoveInstructionList.Clear ();
			ai.MoveInstructionList.Add (moveLeft);
			enemy = Instantiate (enemy);
		}


		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector3 (19.0f, -2.0f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBullets = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc ai = enemy.GetComponent<EnemyAIShipArc> ();
			ai.MoveInstructionList.Clear ();
			ai.MoveInstructionList.Add (moveLeft);
			enemy = Instantiate (enemy);
		}

	}
}
