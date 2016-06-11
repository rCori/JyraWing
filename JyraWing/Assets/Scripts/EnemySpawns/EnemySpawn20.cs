using UnityEngine;
using System.Collections;

public class EnemySpawn20 : EnemySpawner {

	public int diamondHealth;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();



		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_B");
		enemy2.transform.position = new Vector3(20.0f, -1.5f,0f);

		EnemyBehavior enemyBehavior2 = enemy2.GetComponent<EnemyBehavior> ();
		enemyBehavior2.bulletPool = bulletPool;
		enemyBehavior2.LeftWallException = false; 

		enemy2 = Instantiate (enemy2);
		enemy2.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		GameObject enemy3 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_B");
		enemy3.transform.position = new Vector3(21.0f, -0.5f,0f);
		
		EnemyBehavior enemyBehavior3 = enemy3.GetComponent<EnemyBehavior> ();
		enemyBehavior3.bulletPool = bulletPool;
		enemyBehavior3.LeftWallException = false; 
		
		enemy3 = Instantiate (enemy3);
		enemy3.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		GameObject enemy4 = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_B");
		enemy4.transform.position = new Vector3(22.0f, 0.5f,0f);
		
		EnemyBehavior enemyBehavior4 = enemy4.GetComponent<EnemyBehavior> ();
		enemyBehavior4.bulletPool = bulletPool;
		enemyBehavior4.LeftWallException = false; 
		
		enemy4 = Instantiate (enemy4);
		enemy4.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);




		GameObject enemy5 = (GameObject) Resources.Load ("Enemies/Enemy_B");
		enemy5.transform.position = new Vector3(23.0f, 1.5f,0f);
		
		EnemyBehavior enemyBehavior5 = enemy5.GetComponent<EnemyBehavior> ();
		enemyBehavior5.bulletPool = bulletPool;
		enemyBehavior5.LeftWallException = false; 
		
		enemy5 = Instantiate (enemy5);
		enemy5.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);




		GameObject enemy6 = (GameObject) Resources.Load ("Enemies/Enemy_B");
		enemy6.transform.position = new Vector3(24.5f, -1.5f,0f);
		
		EnemyBehavior enemyBehavior6 = enemy6.GetComponent<EnemyBehavior> ();
		enemyBehavior6.bulletPool = bulletPool;
		enemyBehavior6.LeftWallException = false; 
		
		enemy6 = Instantiate (enemy6);
		enemy6.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		GameObject enemy7 = (GameObject) Resources.Load ("Enemies/Enemy_B");
		enemy7.transform.position = new Vector3(25.0f, -0.5f,0f);
		
		EnemyBehavior enemyBehavior7 = enemy7.GetComponent<EnemyBehavior> ();
		enemyBehavior7.bulletPool = bulletPool;
		enemyBehavior7.LeftWallException = false; 
		
		enemy7 = Instantiate (enemy7);
		enemy7.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		GameObject enemy8 = (GameObject) Resources.Load ("Enemies/Enemy_B");
		enemy8.transform.position = new Vector3(26.0f, 0.5f,0f);
		
		EnemyBehavior enemyBehavior8 = enemy8.GetComponent<EnemyBehavior> ();
		enemyBehavior8.bulletPool = bulletPool;
		enemyBehavior8.LeftWallException = false; 
		
		enemy8 = Instantiate (enemy8);
		enemy8.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		GameObject enemy9 = (GameObject) Resources.Load ("Enemies/Enemy_B");
		enemy9.transform.position = new Vector3(27.5f, 1.5f,0f);
		
		EnemyBehavior enemyBehavior9 = enemy9.GetComponent<EnemyBehavior> ();
		enemyBehavior9.bulletPool = bulletPool;
		enemyBehavior9.LeftWallException = false; 
		
		enemy9 = Instantiate (enemy9);
		enemy9.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);



		GameObject enemy10 = (GameObject) Resources.Load ("Enemies/Enemy_B");
		enemy9.transform.position = new Vector3(28.5f, 0.0f,0f);
		
		EnemyBehavior enemyBehavior10 = enemy10.GetComponent<EnemyBehavior> ();
		enemyBehavior10.bulletPool = bulletPool;
		enemyBehavior10.LeftWallException = false; 
		
		enemy10 = Instantiate (enemy10);
		enemy10.GetComponent<EnemyBehavior> ().SetEnemyHealth (diamondHealth);

	}
}
