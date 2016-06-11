﻿using UnityEngine;
using System.Collections;

public class EnemySpawnWaterTurret : EnemySpawner {

	public Vector2 enemyPosition;

	public int Health;

	public EnemyAIWaterTurret.FireDirection Direction;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();
		
		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
		enemy1.transform.position = enemyPosition;
		
		enemy1.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;

		enemy1.GetComponent<EnemyAIWaterTurret> ().fireDirection = Direction;
		enemy1 = Instantiate (enemy1);
	}
}
