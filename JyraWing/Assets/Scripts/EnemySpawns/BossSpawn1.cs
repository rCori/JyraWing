using UnityEngine;
using System.Collections;

public class BossSpawn1 : EnemySpawner {

	public PointIconPool pointIconPool;
	public LevelControllerBehavior levelControllerBehavior;
	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn(){

		Vector3 spawnPos = gameObject.transform.position;

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/BossEnemies/Enemy_Boss");
		enemy1.transform.position = new Vector3(spawnPos.x + 4f,
			                                    spawnPos.y,
			                                    spawnPos.z);


		EnemyBoss1 boss = enemy1.GetComponent<EnemyBoss1> ();
		
		boss.levelControllerBehavior = levelControllerBehavior;
		enemy1 = Instantiate (enemy1);
		EnemyBehavior enemyBehavior = enemy1.GetComponent<EnemyBehavior> ();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.pointIconPool = pointIconPool;
        enemyBehavior.SetPaused(pauseController.IsPaused);
	}
}
