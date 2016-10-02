using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnDiamondArc : EnemySpawner {

    public Vector2 location;
    public PointIconPool pointIconPool;
    public List<EnemyAIDiamondArc.MoveInstruction> moveInstructionList;

    public override void Spawn() {
        GameObject enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondArc");
        enemy.transform.position = location;

        EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
        enemyBehavior.pointIconPool = pointIconPool;
        enemyBehavior.LeftWallException = true;

        EnemyAIDiamondArc ai1 = enemy.GetComponent<EnemyAIDiamondArc>();

        ai1.MoveInstructionList.Clear();
        foreach (EnemyAIDiamondArc.MoveInstruction moveInstruction in moveInstructionList) {
            ai1.MoveInstructionList.Add(moveInstruction);
        }
        enemy = Instantiate(enemy);
    }

}
