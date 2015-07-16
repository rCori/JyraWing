using UnityEngine;
using System.Collections;

public class EnemySpawn11 : EnemySpawner {

	public bool top;
	public bool bottom;

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();

		if (top) {
			//top
			GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy1.transform.position = new Vector3 (5.5f, 3.7f, 0f);
			enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy1 = Instantiate (enemy1);

			GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy2.transform.position = new Vector3 (8.5f, 3.7f, 0f);
			enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy2 = Instantiate (enemy2);

			GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy3.transform.position = new Vector3 (11.5f, 3.7f, 0f);
			enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy3 = Instantiate (enemy3);
		}

		if (bottom) {
			GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy4.transform.position = new Vector3 (5.5f, -3.7f, 0f);
			enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy4 = Instantiate (enemy4);
		
			GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy5.transform.position = new Vector3 (8.5f, -3.7f, 0f);
			enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy5 = Instantiate (enemy5);

			GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_D");
			enemy6.transform.position = new Vector3 (11.5f, -3.7f, 0f);
			enemy6.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy6 = Instantiate (enemy6);
		}


	}
}
