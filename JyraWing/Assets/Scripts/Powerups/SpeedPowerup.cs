using UnityEngine;
using System.Collections;

public class SpeedPowerup : PowerupObject {
	


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//other.GetComponent<Player>().IncreaseSpeedCap();
			PlayPickupsfx();
			Destroy(gameObject);
		}
	}

}
