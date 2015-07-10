using UnityEngine;
using System.Collections;

public class EnemySpawn9 : EnemySpawner {

	public bool spawnBulletPowerup;

	public override void Spawn ()
	{
		enemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<enemyBulletPool> ();
		
		//bottom left
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy1.transform.position = new Vector3 (-6.0f, -1.5f, 0f);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai1 = enemy1.GetComponent<EnemyAI6> ();
		ai1.angle = 0f;
		ai1.speed = 2.0f;
		ai1.lifeTime = 12.0f;
		ai1.fireRate = 1.2f;
		ai1.bulletSpeed = 3.5f;
		enemy1.GetComponent<Scroll> ().speed = 0;
		enemy1 = Instantiate (enemy1);
		
		//top left
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy2.transform.position = new Vector3 (-6.0f, 1.5f, 0f);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai2 = enemy2.GetComponent<EnemyAI6> ();
		ai2.angle = 0f;
		ai2.speed = 2f;
		ai2.lifeTime = 12.0f;
		ai2.fireRate = 1.2f;
		ai2.bulletSpeed = 3.5f;
		enemy2.GetComponent<Scroll> ().speed = 0;
		enemy2 = Instantiate (enemy2);
		
		//mid right
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_H");
		enemy3.transform.position = new Vector3 (6.0f, 0.0f, 0f);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		EnemyAI6 ai3 = enemy3.GetComponent<EnemyAI6> ();
		ai3.angle = 180f;
		ai3.speed = 2f;
		ai3.lifeTime = 7.0f;
		ai3.fireRate = 1.2f;
		ai3.bulletSpeed = 3.5f;
		enemy3.GetComponent<Scroll> ().speed = 0;
		enemy3 = Instantiate (enemy3);


		if (spawnBulletPowerup) {
			GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
			
			//hardcoding groupID, in the future I cannot do that.
			PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
			
			group.SetPowerupObject (PowerupGroup.PowerupType.Bullet);
			
			group.AddToSquad (enemy1);
			group.AddToSquad (enemy2);
			group.AddToSquad (enemy3);
			
			controller.AddSquad (group);
		}

	}
}
