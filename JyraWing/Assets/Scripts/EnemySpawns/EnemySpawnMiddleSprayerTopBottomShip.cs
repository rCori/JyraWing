using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnMiddleSprayerTopBottomShip : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	// Use this for initialization
	public override void Spawn(){
		{
			//Bullet sprayer going right down the middle
			GameObject enemyBulletSprayer = (GameObject)Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayer");
			enemyBulletSprayer.transform.position = new Vector3 (8.0f, 0.0f, 0.0f);

			EnemyBehavior enemyBehavior = enemyBulletSprayer.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBulletSprayer = Instantiate (enemyBulletSprayer);

			EnemyAIReflectBulletSprayerA enemyAI = enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerA> ();
			enemyAI.locations = new List<Vector2> { new Vector2 (-6.0f, 0.0f) };
			enemyAI.times = new List<float> { 3.5f };
            enemyBulletSprayer.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//Ship coming through from the top
		{
			GameObject topShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			topShip.transform.position = new Vector3 (8.0f, 3.0f, 0.0f);

			EnemyBehavior enemyBehavior = topShip.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemyBehavior.LeftWallException = true;
			enemyBehavior.shieldableBullets = false;
			EnemyAIShipArc topShipAI = topShip.GetComponent<EnemyAIShipArc> ();
			topShip = Instantiate (topShip);
            topShip.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		//Ship coming through from the bottom
		{
			GameObject bottomShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			bottomShip.transform.position = new Vector3 (8.0f, -3.0f, 0.0f);

			EnemyBehavior enemyBehavior = bottomShip.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			enemyBehavior.LeftWallException = true;
			enemyBehavior.shieldableBullets = false;
			EnemyAIShipArc bottomShipAI = bottomShip.GetComponent<EnemyAIShipArc> ();
			bottomShip = Instantiate (bottomShip);
            bottomShip.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
	}

}
