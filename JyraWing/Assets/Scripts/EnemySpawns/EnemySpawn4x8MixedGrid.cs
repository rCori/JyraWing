using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn4x8MixedGrid : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	private int rows = 4;
	private int columns = 8;

	private Vector2 enemyDirection = new Vector2 (-1.0f, 0.0f);
	private float enemyTime = 10f;

	private float enemySpeed = 2f;


	private float xOffset = 8f;
	private float yOffset = -2f;
	private float rowSpacing = 1f;
	private float columnSpacing = 1f;

	// Use this for initialization
	public override void Spawn () {
	
		EnemyAITypeBFighter.MoveInstruction left = new EnemyAITypeBFighter.MoveInstruction();
		left.type = EnemyBehavior.MovementStatus.Velocity;
		left.startVelocity = enemyDirection * (enemySpeed+1);
		left.time = enemyTime;

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {

				if (j == 2) {
					GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_BasicEnemyShip");
					enemy.transform.position = new Vector2 (xOffset + j * rowSpacing, yOffset + i * columnSpacing);

					EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
					enemyBehavior.bulletPool = bulletPool;
					enemyBehavior.shieldableBulletPool = shieldableBulletPool;
					enemyBehavior.pointIconPool = pointIconPool;
					enemyBehavior.LeftWallException = true;
					enemyBehavior.shieldableBullets = false;

					EnemyAIBasicShip ai = enemy.GetComponent<EnemyAIBasicShip> ();
					ai.angle = 180;
					ai.speed = enemySpeed;
					ai.lifeTime = enemyTime;
					ai.shootInDirection = true;
					enemy.GetComponent<Scroll> ().speed = 1;
					enemy = Instantiate (enemy);
                    enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
				} else if (j==5 || j == 7) {
					float xLoc = xOffset + j * rowSpacing;
					float yLoc = yOffset + i * columnSpacing;
					//Middle row
					GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
					enemy.transform.position = new Vector2 (xLoc, yLoc);

					EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
					enemyBehavior.bulletPool = bulletPool;
					enemyBehavior.shieldableBulletPool = shieldableBulletPool;
					enemyBehavior.LeftWallException = true;
					enemyBehavior.pointIconPool = pointIconPool;

					EnemyAITypeBFighter ai = enemy.GetComponent<EnemyAITypeBFighter> ();

					ai.MoveInstructionList.Clear ();
					ai.MoveInstructionList.Add (left);
					enemy = Instantiate (enemy);
                    enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
				} else {
					GameObject enemy = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
					enemy.transform.position = new Vector2 (xOffset + j*rowSpacing, yOffset + i*columnSpacing);

					EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
					enemyBehavior.pointIconPool = pointIconPool;

					EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
					enemyAI.direction = enemyDirection*enemySpeed;
					enemyAI.time = enemyTime;
					enemyAI.repeat = false;

					enemy = Instantiate (enemy);
                    enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
				}
			}
		}

	}

}
