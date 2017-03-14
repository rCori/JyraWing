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
	List<GameObject> bulletObjPool;
	List<EnemyBullet> bulletPool;

    private EnemyBehavior bossBehavior;

	/// <summary>
	/// What kind of bullet pool is this? A pool of shieldable bullets or a pool of unshieldable bullets?
	/// </summary>
	public bool shieldablePool;

	// Use this for initialization
	void Start () {
        bossBehavior = null;
		//Create the bullet pool, a list of GameObjects with the EnemyBullet script on it.
		bulletObjPool = new List<GameObject> ();
		bulletPool = new List<EnemyBullet> ();
		for (int i = 0; i < totalBullets; i++) {
			//Create bullet to put in pool.
			GameObject newBulletObj = addBullet();
			EnemyBullet newBullet = newBulletObj.GetComponent<EnemyBullet> ();
			bulletObjPool.Add(newBulletObj);
			bulletPool.Add (newBullet);
		}
	}


	public GameObject GetBullet(){
		for (int i= 0; i < totalBullets; i++) {
			GameObject bulletObj = bulletObjPool [i];
			EnemyBullet bullet = bulletPool[i];
			if (!bullet.GetIsActive ()) {
				bullet.SetRendererEnabled (true);
				return bulletObj;
			}
		}
        //If no bullet of this type exists, create one and call recursivly to get it
        GameObject newBulletObj = addBullet();
        EnemyBullet newBullet = newBulletObj.GetComponent<EnemyBullet>();
        bulletObjPool.Add(newBulletObj);
        bulletPool.Add(newBullet);
        newBullet.SetRendererEnabled(true);
        totalBullets++;
        return newBulletObj;
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
        if(bossBehavior != null) {
            bullet.GetComponent<EnemyBullet>().GiveBossEvent(bossBehavior);
        }
		return bullet;
	}

    public void SetLevelBoss(EnemyBehavior bossBehavior) {
        this.bossBehavior = bossBehavior;
        foreach(EnemyBullet enemyBullet in bulletPool) {
            enemyBullet.GiveBossEvent(bossBehavior);
        }
    }
}
