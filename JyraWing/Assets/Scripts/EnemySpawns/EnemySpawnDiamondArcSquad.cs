using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnDiamondArcSquad : EnemySpawner { 

    public int rows;
    public int columns;

    public float rowSpacing;
    public float columnSpacing;
    public Vector2 initLocation = new Vector2(0f,0f);

    public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

    public List<EnemyAIDiamondArc.MoveInstruction> moveInstructionList;

    public override void Spawn() {
        //float yOffset = enemyPosition.y - columns / 2f + yShift;
        float yOffset = (-((rows-1) * rowSpacing) / 2.0f) + initLocation.y;
        float xOffset = initLocation.x;
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
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
            }
        }
    }
}
