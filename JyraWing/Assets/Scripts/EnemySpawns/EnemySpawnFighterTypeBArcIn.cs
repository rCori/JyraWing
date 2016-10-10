using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnFighterTypeBArcIn : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn () {


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

		EnemyAITypeBFighter.MoveInstruction leftAndUp = new EnemyAITypeBFighter.MoveInstruction();
		leftAndUp.type = EnemyBehavior.MovementStatus.ArcVelocity;
		leftAndUp.startVelocity = new Vector2 (0f, 2f);
		leftAndUp.endVelocity = new Vector2(-2f,0f);
		leftAndUp.time = 2f;

		EnemyAITypeBFighter.MoveInstruction up = new EnemyAITypeBFighter.MoveInstruction();
		up.type = EnemyBehavior.MovementStatus.Velocity;
		up.startVelocity = new Vector2 (0f, 2f);
		up.time = 2f;

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
			enemy.transform.position = new Vector2(4.0f, 5f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAITypeBFighter enemyAI = enemy.GetComponent<EnemyAITypeBFighter> ();

			enemyAI.MoveInstructionList.Clear ();

			enemyAI.MoveInstructionList.Add (down);
			enemyAI.MoveInstructionList.Add (leftAndDown);
			enemyAI.MoveInstructionList.Add (left);

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}

		{
			GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
			enemy.transform.position = new Vector2(4.0f, -5f);

			EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
			enemyBehavior.bulletPool = bulletPool;
			enemyBehavior.shieldableBulletPool = shieldableBulletPool;
			enemyBehavior.pointIconPool = pointIconPool;
			enemyBehavior.LeftWallException = true;

			EnemyAITypeBFighter enemyAI = enemy.GetComponent<EnemyAITypeBFighter> ();

			enemyAI.MoveInstructionList.Clear ();

			enemyAI.MoveInstructionList.Add (up);
			enemyAI.MoveInstructionList.Add (leftAndUp);
			enemyAI.MoveInstructionList.Add (left);

			enemy = Instantiate (enemy);
            enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
		}
	}
}
