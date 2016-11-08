using UnityEngine;
using System.Collections;

public class EnemySpawnDiamondSquad : EnemySpawner {

    //public Vector2 enemyPosition;
    public Vector2 initLocation = new Vector2(0f, 0f);
	public Vector2 enemyDirection;
	public float enemyTime;
	public bool enemyRepeat;

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public PointIconPool pointIconPool;
    public PauseControllerBehavior pauseController;

	public override void Spawn () {

		//float yOffset = enemyPosition.y -columns / 2f + yShift;
        float yOffset = (-((rows-1) * rowSpacing) / 2.0f) + initLocation.y;
		float xOffset = initLocation.x;
		for (int i = 0; i < columns; i++) {
			for (int j = 0; j < rows; j++) {
				GameObject enemy = (GameObject) Resources.Load ("Enemies/DiamondEnemies/Enemy_DiamondOscillate");
				enemy.transform.position = new Vector2 (xOffset + i*columnSpacing, yOffset + j*rowSpacing);

				EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior> ();
				enemyBehavior.pointIconPool = pointIconPool;
				if (enemyRepeat) {
					enemyBehavior.LeftWallException = false;
				}

				EnemyAIDiamondOscillate enemyAI = enemy.GetComponent<EnemyAIDiamondOscillate> ();
				enemyAI.direction = enemyDirection;
				enemyAI.time = enemyTime + i*enemyDirection.magnitude;
				enemyAI.repeat = enemyRepeat;

				enemy = Instantiate (enemy);
                enemy.GetComponent<EnemyBehavior>().SetPaused(pauseController.IsPaused);
			}
		}
	}
}
