﻿using UnityEngine;
using System.Collections;

public class BossNew2Spawn : EnemySpawner {

	public PointIconPool pointIconPool;
	public LevelControllerBehavior levelControllerBehavior;
	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;

	public override void Spawn(){

		Vector3 spawnPos = gameObject.transform.position;

		GameObject enemy = (GameObject) Resources.Load ("Enemies/BossEnemies/Enemy_NewBoss2");
		enemy.transform.position = new Vector3(4.0f,0f,0f);
		
		enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;

		enemy.GetComponent<EnemyAINewBoss2>().levelControllerBehavior = levelControllerBehavior;

		Instantiate (enemy);
	}
}
