using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnShipArcSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;

	public Vector2 initLocation = new Vector2(0f,0f);

	public List<EnemyAIShipArc.MoveInstruction> moveInstructionList;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;


	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		float yOffset = initLocation.y;
		float xOffset = initLocation.x;

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				float xLoc = xOffset + j * columnSpacing;
				float yLoc = yOffset + i * rowSpacing;
				//Middle row
				GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipArc");
				enemy.transform.position = new Vector2 (xLoc, yLoc);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.bulletPool = bulletPool;
				enemyBehavior.shieldableBulletPool = shieldableBulletPool;
				enemyBehavior.pointIconPool = pointIconPool;
				enemyBehavior.LeftWallException = true;
				EnemyAIShipArc ai1 = enemy.GetComponent<EnemyAIShipArc> ();

				ai1.MoveInstructionList.Clear ();
				foreach(EnemyAIShipArc.MoveInstruction moveInstruction in moveInstructionList) {
					ai1.MoveInstructionList.Add(moveInstruction);
				}
				enemy = Instantiate (enemy);
			}
		}
	}
}
