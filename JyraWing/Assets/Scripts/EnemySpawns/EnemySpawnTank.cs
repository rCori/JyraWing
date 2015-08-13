using UnityEngine;
using System.Collections;

public class EnemySpawnTank : EnemySpawner {

	public Vector2 enemyPosition;
	public int tankHealth;
	public EnemyAI5.TankDir direction;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_E");
		enemy1.transform.position = enemyPosition;

		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
//		if (direction == EnemyAI5.TankDir.Left) {
//			enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;
//		} else {
//			enemy1.GetComponent<EnemyBehavior> ().LeftWallException = true;
//		}
		EnemyAI5 ai1 = enemy1.GetComponent<EnemyAI5> ();
		ai1.direction = direction;
		enemy1 = Instantiate (enemy1);
		enemy1.GetComponent<EnemyBehavior> ().SetEnemyHealth (tankHealth);
	}
}
