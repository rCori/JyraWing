using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemySpawnShipTriangle : EnemySpawner {

    public bool flip = false;

    public bool shield = false;

    public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

    private List<EnemyAIShipArc.MoveInstruction> shipArcInstructionList;
    private List<EnemyAITypeBFighter.MoveInstruction> fighterBInstructionList;

    public override void Spawn() {

        shipArcInstructionList = new List<EnemyAIShipArc.MoveInstruction>();
        EnemyAIShipArc.MoveInstruction shipLeftMovement = new EnemyAIShipArc.MoveInstruction();
        shipLeftMovement.startVelocity = new Vector2(-2.0f, 0f);
        shipLeftMovement.time = 16f;
        shipLeftMovement.type = EnemyBehavior.MovementStatus.Velocity;

        fighterBInstructionList = new List<EnemyAITypeBFighter.MoveInstruction>();
        EnemyAITypeBFighter.MoveInstruction fighterBLeftMovement = new EnemyAITypeBFighter.MoveInstruction();
        fighterBLeftMovement.startVelocity = new Vector2(-2.0f, 0f);
        fighterBLeftMovement.time = 16f;
        fighterBLeftMovement.type = EnemyBehavior.MovementStatus.Velocity;

        {
            GameObject enemy;
            if(shield) {
                enemy = Resources.Load("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter") as GameObject;
                EnemyAITypeBFighter ai1 = enemy.GetComponent<EnemyAITypeBFighter> ();
                ai1.MoveInstructionList.Clear ();
                ai1.MoveInstructionList.Add(fighterBLeftMovement);

            } else {
                enemy = Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc") as GameObject;
                EnemyAIShipArc ai1 = enemy.GetComponent<EnemyAIShipArc> ();

		        ai1.MoveInstructionList.Clear ();
                ai1.MoveInstructionList.Add(shipLeftMovement);
                ai1.timer = 0.0f;
            }
            float yPos = 0f;
            if(flip) {
                yPos = -2.5f;
            } else {
                yPos = 2.0f;
            }
            enemy.transform.position = new Vector2(9.0f, yPos);
            EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		    enemyBehavior.bulletPool = bulletPool;
		    enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		    enemyBehavior.pointIconPool = pointIconPool;
		    enemyBehavior.LeftWallException = true;
            enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            GameObject enemy;
            if(shield) {
                enemy = Resources.Load("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter") as GameObject;
            } else {
                enemy = Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc") as GameObject;
                EnemyAIShipArc ai1 = enemy.GetComponent<EnemyAIShipArc> ();

		        ai1.MoveInstructionList.Clear ();
                ai1.MoveInstructionList.Add(shipLeftMovement);
                ai1.timer = 0.3f;
            }
            float yPos = 0f;
            if(flip) {
                yPos = 2.0f;
            } else {
                yPos = -2.5f;
            }
            enemy.transform.position = new Vector2(13.0f, yPos);
            EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		    enemyBehavior.bulletPool = bulletPool;
		    enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		    enemyBehavior.pointIconPool = pointIconPool;
		    enemyBehavior.LeftWallException = true;
            enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }

        {
            GameObject enemy;
            if(shield) {
                enemy = Resources.Load("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter") as GameObject;
            } else {
                enemy = Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc") as GameObject;
                EnemyAIShipArc ai1 = enemy.GetComponent<EnemyAIShipArc> ();

		        ai1.MoveInstructionList.Clear ();
                ai1.MoveInstructionList.Add(shipLeftMovement);
                ai1.timer = 0.5f;
            }
            float yPos = 0f;
            if(flip) {
                yPos = -2.5f;
            } else {
                yPos = 2.0f;
            }
            enemy.transform.position = new Vector2(17.0f, yPos);
            EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
		    enemyBehavior.bulletPool = bulletPool;
		    enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		    enemyBehavior.pointIconPool = pointIconPool;
		    enemyBehavior.LeftWallException = true;
            enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
        }
    }
}
