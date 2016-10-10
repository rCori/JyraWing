using UnityEngine;
using System.Collections;

public class EnemySpawn6DiamondsIncoming : EnemySpawner
{

    public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

    public override void Spawn() {

        GameObject enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
        EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate>();
        EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
        enemyBehavior.pointIconPool = pointIconPool;

        float speed = 3.5f;

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(8f, 2f);
            enemyAI.direction = new Vector2(-7f, -2f).normalized*speed;
            enemyAI.time = 5f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(8f, -2f);
            enemyAI.direction = new Vector2(-7f, 2f).normalized * speed;
            enemyAI.time = 5f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(9f, 2.25f);
            enemyAI.direction = new Vector2(-7f, -2f).normalized * speed;
            enemyAI.time = 5f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(9f, -2.25f);
            enemyAI.direction = new Vector2(-7f, 2f).normalized * speed;
            enemyAI.time = 5f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }




        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(12f, -8f);
            enemyAI.direction = new Vector2(-10f, 8f).normalized* speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(12f, 8f);
            enemyAI.direction = new Vector2(-10f, -8f).normalized* speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(13.5f, -9.125f);
            enemyAI.direction = new Vector2(-10f, 8f).normalized * speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(13.5f, 9.125f);
            enemyAI.direction = new Vector2(-10f, -8f).normalized * speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }



        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(17f, -14.0f);
            enemyAI.direction = new Vector2(-12f, 14f).normalized * speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(17f, 14.0f);
            enemyAI.direction = new Vector2(-12f, -14f).normalized * speed;
            enemyAI.time = 12f;
            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(18f, -15.75f);
            enemyAI.direction = new Vector2(-12f, 14f).normalized* speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(18f, 15.75f);
            enemyAI.direction = new Vector2(-12f, -14f).normalized* speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }



        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(20f, -20f);
            enemyAI.direction = new Vector2(-14f, 20f).normalized * speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(20f, 20f);
            enemyAI.direction = new Vector2(-14f, -20f).normalized * speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(22f, -22f);
            enemyAI.direction = new Vector2(-14f, 20f).normalized * speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
            enemy.transform.position = new Vector2(22f, 22f);
            enemyAI.direction = new Vector2(-14f, -20f).normalized * speed;
            enemyAI.time = 12f;

            enemy = Instantiate(enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

    }
	
}
