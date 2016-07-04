using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnFighterTypeBArcIn : EnemySpawner {

	public override void Spawn () {

		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject fromTopEnemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
		fromTopEnemy.transform.position = new Vector2(4.0f, 5f);

		fromTopEnemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		fromTopEnemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		fromTopEnemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAITypeBFighter arcDownAI = fromTopEnemy.GetComponent<EnemyAITypeBFighter> ();

		EnemyAITypeBFighter.MoveInstruction left = new EnemyAITypeBFighter.MoveInstruction();
		left.type = EnemyBehavior.MovementStatus.Velocity;
		left.startVelocity = new Vector2 (-2f, 0f);
		left.time = 7f;

		EnemyAITypeBFighter.MoveInstruction leftAndDown = new EnemyAITypeBFighter.MoveInstruction();
		leftAndDown.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndDown.startVelocity = new Vector2 (0f, -2f);
		leftAndDown.endVelocity = new Vector2(-2f,0f);
		leftAndDown.time = 2f;

		EnemyAITypeBFighter.MoveInstruction down = new EnemyAITypeBFighter.MoveInstruction();
		down.type = EnemyBehavior.MovementStatus.Velocity;
		down.startVelocity = new Vector2 (0f, -2f);
		down.time = 2f;

		arcDownAI.MoveInstructionList.Clear ();

		arcDownAI.MoveInstructionList.Add (down);
		arcDownAI.MoveInstructionList.Add (leftAndDown);
		arcDownAI.MoveInstructionList.Add (left);


		//arcDownAI.MoveInstructionList
		fromTopEnemy = Instantiate (fromTopEnemy);

		GameObject upFromBottom = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
		upFromBottom.transform.position = new Vector2(4.0f, -5f);

		upFromBottom.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		upFromBottom.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		upFromBottom.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAITypeBFighter arcUpAI = upFromBottom.GetComponent<EnemyAITypeBFighter> ();

		EnemyAITypeBFighter.MoveInstruction leftAndUp = new EnemyAITypeBFighter.MoveInstruction();
		leftAndUp.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndUp.startVelocity = new Vector2 (0f, 2f);
		leftAndUp.endVelocity = new Vector2(-2f,0f);
		leftAndUp.time = 2f;

		EnemyAITypeBFighter.MoveInstruction up = new EnemyAITypeBFighter.MoveInstruction();
		up.type = EnemyBehavior.MovementStatus.Velocity;
		up.startVelocity = new Vector2 (0f, 2f);
		up.time = 2f;

		arcUpAI.MoveInstructionList.Clear ();

		arcUpAI.MoveInstructionList.Add (up);
		arcUpAI.MoveInstructionList.Add (leftAndUp);
		arcUpAI.MoveInstructionList.Add (left);

		upFromBottom = Instantiate (upFromBottom);
	}
}
