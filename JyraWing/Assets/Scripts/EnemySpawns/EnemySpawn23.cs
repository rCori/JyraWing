using UnityEngine;
using System.Collections;

public class EnemySpawn23 : EnemySpawner {

	public int EnemyHealth = 3;

	public float vertShift = 5;
	public float oscillation = -1.5f;

	// Use this for initialization
	public override void Spawn(){
		EnemyBulletPool bulletPool = GameObject.Find ("EnemyBulletPool").GetComponent<EnemyBulletPool> ();
		EnemyBulletPool shieldableBulletPool = GameObject.Find ("EnemyShieldableBulletPool").GetComponent<EnemyBulletPool> ();


		{
			//first enemy from the bottom
			GameObject enemy1 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy1.transform.position = new Vector2 (vertShift, 5f);

			enemy1.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy1.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy1.GetComponent<EnemyBehavior> ().LeftWallException = false;

			EnemyAI11 enemy1AI11 = enemy1.GetComponent<EnemyAI11> ();
			enemy1AI11.oscillationFactor = oscillation;
			enemy1AI11.delayTimer = 0f;
			enemy1AI11.ySpeed = -2.0f;
			enemy1AI11.fireTimeLimit = 0.8f;
			enemy1 = Instantiate (enemy1);
		}
		{
			//second enemy from the bottom
			GameObject enemy2 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy2.transform.position = new Vector2 (vertShift, 5f);
		
			enemy2.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy2.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy2.GetComponent<EnemyBehavior> ().LeftWallException = false;
		
			EnemyAI11 enemy2AI11 = enemy2.GetComponent<EnemyAI11> ();
			enemy2AI11.oscillationFactor = oscillation;
			enemy2AI11.delayTimer = 1.0f;
			enemy2AI11.ySpeed = -2.0f;
			enemy2AI11.fireTimeLimit = 1.5f;
			enemy2 = Instantiate (enemy2);
		}
		{
			//third enemy from the bottom
			GameObject enemy3 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy3.transform.position = new Vector2 (vertShift, 5f);
		
			enemy3.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy3.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy3.GetComponent<EnemyBehavior> ().LeftWallException = false;
		
			EnemyAI11 enemy3AI11 = enemy3.GetComponent<EnemyAI11> ();
			enemy3AI11.oscillationFactor = oscillation;
			enemy3AI11.delayTimer = 2.0f;
			enemy3AI11.ySpeed = -2.0f;
			enemy3AI11.fireTimeLimit = 1.1f;
			enemy3 = Instantiate (enemy3);
		}
		{
			//second enemy from the bottom
			GameObject enemy4 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy4.transform.position = new Vector2 (vertShift, 5f);
		
			enemy4.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy4.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy4.GetComponent<EnemyBehavior> ().LeftWallException = false;
		
			EnemyAI11 enemy4AI11 = enemy4.GetComponent<EnemyAI11> ();
			enemy4AI11.oscillationFactor = oscillation;
			enemy4AI11.delayTimer = 3.0f;
			enemy4AI11.ySpeed = -2.0f;
			enemy4AI11.fireTimeLimit = 0.9f;
			enemy4 = Instantiate (enemy4);
		}

		{
			//second enemy from the bottom
			GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy5.transform.position = new Vector2 (vertShift, -5f);
			
			enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy5.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy5.GetComponent<EnemyBehavior> ().LeftWallException = false;
			
			EnemyAI11 enemy5AI11 = enemy5.GetComponent<EnemyAI11> ();
			enemy5AI11.oscillationFactor = oscillation;
			enemy5AI11.delayTimer = 0.5f;
			enemy5AI11.ySpeed = 2.0f;
			enemy5AI11.fireTimeLimit = 1.8f;
			enemy5 = Instantiate (enemy5);
		}
		{
			//second enemy from the bottom
			GameObject enemy6 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy6.transform.position = new Vector2 (vertShift, -5f);
			
			enemy6.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy6.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy6.GetComponent<EnemyBehavior> ().LeftWallException = false;
			
			EnemyAI11 enemy6AI11 = enemy6.GetComponent<EnemyAI11> ();
			enemy6AI11.oscillationFactor = oscillation;
			enemy6AI11.delayTimer = 1.5f;
			enemy6AI11.ySpeed = 2.0f;
			enemy6AI11.fireTimeLimit = 1.8f;
			enemy6 = Instantiate (enemy6);
		}
		{
			//second enemy from the bottom
			GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy5.transform.position = new Vector2 (vertShift, -5f);
			
			enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy5.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy5.GetComponent<EnemyBehavior> ().LeftWallException = false;
			
			EnemyAI11 enemy5AI11 = enemy5.GetComponent<EnemyAI11> ();
			enemy5AI11.oscillationFactor = oscillation;
			enemy5AI11.delayTimer = 2.5f;
			enemy5AI11.ySpeed = 2.0f;
			enemy5AI11.fireTimeLimit = 1.3f;
			enemy5 = Instantiate (enemy5);
		}		
		{
			//second enemy from the bottom
			GameObject enemy5 = (GameObject)Resources.Load ("Enemies/Enemy_K");
			enemy5.transform.position = new Vector2 (vertShift, -5f);
			
			enemy5.GetComponent<EnemyBehavior> ().bulletPool = bulletPool;
			enemy5.GetComponent<EnemyBehavior> ().shieldableBulletPool = shieldableBulletPool;
			enemy5.GetComponent<EnemyBehavior> ().LeftWallException = false;
			
			EnemyAI11 enemy5AI11 = enemy5.GetComponent<EnemyAI11> ();
			enemy5AI11.oscillationFactor = oscillation;
			enemy5AI11.delayTimer = 3.5f;
			enemy5AI11.ySpeed = 2.0f;
			enemy5AI11.fireTimeLimit = 1.0f;
			enemy5 = Instantiate (enemy5);
		}


	}

}
