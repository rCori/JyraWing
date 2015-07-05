using UnityEngine;
using System.Collections;

public class EnemySpawn8 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();
		
		//bottom left
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy1.transform.position = new Vector3 (-4.0f, -4.0f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai1 = enemy1.GetComponent<EnemyAI6> ();
		ai1.angle = 45f;
		ai1.speed = 2f;
		ai1.lifeTime = 5.0f;
		ai1.fireRate = 1.2f;
		ai1.bulletSpeed = 3f;
		enemy1.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy1);

		//top left
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy2.transform.position = new Vector3 (-4.0f, 4.0f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai2 = enemy2.GetComponent<EnemyAI6> ();
		ai2.angle = 315f;
		ai2.speed = 2f;
		ai2.lifeTime = 5.0f;
		ai2.fireRate = 1.2f;
		ai2.bulletSpeed = 3f;
		enemy2.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy2);

		//bottom right
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy3.transform.position = new Vector3 (4.0f, -4.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai3 = enemy3.GetComponent<EnemyAI6> ();
		ai3.angle = 135f;
		ai3.speed = 2f;
		ai3.lifeTime = 5.0f;
		ai3.fireRate = 1.2f;
		ai3.bulletSpeed = 3f;
		enemy3.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy3);

		//top right
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy4.transform.position = new Vector3 (4.0f, 4.0f, 0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai4 = enemy4.GetComponent<EnemyAI6> ();
		ai4.angle = 225f;
		ai4.speed = 2f;
		ai4.lifeTime = 5.0f;
		ai4.fireRate = 1.2f;
		ai4.bulletSpeed = 3f;
		enemy4.GetComponent<Scroll> ().speed = 0;
		Instantiate (enemy4);
	}
}
