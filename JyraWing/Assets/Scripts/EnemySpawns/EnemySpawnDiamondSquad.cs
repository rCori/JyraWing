using UnityEngine;
using System.Collections;

public class EnemySpawnDiamondSquad : EnemySpawner {

	public Vector2 enemyPosition;
	public Vector2 enemyDirection;
	public float enemyTime;
	public bool enemyRepeat;
	public int enemyHitPoints;

	public int rows;
	public int columns;

	public float rowSpacing;
	public float columnSpacing;
	public float yShift;

	public override void Spawn () {

		float yOffset = enemyPosition.y -columns / 2f + yShift;
		float xOffset = enemyPosition.x;
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_H");
				enemy1.transform.position = new Vector2 (xOffset + i*rowSpacing, yOffset + j*columnSpacing);

				EnemyBehavior enemyBehavior1 = enemy1.GetComponent<EnemyBehavior> ();
				if (enemyRepeat) {
					enemyBehavior1.LeftWallException = false;
				}

				EnemyAI8 enemyAI1 = enemy1.GetComponent<EnemyAI8> ();
				enemyAI1.direction = enemyDirection;
				enemyAI1.time = enemyTime + i*enemyDirection.magnitude;
				enemyAI1.repeat = enemyRepeat;

				enemy1 = Instantiate (enemy1);
				enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (enemyHitPoints);
			}
		}
	}
}
