using UnityEngine;
using System.Collections;

public class EnemySpawn22 : EnemySpawner {
	
	
	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();

		/* second turret */

		GameObject enemy1 = (GameObject) Resources.Load ("Enemies/Enemy_J");
		enemy1.transform.position = new Vector2 (8f, 2f);
		
		enemy1.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;

		enemy1.GetComponent<EnemyAI10> ().Health = 3;
		enemy1 = Instantiate (enemy1);

		/* bottom turret */

		GameObject enemy2 = (GameObject) Resources.Load ("Enemies/Enemy_J");
		enemy2.transform.position = new Vector2 (8f, -2f);
		
		enemy2.GetComponent<EnemyBehavior> ().bulletPool= bulletPool;
		enemy2.GetComponent<EnemyBehavior> ().shieldableBulletPool= shieldableBulletPool;
		enemy2.GetComponent<EnemyBehavior> ().LeftWallException = false;

		enemy2.GetComponent<EnemyAI10> ().Health = 3;
		enemy2 = Instantiate (enemy2);

	}
}
