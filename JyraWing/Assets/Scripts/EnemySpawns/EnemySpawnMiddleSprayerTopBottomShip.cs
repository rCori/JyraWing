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
			GameObject enemyBulletSprayer = (GameObject)Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayerArc");
			enemyBulletSprayer.transform.position = new Vector3 (9.0f, 0.0f, 0.0f);

            EnemyAIReflectBulletSprayerArc.MoveInstruction leftMovement = new EnemyAIReflectBulletSprayerArc.MoveInstruction();
            leftMovement.startVelocity = new Vector2(-3.0f, 0f);
            leftMovement.type = EnemyBehavior.MovementStatus.Velocity;
            leftMovement.time = 6f;

			EnemyBehavior enemyBehavior = enemyBulletSprayer.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;

			EnemyAIReflectBulletSprayerArc enemyAI = enemyBulletSprayer.GetComponent<EnemyAIReflectBulletSprayerArc> ();
            enemyAI.MoveInstructionList.Clear();
            enemyAI.MoveInstructionList.Add(leftMovement);
            enemyBulletSprayer.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);

            enemyBulletSprayer = Instantiate (enemyBulletSprayer);
		}


		//Ship coming through from the top
		{
			GameObject topShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			topShip.transform.position = new Vector3 (9.0f, 2.0f, 0.0f);

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
			bottomShip.transform.position = new Vector3 (9.0f, -3.0f, 0.0f);

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
