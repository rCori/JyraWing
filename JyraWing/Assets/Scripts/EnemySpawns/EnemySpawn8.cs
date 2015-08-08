﻿using UnityEngine;
using System.Collections;

public class EnemySpawn8 : EnemySpawner {

	public int enemyHitPoints;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		
		//bottom left
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy1.transform.position = new Vector3 (-6.0f, -4.0f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai1 = enemy1.GetComponent<EnemyAI6> ();
		ai1.angle = 45f;
		ai1.speed = 1.5f;
		ai1.lifeTime = 10.0f;
		ai1.fireRate = 1.2f;
		ai1.bulletSpeed = 3f;
		ai1.hits = enemyHitPoints;
		enemy1.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy1);

		//top left
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy2.transform.position = new Vector3 (-6.0f, 4.0f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai2 = enemy2.GetComponent<EnemyAI6> ();
		ai2.angle = 315f;
		ai2.speed = 1.5f;
		ai2.lifeTime = 10.0f;
		ai2.fireRate = 1.2f;
		ai2.bulletSpeed = 3f;
		ai2.hits = enemyHitPoints;
		enemy2.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy2);

		//bottom right
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy3.transform.position = new Vector3 (6.0f, -4.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai3 = enemy3.GetComponent<EnemyAI6> ();
		ai3.angle = 135f;
		ai3.speed = 1.5f;
		ai3.lifeTime = 10.0f;
		ai3.fireRate = 1.2f;
		ai3.bulletSpeed = 3f;
		ai3.hits = enemyHitPoints;
		enemy3.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy3);

		//top right
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy4.transform.position = new Vector3 (6.0f, 4.0f, 0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai4 = enemy4.GetComponent<EnemyAI6> ();
		ai4.angle = 225f;
		ai4.speed = 1.5f;
		ai4.lifeTime = 10.0f;
		ai4.fireRate = 1.2f;
		ai4.bulletSpeed = 3f;
		ai4.hits = enemyHitPoints;
		enemy4.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy4);

		//top 
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy5.transform.position = new Vector3 (0.0f, 5.0f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai5 = enemy4.GetComponent<EnemyAI6> ();
		ai5.angle = 270f;
		ai5.speed = 1.5f;
		ai5.lifeTime = 10.0f;
		ai5.fireRate = 1.2f;
		ai5.bulletSpeed = 3f;
		ai5.hits = enemyHitPoints;
		enemy5.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy5);
		//top 
		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy6.transform.position = new Vector3 (0.0f, -5.0f, 0f);
		enemy6.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai6 = enemy4.GetComponent<EnemyAI6> ();
		ai6.angle = 90f;
		ai6.speed = 1.5f;
		ai6.lifeTime = 10.0f;
		ai6.fireRate = 1.2f;
		ai6.bulletSpeed = 3f;
		ai6.hits = enemyHitPoints;
		enemy6.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy6);
	}
}
