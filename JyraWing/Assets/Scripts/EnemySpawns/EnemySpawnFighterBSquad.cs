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

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
		float yOffset = -columns / 2f + yShift;
		float xOffset = 8.0f;

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				float xLoc = xOffset + i * rowSpacing;
				float yLoc = yOffset + j * columnSpacing;
				//Middle row
				GameObject enemy = (GameObject)Resources.Load ("Enemies/BasicShipEnemies/Enemy_ShipTypeBFighter");
				enemy.transform.position = new Vector2 (xLoc, yLoc);

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
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}
	}
}
