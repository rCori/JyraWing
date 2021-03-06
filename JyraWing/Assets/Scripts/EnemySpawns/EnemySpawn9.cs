﻿using UnityEngine;
using System.Collections;

public class EnemySpawn9 : EnemySpawner {

	public int enemyHitPoints;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		
		//mid-bot
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy1.transform.position = new Vector3 (6.0f, -1.5f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai1 = enemy1.GetComponent<EnemyAI6> ();
		ai1.angle = 155f;
		ai1.speed = 2.0f;
		ai1.lifeTime = 12.0f;
		ai1.fireRate = 1.2f;
		ai1.bulletSpeed = 3.5f;
		ai1.hits = enemyHitPoints;
		enemy1.GetComponent<Scroll> ().speed = 0;
		enemy1 = Instantiate (enemy1);
		
		//mid-top
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy2.transform.position = new Vector3 (6.0f, 1.5f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai2 = enemy2.GetComponent<EnemyAI6> ();
		ai2.angle = 205f;
		ai2.speed = 2f;
		ai2.lifeTime = 12.0f;
		ai2.fireRate = 1.2f;
		ai2.bulletSpeed = 3.5f;
		ai2.hits = enemyHitPoints;
		enemy2.GetComponent<Scroll> ().speed = 0;
		enemy2 = Instantiate (enemy2);
		
		//mid
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy3.transform.position = new Vector3 (6.0f, 0.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai3 = enemy3.GetComponent<EnemyAI6> ();
		ai3.angle = 180f;
		ai3.speed = 2f;
		ai3.lifeTime = 7.0f;
		ai3.fireRate = 1.2f;
		ai3.bulletSpeed = 3.5f;
		ai3.hits = enemyHitPoints;
		enemy3.GetComponent<Scroll> ().speed = 0;
		enemy3 = Instantiate (enemy3);


		//top
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy4.transform.position = new Vector3 (6.0f, 3.0f, 0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai4 = enemy4.GetComponent<EnemyAI6> ();
		ai4.angle = 180f;
		ai4.speed = 2f;
		ai4.lifeTime = 12.0f;
		ai4.fireRate = 1.2f;
		ai4.bulletSpeed = 3.5f;
		ai4.hits = enemyHitPoints;
		enemy4.GetComponent<Scroll> ().speed = 0;
		enemy4 = Instantiate (enemy4);		

		//bottom
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy5.transform.position = new Vector3 (6.0f, -3.0f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai5 = enemy5.GetComponent<EnemyAI6> ();
		ai5.angle = 180f;
		ai5.speed = 2f;
		ai5.lifeTime = 12.0f;
		ai5.fireRate = 1.2f;
		ai5.bulletSpeed = 3.5f;
		ai5.hits = enemyHitPoints;
		enemy5.GetComponent<Scroll> ().speed = 0;
		enemy5 = Instantiate (enemy5);	
		

	}
}
