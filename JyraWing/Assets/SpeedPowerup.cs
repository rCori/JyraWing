using UnityEngine;
using System.Collections;

public class SpeedPowerup : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			other.GetComponent<Player>().IncreaseSpeedCap();
			Destroy(gameObject);
		}
	}
}
