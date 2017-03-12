using UnityEngine;
using System.Collections;

public class Boss3Spawn : EnemySpawner {

	public PointIconPool pointIconPool;
	public LevelControllerBehavior levelControllerBehavior;
	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn(){

		Vector3 spawnPos = gameObject.transform.position;

		GameObject enemy = (GameObject) Resources.Load ("Enemies/BossEnemies/Enemy_Boss3");
		enemy.transform.position = new Vector3(10.0f,0f,0f);
		
		enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy.GetComponent<EnemyBehavior> ().pointIconPool = pointIconPool;

        EnemyAIBoss3 boss3AI = enemy.GetComponent<EnemyAIBoss3>();
		boss3AI.levelControllerBehavior = levelControllerBehavior;

		enemy = Instantiate (enemy);
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);

        bulletPool.SetLevelBoss(enemy.GetComponent<EnemyBehavior>());
        shieldableBulletPool.SetLevelBoss(enemy.GetComponent<EnemyBehavior>());
	}
}
