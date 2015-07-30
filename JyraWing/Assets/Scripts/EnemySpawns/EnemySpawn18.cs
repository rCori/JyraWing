using UnityEngine;
using System.Collections;

public class EnemySpawn18 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();

		//first diamond
		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy1.transform.position = new Vector3(4.0f, -4.5f,0f);
		
		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		enemyBehavior1.LeftWallException = false;
		
		EnemyAI8 enemyAI1 = enemy1.GetComponent<EnemyAI8> ();
		enemyAI1.direction = new Vector2 (0f, 4f);
		enemyAI1.time = 1.5f;
		enemyAI1.repeat = true;
		enemy1 = Instantiate (enemy1);



		//second diamond
		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy2.transform.position = new Vector3(8.0f, 4.5f,0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		enemyBehavior2.LeftWallException = false;
		
		EnemyAI8 enemyAI2 = enemy2.GetComponent<EnemyAI8> ();
		enemyAI2.direction = new Vector2 (0f, -4f);
		enemyAI2.time = 1.5f;
		enemyAI2.repeat = true;
		enemy2 = Instantiate (enemy2);


	
		//third diamond
		GameObject enemy3 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy3.transform.position = new Vector3(12.0f, -4.5f,0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;
		enemyBehavior3.LeftWallException = false;
		
		EnemyAI8 enemyAI3 = enemy3.GetComponent<EnemyAI8> ();
		enemyAI3.direction = new Vector2 (0f, 4f);
		enemyAI3.time = 1.5f;
		enemyAI3.repeat = true;
		enemy3 = Instantiate (enemy3);



		//fourth diamond
		GameObject enemy4 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy4.transform.position = new Vector3(16.0f, 4.5f,0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;
		enemyBehavior4.LeftWallException = false;
		
		EnemyAI8 enemyAI4 = enemy4.GetComponent<EnemyAI8> ();
		enemyAI4.direction = new Vector2 (0f, -4f);
		enemyAI4.time = 1.5f;
		enemyAI4.repeat = true;
		enemy4 = Instantiate (enemy4);



		//First ship enemy
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy5.transform.position = new Vector3 (8.0f, 0.0f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai5 = enemy5.GetComponent<EnemyAI6> ();
		ai5.angle = 180f;
		ai5.speed = 0.5f;
		ai5.lifeTime = 40.0f;
		ai5.fireRate = 2.5f;
		ai5.bulletSpeed = 2f;
		ai5.hits = 5;
		enemy5.GetComponent<Scroll> ().speed = 0;
		enemy5 = Instantiate (enemy5);



		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy6.transform.position = new Vector3 (11.0f, 0.0f, 0f);
		enemy6.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy6.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai6 = enemy6.GetComponent<EnemyAI6> ();
		ai6.angle = 180f;
		ai6.speed = 0.5f;
		ai6.lifeTime = 40.0f;
		ai6.fireRate = 2.5f;
		ai6.bulletSpeed = 2f;
		ai6.hits = 5;
		enemy6.GetComponent<Scroll> ().speed = 0;
		enemy6 = Instantiate (enemy6);
	}
}
