using UnityEngine;
using System.Collections;

public class Boss2Spawn : EnemySpawner {

	public PointIconPool pointIconPool;
	public LevelControllerBehavior levelControllerBehavior;
	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn(){

		Vector3 spawnPos = gameObject.transform.position;

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/BossEnemies/Enemy_Boss2");
		enemy1.transform.position = new Vector3(spawnPos.x + 4f,
			                                    spawnPos.y,
			                                    spawnPos.z);


		EnemyAIBoss2 boss = enemy1.GetComponent<EnemyAIBoss2> ();
		
		boss.levelControllerBehavior = levelControllerBehavior;
		
		EnemyBehavior enemyBehavior = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
        enemy1 = Instantiate (enemy1);
        enemyBehavior.SetPaused(pauseController.IsPaused);

        bulletPool.SetLevelBoss(enemy1.GetComponent<EnemyBehavior>());
        shieldableBulletPool.SetLevelBoss(enemy1.GetComponent<EnemyBehavior>());
	}
}
