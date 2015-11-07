using UnityEngine;
using System.Collections;

public class EnemySpawn6 : EnemySpawner {

	public bool spawnBullet;

	public override void Spawn ()
	{
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool>();

		Vector3 spawnPos = gameObject.transform.position;
		GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy1.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y,
		                                        spawnPos.z);
		enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy1.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Left;
		enemy1 = Instantiate (enemy1);
		
		GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_E");
		enemy2.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y-1.5f,
		                                        spawnPos.z);
		enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy2.GetComponent<EnemyAI5> ().direction = EnemyAI5.TankDir.Left;
		enemy2 = Instantiate (enemy2);
		
		GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_D");
		enemy3.transform.position = new Vector3(spawnPos.x+0.5f,
		                                        spawnPos.y+1.5f,
		                                        spawnPos.z);
		enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
		enemy3 = Instantiate (enemy3);

		if (spawnBullet) {
			GameController controller = GameObject.Find ("GameController").GetComponent<GameController> ();
			
			//hardcoding groupID, in the future I cannot do that.
			PowerupGroup group = new PowerupGroup (controller.GetNextSquadID());
			
			group.SetPowerupType (PowerupGroup.PowerupType.Bullet);

			group.AddToSquad (enemy3);
			
			controller.AddSquad (group);
		}
	}
}
