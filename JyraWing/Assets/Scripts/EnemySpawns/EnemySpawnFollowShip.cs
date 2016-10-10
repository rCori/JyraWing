using UnityEngine;
using System.Collections;

public class EnemySpawnFollowShip : EnemySpawner
{

    public PointIconPool pointIconPool;
    public EnemyBulletPool bulletPool;
    public EnemyBulletPool shieldableBulletPool;
    public PauseControllerBehavior pauseController;

    public Vector2 position;

    public override void Spawn()
    {
        GameObject enemy = (GameObject)Resources.Load("Enemies/BasicShipEnemies/Enemy_ShipFollow");
        EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
        enemyBehavior.bulletPool = bulletPool;
        enemyBehavior.shieldableBulletPool = shieldableBulletPool;
        enemyBehavior.pointIconPool = pointIconPool;
        enemy = Instantiate(enemy);
        enemy.transform.position = position;
        enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);

    }
}
