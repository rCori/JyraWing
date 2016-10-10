using UnityEngine;
using System.Collections;

public class EnemySpawn2Ships2BFightersArcAway : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn () {

		EnemyAIShipArc.MoveInstruction left = new EnemyAIShipArc.MoveInstruction();
		left.type = EnemyBehavior.MovementStatus.Velocity;
		left.startVelocity = new Vector2 (-2f, 0f);
		left.time = 2f;

		EnemyAIShipArc.MoveInstruction down = new EnemyAIShipArc.MoveInstruction();
		down.type = EnemyBehavior.MovementStatus.Velocity;
		down.startVelocity = new Vector2 (0f, -2f);
		down.time = 2f;

		EnemyAIShipArc.MoveInstruction right = new EnemyAIShipArc.MoveInstruction();
		right.type = EnemyBehavior.MovementStatus.Velocity;
		right.startVelocity = new Vector2 (2f, 0f);
		right.time = 2f;

		EnemyAIShipArc.MoveInstruction up = new EnemyAIShipArc.MoveInstruction();
		up.type = EnemyBehavior.MovementStatus.Velocity;
		up.startVelocity = new Vector2 (0f, 2f);
		up.time = 2f;

		EnemyAIShipArc.MoveInstruction leftAndDown = new EnemyAIShipArc.MoveInstruction();
		leftAndDown.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndDown.startVelocity = new Vector2 (-2f, 0f);
		leftAndDown.endVelocity = new Vector2(0f,-2f);
		leftAndDown.time = 2f;

		EnemyAIShipArc.MoveInstruction leftAndUp = new EnemyAIShipArc.MoveInstruction();
		leftAndUp.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndUp.startVelocity = new Vector2 (-2f, 0f);
		leftAndUp.endVelocity = new Vector2(0f,2f);
		leftAndUp.time = 2f;

		EnemyAIShipArc.MoveInstruction downAndRight = new EnemyAIShipArc.MoveInstruction ();
		downAndRight.type = EnemyBehavior.MovementStatus.ArcVelocity;
		downAndRight.startVelocity = new Vector2 (0, -2f);
		downAndRight.endVelocity = new Vector2 (2f, 0f);
		downAndRight.time = 2f;

		EnemyAIShipArc.MoveInstruction upAndRight = new EnemyAIShipArc.MoveInstruction ();
		upAndRight.type = EnemyBehavior.MovementStatus.ArcVelocity;
		upAndRight.startVelocity = new Vector2 (0, 2f);
		upAndRight.endVelocity = new Vector2 (2f, 0f);
		upAndRight.time = 2f;

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector2 (8.0f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc enemyAI = enemy.GetComponent<EnemyAIShipArc> ();

			enemyAI.MoveInstructionList.Clear ();

			enemyAI.MoveInstructionList.Add (left);
			enemyAI.MoveInstructionList.Add (leftAndDown);
			enemyAI.MoveInstructionList.Add (down);
			enemyAI.MoveInstructionList.Add (downAndRight);
			enemyAI.MoveInstructionList.Add (right);

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
			enemy.transform.position = new Vector2 (9.0f, 0f);
			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAIShipArc enemyAI = enemy.GetComponent<EnemyAIShipArc> ();

			enemyAI.MoveInstructionList.Clear ();

			enemyAI.MoveInstructionList.Add (left);
			enemyAI.MoveInstructionList.Add (leftAndUp);
			enemyAI.MoveInstructionList.Add (up);
			enemyAI.MoveInstructionList.Add (upAndRight);
			enemyAI.MoveInstructionList.Add (right);

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}


		EnemyAITypeBFighter.MoveInstruction leftFighterB = new EnemyAITypeBFighter.MoveInstruction();
		leftFighterB.type = EnemyBehavior.MovementStatus.Velocity;
		leftFighterB.startVelocity = new Vector2 (-2f, 0f);
		leftFighterB.time = 2f;

		EnemyAITypeBFighter.MoveInstruction downFighterB = new EnemyAITypeBFighter.MoveInstruction();
		downFighterB.type = EnemyBehavior.MovementStatus.Velocity;
		downFighterB.startVelocity = new Vector2 (0f, -2f);
		downFighterB.time = 2f;

		EnemyAITypeBFighter.MoveInstruction rightFighterB = new EnemyAITypeBFighter.MoveInstruction();
		rightFighterB.type = EnemyBehavior.MovementStatus.Velocity;
		rightFighterB.startVelocity = new Vector2 (2f, 0f);
		rightFighterB.time = 2f;

		EnemyAITypeBFighter.MoveInstruction upFighterB = new EnemyAITypeBFighter.MoveInstruction();
		upFighterB.type = EnemyBehavior.MovementStatus.Velocity;
		upFighterB.startVelocity = new Vector2 (0f, 2f);
		upFighterB.time = 2f;

		EnemyAITypeBFighter.MoveInstruction leftAndDownFighterB = new EnemyAITypeBFighter.MoveInstruction();
		leftAndDownFighterB.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndDownFighterB.startVelocity = new Vector2 (-2f, 0f);
		leftAndDownFighterB.endVelocity = new Vector2(0f,-2f);
		leftAndDownFighterB.time = 2f;

		EnemyAITypeBFighter.MoveInstruction leftAndUpFighterB = new EnemyAITypeBFighter.MoveInstruction();
		leftAndUpFighterB.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndUpFighterB.startVelocity = new Vector2 (-2f, 0f);
		leftAndUpFighterB.endVelocity = new Vector2(0f,2f);
		leftAndUpFighterB.time = 2f;

		EnemyAITypeBFighter.MoveInstruction downAndRightFighterB = new EnemyAITypeBFighter.MoveInstruction ();
		downAndRightFighterB.type = EnemyBehavior.MovementStatus.ArcVelocity;
		downAndRightFighterB.startVelocity = new Vector2 (0, -2f);
		downAndRightFighterB.endVelocity = new Vector2 (2f, 0f);
		downAndRightFighterB.time = 2f;

		EnemyAITypeBFighter.MoveInstruction upAndRightFighterB = new EnemyAITypeBFighter.MoveInstruction ();
		upAndRightFighterB.type = EnemyBehavior.MovementStatus.ArcVelocity;
		upAndRightFighterB.startVelocity = new Vector2 (0, 2f);
		upAndRightFighterB.endVelocity = new Vector2 (2f, 0f);
		upAndRightFighterB.time = 2f;


		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
			enemy.transform.position = new Vector2 (10.0f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAITypeBFighter arcFighterBAI = enemy.GetComponent<EnemyAITypeBFighter> ();

			arcFighterBAI.MoveInstructionList.Clear ();

			arcFighterBAI.MoveInstructionList.Add (leftFighterB);
			arcFighterBAI.MoveInstructionList.Add (leftAndDownFighterB);
			arcFighterBAI.MoveInstructionList.Add (downFighterB);
			arcFighterBAI.MoveInstructionList.Add (downAndRightFighterB);
			arcFighterBAI.MoveInstructionList.Add (rightFighterB);

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
			enemy.transform.position = new Vector2 (11.0f, 0f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;
			EnemyAITypeBFighter arcFighterBAI = enemy.GetComponent<EnemyAITypeBFighter> ();

			arcFighterBAI.MoveInstructionList.Clear ();

			arcFighterBAI.MoveInstructionList.Add (leftFighterB);
			arcFighterBAI.MoveInstructionList.Add (leftAndUpFighterB);
			arcFighterBAI.MoveInstructionList.Add (upFighterB);
			arcFighterBAI.MoveInstructionList.Add (upAndRightFighterB);
			arcFighterBAI.MoveInstructionList.Add (rightFighterB);

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

	}
}
