using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnShipsArcAway : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn () {

		EnemyAIShipArc.MoveInstruction left = new EnemyAIShipArc.MoveInstruction ();
		left.type = EnemyBehavior.MovementStatus.Velocity;
		left.startVelocity = new Vector2 (-2f, 0f);
		left.time = 2f;

		EnemyAIShipArc.MoveInstruction leftAndDown = new EnemyAIShipArc.MoveInstruction ();
		leftAndDown.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndDown.startVelocity = new Vector2 (-2f, 0f);
		leftAndDown.endVelocity = new Vector2 (0f, -2f);
		leftAndDown.time = 2f;

		EnemyAIShipArc.MoveInstruction down = new EnemyAIShipArc.MoveInstruction ();
		down.type = EnemyBehavior.MovementStatus.Velocity;
		down.startVelocity = new Vector2 (0f, -2f);
		down.time = 2f;

		EnemyAIShipArc.MoveInstruction leftAndUp = new EnemyAIShipArc.MoveInstruction ();
		leftAndUp.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndUp.startVelocity = new Vector2 (-2f, 0f);
		leftAndUp.endVelocity = new Vector2 (0f, 2f);
		leftAndUp.time = 2f;

		EnemyAIShipArc.MoveInstruction up = new EnemyAIShipArc.MoveInstruction ();
		up.type = EnemyBehavior.MovementStatus.Velocity;
		up.startVelocity = new Vector2 (0f, 2f);
		up.time = 2f;

		{
			GameObject arcDownEnemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			arcDownEnemy.transform.position = new Vector2 (8.0f, 1.5f);

			EnemyBehavior enemyBehavior = arcDownEnemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc arcDownAI = arcDownEnemy.GetComponent<EnemyAIShipArc> ();

			arcDownAI.MoveInstructionList.Clear ();

			arcDownAI.MoveInstructionList.Add (left);
			arcDownAI.MoveInstructionList.Add (leftAndDown);
			arcDownAI.MoveInstructionList.Add (down);

			//arcDownAI.MoveInstructionList
			arcDownEnemy = Instantiate (arcDownEnemy);
            arcDownEnemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject arcUpEnemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			arcUpEnemy.transform.position = new Vector2 (8.0f, -1.5f);

			EnemyBehavior enemyBehavior = arcUpEnemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc arcUpAI = arcUpEnemy.GetComponent<EnemyAIShipArc> ();


			arcUpAI.MoveInstructionList.Clear ();

			arcUpAI.MoveInstructionList.Add (left);
			arcUpAI.MoveInstructionList.Add (leftAndUp);
			arcUpAI.MoveInstructionList.Add (up);

			arcUpEnemy = Instantiate (arcUpEnemy);
            arcUpEnemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
	}
}
