using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnFighterTypeB : EnemySpawner {

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;

	public Vector2 location;
	public List<EnemyAITypeBFighter.MoveInstruction> moveInstructionList;

	public override void Spawn () {
		GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
		enemy.transform.position = location;

		EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
		enemyBehavior.bulletPool = bulletPool;
		enemyBehavior.shieldableBulletPool = shieldableBulletPool;
		enemyBehavior.LeftWallException = true;
		enemyBehavior.pointIconPool = pointIconPool;

		EnemyAITypeBFighter ai = enemy.GetComponent<EnemyAITypeBFighter> ();

		ai.MoveInstructionList.Clear ();
		foreach(EnemyAITypeBFighter.MoveInstruction moveInstruction in moveInstructionList) {
			ai.MoveInstructionList.Add(moveInstruction);
		}
		enemy = Instantiate (enemy);

	}
}
