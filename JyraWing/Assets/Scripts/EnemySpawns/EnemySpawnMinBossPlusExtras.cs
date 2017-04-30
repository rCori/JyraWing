using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnMinBossPlusExtras : EnemySpawner {

	public bool turrets = false;
	public bool sprayer = false;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BossEnemies/Enemy_MiniBoss1");
			enemy.transform.position = new Vector3 (9.0f, 0f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.LeftWallException = false;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;

			EnemyAIMiniBoss1 enemyAI = enemy.GetComponent<EnemyAIMiniBoss1> ();
			enemyAI.bulletSpeed = 3.5f;
			enemyAI.shotTime = 0.5f;
			enemyAI.health = 40;
			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
		if (turrets) {
			
			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
				enemy.transform.position = new Vector3 (9.0f, 2.5f, 0f);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = false;

				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}

			{
				GameObject enemy = (GameObject)Resources.Load ("Enemies/TurretEnemies/Enemy_WaterTurretLevel1");
				enemy.transform.position = new Vector3 (9.0f, -2.5f, 0f);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = false;

				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}

		if (sprayer) {
			{
				GameObject sprayerEnemy = (GameObject)Resources.Load ("Enemies/ReflectorEnemies/Enemy_ReflectBulletSprayerArc");
				sprayerEnemy.transform.position = new Vector3 (11.0f, 0f, 0f);

				EnemyBehavior enemyBehavior = sprayerEnemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
                enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = false;

				sprayerEnemy = Instantiate (sprayerEnemy);

				EnemyAIReflectBulletSprayerArc enemyAI = sprayerEnemy.GetComponent<EnemyAIReflectBulletSprayerArc> ();
                enemyAI.MoveInstructionList.Clear();

                List<EnemyAIReflectBulletSprayerArc.MoveInstruction> moveInstructions = new List<EnemyAIReflectBulletSprayerArc.MoveInstruction>();

                for(int i = 0; i < 4; i++) {
                    EnemyAIReflectBulletSprayerArc.MoveInstruction moveInstruction = new EnemyAIReflectBulletSprayerArc.MoveInstruction();
                    moveInstruction.type = EnemyBehavior.MovementStatus.Lerp;
                    switch(i) {
                    case 0:
                        moveInstruction.startVelocity = new Vector2(9.0f, 3.0f);
                        moveInstruction.time = 1.5f;
                        break;
                    case 1:
                        moveInstruction.startVelocity = new Vector2(-6.0f, 3.0f);
                        moveInstruction.time = 3.0f;
                        break;
                    case 2:
                        moveInstruction.startVelocity = new Vector2(-6.0f, -3.0f);
                        moveInstruction.time = 2.5f;
                        break;
                    case 3:
                        moveInstruction.startVelocity = new Vector2(9.0f, -3.0f);
                        moveInstruction.time = 3.5f;
                        break;
                    default:
                        break;
                    }
                    moveInstructions.Add(moveInstruction);
                }

                enemyAI.MoveInstructionList = moveInstructions;

                sprayerEnemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}
	}
}
