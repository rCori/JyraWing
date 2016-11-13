﻿using UnityEngine;
using System.Collections;

public class EnemySpawnTwoWaterTurrets : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn(){
		/* second turret */
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			enemy.transform.position = new Vector2 (9f, 2f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;

			EnemyAIWaterTurret enemyAI = enemy.GetComponent<EnemyAIWaterTurret> ();
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
		/* bottom turret */
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
			enemy.transform.position = new Vector2 (9f, -2f);
		
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = false;

			EnemyAIWaterTurret enemyAI = enemy.GetComponent<EnemyAIWaterTurret> ();
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
	}
}
