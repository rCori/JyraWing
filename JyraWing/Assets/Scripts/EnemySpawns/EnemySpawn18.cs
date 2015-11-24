using UnityEngine;
using System.Collections;

public class EnemySpawn18 : EnemySpawner {

	public int diamondHealth;
	public int shipHealth;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		//first diamond
		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy1.transform.position = new Vector3(4.0f, -4.5f,0f);
		
		EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior1.bulletPool = bulletPool;
		enemyBehavior1.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior1.shieldableBullets = false;
		enemyBehavior1.LeftWallException = false;
		
		EnemyAI8 enemyAI1 = enemy1.GetComponent<EnemyAI8> ();
		enemyAI1.direction = new Vector2 (0f, 4f);
		enemyAI1.time = 1.5f;
		enemyAI1.repeat = true;
		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);


		//second diamond
		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy2.transform.position = new Vector3(8.0f, 4.5f,0f);
		
		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		enemyBehavior2.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior2.shieldableBullets = false;
		enemyBehavior2.LeftWallException = false;
		
		EnemyAI8 enemyAI2 = enemy2.GetComponent<EnemyAI8> ();
		enemyAI2.direction = new Vector2 (0f, -4f);
		enemyAI2.time = 1.5f;
		enemyAI2.repeat = true;
		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);


	
		//third diamond
		GameObject enemy3 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy3.transform.position = new Vector3(12.0f, -4.5f,0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;
		enemyBehavior3.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior3.shieldableBullets = false;
		enemyBehavior3.LeftWallException = false;
		
		EnemyAI8 enemyAI3 = enemy3.GetComponent<EnemyAI8> ();
		enemyAI3.direction = new Vector2 (0f, 4f);
		enemyAI3.time = 1.5f;
		enemyAI3.repeat = true;
		enemy3 = Instantiate (enemy3);
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		//fourth diamond
		GameObject enemy4 = (GameObject) Resources.Load ("Enemies/Enemy_H");
		enemy4.transform.position = new Vector3(16.0f, 4.5f,0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;
		enemyBehavior4.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior4.shieldableBullets = false;
		enemyBehavior4.LeftWallException = false;
		
		EnemyAI8 enemyAI4 = enemy4.GetComponent<EnemyAI8> ();
		enemyAI4.direction = new Vector2 (0f, -4f);
		enemyAI4.time = 1.5f;
		enemyAI4.repeat = true;
		enemy4 = Instantiate (enemy4);
		enemy4.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		//First ship enemy
		GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy5.transform.position = new Vector3 (8.0f, 0.0f, 0f);
		enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy5.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy5.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai5 = enemy5.GetComponent<EnemyAI6> ();
		ai5.angle = 180f;
		ai5.speed = 1.0f;
		ai5.lifeTime = 30.0f;
		ai5.fireRate = 2.5f;
		ai5.bulletSpeed = 6f;
		ai5.hits = shipHealth;
		enemy5.GetComponent<Scroll> ().speed = 0;
		enemy5 = Instantiate (enemy5);
		enemy5.GetComponent<EnemyBehavior> ().shieldableBullets = true;

		//Second ship enemy
		GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy6.transform.position = new Vector3 (11.0f, 0.0f, 0f);
		enemy6.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy6.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy6.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai6 = enemy6.GetComponent<EnemyAI6> ();
		ai6.angle = 180f;
		ai6.speed = 1.0f;
		ai6.lifeTime = 30.0f;
		ai6.fireRate = 2.5f;
		ai6.bulletSpeed = 6f;
		ai6.hits = shipHealth;
		enemy6.GetComponent<Scroll> ().speed = 0;
		enemy6 = Instantiate (enemy6);
		enemy6.GetComponent<EnemyBehavior> ().shieldableBullets = true;


		//First ship enemy
		GameObject enemy7 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy7.transform.position = new Vector3 (8.0f, 2.5f, 0f);
		enemy7.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy7.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy7.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai7 = enemy7.GetComponent<EnemyAI6> ();
		ai7.angle = 180f;
		ai7.speed = 1.0f;
		ai7.lifeTime = 30.0f;
		ai7.fireRate = 2.5f;
		ai7.bulletSpeed = 6f;
		ai7.hits = shipHealth;
		enemy7.GetComponent<Scroll> ().speed = 0;
		enemy7 = Instantiate (enemy7);
		enemy7.GetComponent<EnemyBehavior> ().shieldableBullets = false;

		
		//Second ship enemy
		GameObject enemy8 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy8.transform.position = new Vector3 (11.0f, 2.5f, 0f);
		enemy8.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy8.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy8.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai8 = enemy8.GetComponent<EnemyAI6> ();
		ai8.angle = 180f;
		ai8.speed = 1.0f;
		ai8.lifeTime = 30.0f;
		ai8.fireRate = 2.5f;
		ai8.bulletSpeed = 6f;
		ai8.hits = shipHealth;
		enemy8.GetComponent<Scroll> ().speed = 0;
		enemy8 = Instantiate (enemy8);
		enemy8.GetComponent<EnemyBehavior> ().shieldableBullets = false;


		//First ship enemy
		GameObject enemy9 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy9.transform.position = new Vector3 (8.0f, -2.5f, 0f);
		enemy9.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy9.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy9.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai9 = enemy9.GetComponent<EnemyAI6> ();
		ai9.angle = 180f;
		ai9.speed = 1.0f;
		ai9.lifeTime = 30.0f;
		ai9.fireRate = 2.5f;
		ai9.bulletSpeed = 6f;
		ai9.hits = shipHealth;
		enemy9.GetComponent<Scroll> ().speed = 0;
		enemy9 = Instantiate (enemy9);
		enemy9.GetComponent<EnemyBehavior> ().shieldableBullets = false;

		
		//Second ship enemy
		GameObject enemy10 = (GameObject)Resources.Load ("Enemies/Enemy_F");
		enemy10.transform.position = new Vector3 (11.0f, -2.5f, 0f);
		enemy10.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy10.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy10.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAI6 ai10 = enemy10.GetComponent<EnemyAI6> ();
		ai10.angle = 180f;
		ai10.speed = 1.0f;
		ai10.lifeTime = 30.0f;
		ai10.fireRate = 2.5f;
		ai10.bulletSpeed = 6f;
		ai10.hits = shipHealth;
		enemy10.GetComponent<Scroll> ().speed = 0;
		enemy10 = Instantiate (enemy10);
		enemy10.GetComponent<EnemyBehavior> ().shieldableBullets = false;
	}
}
