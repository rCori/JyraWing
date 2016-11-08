using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnFighterBSquad : EnemySpawner {

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;

    public Vector2 initLocation = new Vector2(0f,0f);

	public List<EnemyAITypeBFighter.MoveInstruction> moveInstructionList;

	public EnemyBulletPool bulletPool;
	public EnemyBulletPool shieldableBulletPool;
	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn ()
	{
        //float yOffset = initLocation.y;
        float yOffset = (-((rows-1) * rowSpacing) / 2.0f) + initLocation.y;
		float xOffset = initLocation.x;

		for (int i = 0; i < columns; i++) {
			for (int j = 0; j < rows; j++) {
				float xLoc = xOffset + i * columnSpacing;
				float yLoc = yOffset + j * rowSpacing;
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
