using UnityEngine;
using System.Collections;

public class EnemySpawn2Ships2BFightersArcAway : EnemySpawner {

	public override void Spawn () {

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();



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

		GameObject arcDownShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		arcDownShip.transform.position = new Vector2(8.0f, 0f);

		arcDownShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		arcDownShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAIShipArc arcDownShipAI = arcDownShip.GetComponent<EnemyAIShipArc> ();

		arcDownShipAI.MoveInstructionList.Clear ();

		arcDownShipAI.MoveInstructionList.Add (left);
		arcDownShipAI.MoveInstructionList.Add (leftAndDown);
		arcDownShipAI.MoveInstructionList.Add (down);
		arcDownShipAI.MoveInstructionList.Add (downAndRight);
		arcDownShipAI.MoveInstructionList.Add (right);

		arcDownShip = Instantiate (arcDownShip);



		GameObject arcUpShip = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		arcUpShip.transform.position = new Vector2(9.0f, 0f);

		arcUpShip.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		arcUpShip.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAIShipArc arcUpShipAI = arcUpShip.GetComponent<EnemyAIShipArc> ();

		arcUpShipAI.MoveInstructionList.Clear ();

		arcUpShipAI.MoveInstructionList.Add (left);
		arcUpShipAI.MoveInstructionList.Add (leftAndUp);
		arcUpShipAI.MoveInstructionList.Add (up);
		arcUpShipAI.MoveInstructionList.Add (upAndRight);
		arcUpShipAI.MoveInstructionList.Add (right);

		arcUpShip = Instantiate (arcUpShip);



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



		GameObject arcDownFighterB = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
		arcDownFighterB.transform.position = new Vector2(10.0f, 0f);

		arcDownFighterB.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		arcDownFighterB.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		arcDownFighterB.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAITypeBFighter arcDownFighterBAI = arcDownFighterB.GetComponent<EnemyAITypeBFighter> ();

		arcDownFighterBAI.MoveInstructionList.Clear ();

		arcDownFighterBAI.MoveInstructionList.Add (leftFighterB);
		arcDownFighterBAI.MoveInstructionList.Add (leftAndDownFighterB);
		arcDownFighterBAI.MoveInstructionList.Add (downFighterB);
		arcDownFighterBAI.MoveInstructionList.Add (downAndRightFighterB);
		arcDownFighterBAI.MoveInstructionList.Add (rightFighterB);

		arcDownFighterB = Instantiate (arcDownFighterB);



		GameObject arcUpFighterB = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
		arcUpFighterB.transform.position = new Vector2(11.0f, 0f);

		arcUpFighterB.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		arcUpFighterB.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		arcUpFighterB.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAITypeBFighter arcUpFighterBAI = arcUpFighterB.GetComponent<EnemyAITypeBFighter> ();

		arcUpFighterBAI.MoveInstructionList.Clear ();

		arcUpFighterBAI.MoveInstructionList.Add (leftFighterB);
		arcUpFighterBAI.MoveInstructionList.Add (leftAndUpFighterB);
		arcUpFighterBAI.MoveInstructionList.Add (upFighterB);
		arcUpFighterBAI.MoveInstructionList.Add (upAndRightFighterB);
		arcUpFighterBAI.MoveInstructionList.Add (rightFighterB);

		arcUpFighterB = Instantiate (arcUpFighterB);


	}
}
