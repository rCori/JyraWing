using UnityEngine;
using System.Collections;

public class EnemySpawn8 : EnemySpawner {

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();
		
		//bottom right
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy1.transform.position = new Vector3 (4.0f, -4.0f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyAI6> ().angle = 180f;
		Instantiate (enemy1);
	}
}
