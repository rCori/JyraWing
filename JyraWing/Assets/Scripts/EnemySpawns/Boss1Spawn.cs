using UnityEngine;
using System.Collections;

public class Boss1Spawn : EnemySpawner {

    public PointIconPool pointIconPool;
    public LevelControllerBehavior levelControllerBehavior;
    public EnemyBulletPool bulletPool;
    public EnemyBulletPool shieldableBulletPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn() {
	    Vector3 spawnPos = gameObject.transform.position;

        GameObject enemy = (GameObject)Resources.Load("Enemies/BossEnemies/Enemy_Boss1");
        enemy.transform.position = new Vector3(10.0f, 0f, 0f);

        enemy.GetComponent<EnemyBehavior>().bulletPool = bulletPool;
        enemy.GetComponent<EnemyBehavior>().shieldableBulletPool = shieldableBulletPool;
        enemy.GetComponent<EnemyBehavior>().pointIconPool = pointIconPool;

        EnemyAIBoss1 boss1AI = enemy.GetComponent<EnemyAIBoss1>();
        boss1AI.levelControllerBehavior = levelControllerBehavior;

        enemy = Instantiate(enemy);
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
	}
	

}
