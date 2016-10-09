using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnDiamondsquadArcInShipSquadStraightIn : EnemySpawner {

    public EnemyBulletPool bulletPool;
    public EnemyBulletPool shieldableBulletPool;
    public PointIconPool pointIconPool;

    public int extraAdditions = 1;

    private int diamondRows;
    private int diamondColumns;

    private int shipRows;
    private int shipColumns;

    public override void Spawn() {

        Mathf.Clamp(extraAdditions, 1, 3);
       
        switch(extraAdditions) {
        case 1:
            diamondRows = 3;
            diamondColumns = 4;
            shipRows = 3;
            shipColumns = 1;
            break;
        case 2:
            diamondRows = 4;
            diamondColumns = 7;
            shipRows = 3;
            shipColumns = 2;
            break;
        case 3:
            diamondRows = 3;
            diamondColumns = 8;
            shipRows = 3;
            shipColumns = 3;
            break;
        }

        EnemyAIDiamondArc.MoveInstruction downInstruction = new EnemyAIDiamondArc.MoveInstruction();
        downInstruction.time = 1f;
        downInstruction.type = EnemyBehavior.MovementStatus.Velocity;
        downInstruction.startVelocity = new Vector2(0f, -2f);

        EnemyAIDiamondArc.MoveInstruction downLeftInstruction = new EnemyAIDiamondArc.MoveInstruction();
        downLeftInstruction.time = 1f;
        downLeftInstruction.type = EnemyBehavior.MovementStatus.ArcVelocity;
        downLeftInstruction.startVelocity = new Vector2(0f, -2f);
        downLeftInstruction.endVelocity = new Vector2(-2.5f, 0f);


        EnemyAIDiamondArc.MoveInstruction leftInstruction = new EnemyAIDiamondArc.MoveInstruction();
        leftInstruction.time = 7f;
        leftInstruction.type = EnemyBehavior.MovementStatus.Velocity;
        leftInstruction.startVelocity = new Vector2(-2.5f, 0f);


        GameObject diamondArcEnemy = (GameObject)Resources.Load("Enemies/DiamondEnemies/Enemy_DiamondArc");

        List<EnemyAIDiamondArc.MoveInstruction> downwardDiamonds = new List<EnemyAIDiamondArc.MoveInstruction>();

        downwardDiamonds.Add(downInstruction);
        downwardDiamonds.Add(downLeftInstruction);
        downwardDiamonds.Add(leftInstruction);

        diamondArcEnemy.GetComponent<EnemyAIDiamondArc>().MoveInstructionList.Clear();


        for (int i = 0; i < diamondColumns; i++) {
            for (int j = 0; j < diamondRows; j++) {
                diamondArcEnemy.transform.position = new Vector2(1f + (1.0f * i), 4f + (0.8f * j));

                EnemyBehavior enemyBehavior = diamondArcEnemy.GetComponent<EnemyBehavior>();
                enemyBehavior.pointIconPool = pointIconPool;
                enemyBehavior.LeftWallException = true;

                EnemyAIDiamondArc diamondArcAI = diamondArcEnemy.GetComponent<EnemyAIDiamondArc>();

                diamondArcAI.MoveInstructionList = downwardDiamonds;

                Instantiate(diamondArcEnemy);
            }
        }

        EnemyAIDiamondArc.MoveInstruction upInstruction = new EnemyAIDiamondArc.MoveInstruction();
        upInstruction.time = 1f;
        upInstruction.type = EnemyBehavior.MovementStatus.Velocity;
        upInstruction.startVelocity = new Vector2(0f, 2f);

        EnemyAIDiamondArc.MoveInstruction upLeftInstruction = new EnemyAIDiamondArc.MoveInstruction();
        upLeftInstruction.time = 1f;
        upLeftInstruction.type = EnemyBehavior.MovementStatus.ArcVelocity;
        upLeftInstruction.startVelocity = new Vector2(0f, 2f);
        upLeftInstruction.endVelocity = new Vector2(-2.5f, 0f);

        List<EnemyAIDiamondArc.MoveInstruction> upwardDiamonds = new List<EnemyAIDiamondArc.MoveInstruction>();

        upwardDiamonds.Add(upInstruction);
        upwardDiamonds.Add(upLeftInstruction);
        upwardDiamonds.Add(leftInstruction);

        diamondArcEnemy.GetComponent<EnemyAIDiamondArc>().MoveInstructionList.Clear();


        for (int i = 0; i < diamondColumns; i++) {
            for (int j = 0; j < diamondRows; j++) {
                diamondArcEnemy.transform.position = new Vector2(1f + (1.0f * i), -5f - (0.8f * j));

                EnemyBehavior enemyBehavior = diamondArcEnemy.GetComponent<EnemyBehavior>();
                enemyBehavior.pointIconPool = pointIconPool;
                enemyBehavior.LeftWallException = true;

                EnemyAIDiamondArc diamondArcAI = diamondArcEnemy.GetComponent<EnemyAIDiamondArc>();

                diamondArcAI.MoveInstructionList = upwardDiamonds;

                Instantiate(diamondArcEnemy);
            }
        }


        GameObject shipEnemy = (GameObject)Resources.Load("Enemies/BasicShipEnemies/Enemy_ShipArc");

        List<EnemyAIShipArc.MoveInstruction> moveInstructionList = new List<EnemyAIShipArc.MoveInstruction>();

        EnemyAIShipArc.MoveInstruction leftShipInstruction = new EnemyAIShipArc.MoveInstruction();
        leftShipInstruction.time = 10f;
        leftShipInstruction.type = EnemyBehavior.MovementStatus.Velocity;
        leftShipInstruction.startVelocity = new Vector2(-2.5f, 0f);

        moveInstructionList.Add(leftShipInstruction);

        shipEnemy.GetComponent<EnemyAIShipArc>().MoveInstructionList.Clear();

        if (extraAdditions == 1) {
            for (int i = 0; i < shipColumns; i++) {
                for (int j = 0; j < shipRows; j++) {
                    float baseY = -1.5f;
                    shipEnemy.transform.position = new Vector2(8f + (1.0f * i), baseY + (1.0f * j));

                    EnemyBehavior enemyBehavior = shipEnemy.GetComponent<EnemyBehavior>();
                    enemyBehavior.bulletPool = bulletPool;
                    enemyBehavior.shieldableBulletPool = shieldableBulletPool;
                    enemyBehavior.pointIconPool = pointIconPool;

                    EnemyAIShipArc shipAi = shipEnemy.GetComponent<EnemyAIShipArc>();

                    shipAi.MoveInstructionList = moveInstructionList;

                    Instantiate(shipEnemy);
                }
            }
        } else {
            int rows = 1;
            for (int i = 0; i < shipColumns; i++) {
                for (int j = 0; j < rows; j++) {
                    float baseY = -(rows * 0.5f);
                    shipEnemy.transform.position = new Vector2(8f + (1.0f * i), baseY + (1.0f * j));

                    EnemyBehavior enemyBehavior = shipEnemy.GetComponent<EnemyBehavior>();
                    enemyBehavior.bulletPool = bulletPool;
                    enemyBehavior.shieldableBulletPool = shieldableBulletPool;
                    enemyBehavior.pointIconPool = pointIconPool;

                    EnemyAIShipArc shipAi = shipEnemy.GetComponent<EnemyAIShipArc>();

                    shipAi.MoveInstructionList = moveInstructionList;

                    Instantiate(shipEnemy);
                }
                rows++;
            }
        }

        /*
        for (int i = 0; i < shipColumns; i++) {
            for (int j = 0; j < shipRows; j++) {
                float baseY = -1.5f;
                if(i%2 != 0) {
                    baseY = -2.0f;
                }
                shipEnemy.transform.position = new Vector2(8f + (1.0f * i), baseY + (1.0f*j));

                EnemyBehavior enemyBehavior = shipEnemy.GetComponent<EnemyBehavior>();
                enemyBehavior.bulletPool = bulletPool;
                enemyBehavior.shieldableBulletPool = shieldableBulletPool;
                enemyBehavior.pointIconPool = pointIconPool;

                EnemyAIShipArc shipAi = shipEnemy.GetComponent<EnemyAIShipArc>();

                shipAi.MoveInstructionList = moveInstructionList;

                Instantiate(shipEnemy);
            }
        }



        if (shipColumns == 2) {
            shipEnemy.transform.position = new Vector2(9f, 1.0f);

            EnemyBehavior enemyBehavior = shipEnemy.GetComponent<EnemyBehavior>();
            enemyBehavior.bulletPool = bulletPool;
            enemyBehavior.shieldableBulletPool = shieldableBulletPool;
            enemyBehavior.pointIconPool = pointIconPool;

            EnemyAIShipArc shipAi = shipEnemy.GetComponent<EnemyAIShipArc>();

            shipAi.MoveInstructionList.Add(leftShipInstruction);

            Instantiate(shipEnemy);
        }
        */
    }
}
