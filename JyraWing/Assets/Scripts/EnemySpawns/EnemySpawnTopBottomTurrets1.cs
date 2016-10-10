using UnityEngine;
using System.Collections;

public class EnemySpawnTopBottomTurrets : EnemySpawner {

	public bool top;
	public bool bottom;

	public bool shieldableBullets;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		if (top) {
			//top
			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
				enemy.transform.position = new Vector3 (5.5f, 3.7f, 0f);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}

			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
				enemy.transform.position = new Vector3 (8.5f, 3.7f, 0f);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}

			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
				enemy.transform.position = new Vector3 (11.5f, 3.7f, 0f);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}

		if (bottom) {
			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
				enemy.transform.position = new Vector3 (5.5f, -3.7f, 0f);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}

			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
				enemy.transform.position = new Vector3 (8.5f, -3.7f, 0f);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}

			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_BoxTurret");
				enemy.transform.position = new Vector3 (11.5f, -3.7f, 0f);
				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}

	}
}
