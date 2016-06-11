using UnityEngine;
using System.Collections;

public class EnemySpawn7 : EnemySpawner {

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();


		//bottom right
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy1.transform.position = new Vector3(6.0f,-4.0f,0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Up;
		Instantiate (enemy1);

		//bottom left
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy2.transform.position = new Vector3(-2.0f,-4.0f,0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Up;
		Instantiate (enemy2);

		//top right
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy3.transform.position = new Vector3(6.0f,4.0f,0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Down;
		Instantiate (enemy3);

		//top left
		GameObject enemy4 = (GameObject)Resources.Load ("Enemies/TankEnemies/TankEnemyLevel1");
		enemy4.transform.position = new Vector3(-2.0f,4.0f,0f);
		enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy4.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Down;
		Instantiate (enemy4);

	}
}
