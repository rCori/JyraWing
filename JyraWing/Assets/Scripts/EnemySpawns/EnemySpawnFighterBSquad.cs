using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnFighterBSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public List<EnemyAITypeBFighter.MoveInstruction> moveInstructionList;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		float yOffset = -columns / 2f + yShift;
		float xOffset = 8.0f;

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				float xLoc = xOffset + i * rowSpacing;
				float yLoc = yOffset + j * columnSpacing;
				//Middle row
				GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
				enemy.transform.position = new Vector2 (xLoc, yLoc);
				Debug.Log ("xLoc: " + xLoc + " yLoc: " + yLoc);

				enemy.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
				enemy.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
				enemy.GetComponent<EnemyBehavior> ().LeftWallException = true;
				EnemyAITypeBFighter ai1 = enemy.GetComponent<EnemyAITypeBFighter> ();

				ai1.MoveInstructionList.Clear ();
				foreach(EnemyAITypeBFighter.MoveInstruction moveInstruction in moveInstructionList) {
					ai1.MoveInstructionList.Add(moveInstruction);
				}
				enemy = Instantiate (enemy);
			}
		}
	}
}
