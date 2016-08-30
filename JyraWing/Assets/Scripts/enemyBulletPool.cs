using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBulletPool : MonoBehaviour {

	/// <summary>
	/// Total number of bullets in the pool
	/// </summary>

	public int totalBullets;

	///<summary>
	/// This pool will contains all bullets for all enemies
	/// </summary>
	List<GameObject> bulletPool;
	
	/// <summary>
	/// What kind of bullet pool is this? A pool of shieldable bullets or a pool of unshieldable bullets?
	/// </summary>
	public bool shieldablePool;

	// Use this for initialization
	void Start () {
		//Create the bullet pool, a list of GameObjects with the EnemyBullet script on it.
		bulletPool = new List<GameObject> ();
		for (int i = 0; i < totalBullets; i++) {
//			//Create bullet to put in pool.
//			GameObject bullet;
//			//Determine what kind of bullets are going in the pool
//			if(shieldablePool){
//				bullet = Resources.Load ("EnemyBulletShieldable") as GameObject;
//			}
//			else{
//				bullet = Resources.Load ("EnemyBullet") as GameObject;
//			}
//			bullet.transform.position = new Vector2(0f,10f);
//			bullet = Instantiate(bullet);
//			bullet.gameObject.SetActive(true);
//			bulletPool.Add(bullet);
			GameObject newBullet = addBullet();
			bulletPool.Add(newBullet);
		}
	}


	public GameObject GetBullet(){
		for (int i= 0; i < totalBullets; i++) {
			GameObject bulletObj = bulletPool [i];
			EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet> ();
			if (!bullet.GetIsActive ()) {;
				return bulletObj;
			}
		}
		//If no bullet of this type exists, create one and call recursivly to get it
		GameObject newBullet = addBullet();
		bulletPool.Add(newBullet);
		return newBullet;
	}

	private GameObject addBullet() {
		GameObject bullet;
		//Determine what kind of bullets are going in the pool
		if(shieldablePool){
			bullet = Resources.Load ("EnemyBulletShieldable") as GameObject;
		}
		else{
			bullet = Resources.Load ("EnemyBullet") as GameObject;
		}
		bullet.transform.position = new Vector2(0f,10f);
		bullet = Instantiate(bullet);
		bullet.gameObject.SetActive(true);
		return bullet;
	}

}
