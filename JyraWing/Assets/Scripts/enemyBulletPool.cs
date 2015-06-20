using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyBulletPool : MonoBehaviour {

	/// <summary>
	/// Total number of bullets in the pool
	/// </summary>

	public int totalBullets;

	///<summary>
	/// This pool will contains all bullets for all enemies
	/// </summary>
	List<GameObject> bulletPool;


	// Use this for initialization
	void Start () {
		bulletPool = new List<GameObject> ();
		for (int i = 0; i < totalBullets; i++) {
			//Put all the bullet live in the pool
			GameObject bullet = Resources.Load ("EnemyBullet") as GameObject;
			bullet.transform.position = new Vector2(0f,10f);
			bullet = Instantiate(bullet);
			bullet.gameObject.SetActive(true);
			bulletPool.Add(bullet);
		}
	}


	public GameObject GetBullet(){
		for (int i= 0; i < totalBullets; i++) {
			GameObject bulletObj = bulletPool [i];
			EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet> ();
			if (!bullet.GetIsActive ()) {
				return bulletObj;
			}
		}
		return null;
	}
}
