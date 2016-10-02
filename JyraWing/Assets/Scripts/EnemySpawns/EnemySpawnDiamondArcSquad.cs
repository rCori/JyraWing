using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnDiamondArcSquad : EnemySpawner {

    public Vector2 enemyPosition;

    public int rows;
    public int columns;

    public float rowSpacing;
    public float columnSpacing;
    public float yShift;

    public PointIconPool pointIconPool;

    public List<EnemyAIDiamondArc.MoveInstruction> moveInstructionList;

    public override void Spawn() {
        float yOffset = enemyPosition.y - columns / 2f + yShift;
        float xOffset = enemyPosition.x;
        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++) {
                GameObject enemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondArc");
                enemy.transform.position = new Vector2(xOffset + i * columnSpacing, yOffset + j * rowSpacing);

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
    }
}
