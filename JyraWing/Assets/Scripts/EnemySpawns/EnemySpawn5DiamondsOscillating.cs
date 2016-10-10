using UnityEngine;
using System.Collections;

public class EnemySpawn5DiamondsOscillating : EnemySpawner {

	public float VerticalShift;

	public PointIconPool pointIconPool;
	public EnemyBulletPool bulletPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn(){

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (6f,
				VerticalShift + 0.5f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

            EnemyAISimpleOscillate simpleOscillateAI = enemy.GetComponent<EnemyAISimpleOscillate>();

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy2 = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy2.transform.position = new Vector3 (7f,
				VerticalShift - 0.5f,
				0f);
			enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy2.GetComponent<EnemyBehavior> ().pointIconPool = pointIconPool;
            enemy2 = Instantiate(enemy2);
            enemy2.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);	
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (8f,
				VerticalShift + 0.5f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

            EnemyAISimpleOscillate simpleOscillateAI = enemy.GetComponent<EnemyAISimpleOscillate>();

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);		
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (9f,
				VerticalShift - 0.5f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

            EnemyAISimpleOscillate simpleOscillateAI = enemy.GetComponent<EnemyAISimpleOscillate>();

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillateFixed");
			enemy.transform.position = new Vector3 (10f,
				VerticalShift + 0.5f,
				0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

            EnemyAISimpleOscillate simpleOscillateAI = enemy.GetComponent<EnemyAISimpleOscillate>();

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


	}

}
