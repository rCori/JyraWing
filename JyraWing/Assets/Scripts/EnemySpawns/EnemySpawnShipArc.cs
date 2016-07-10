using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnShipArc : EnemySpawner {

	public Vector2 location;
	public List<EnemyAIShipArc.MoveInstruction> moveInstructionList;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
		enemy.transform.position = location;

		enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
		enemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
		EnemyAIShipArc ai1 = enemy.GetComponent<EnemyAIShipArc> ();

		ai1.MoveInstructionList.Clear ();
		foreach(EnemyAIShipArc.MoveInstruction moveInstruction in moveInstructionList) {
			ai1.MoveInstructionList.Add(moveInstruction);
		}
		enemy = Instantiate (enemy);
	}
}

