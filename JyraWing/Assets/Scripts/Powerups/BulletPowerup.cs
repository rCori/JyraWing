using UnityEngine;
using System.Collections;

public class BulletPowerup : PowerupObject {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.GetComponent<Player>().IncreaseBulletLevel();
			Destroy(gameObject);
		}
	}
}
