using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Keeps track of what powerup if any that an enemy should spawn if it is destroyed.
/// </summary>
public class SpawnPowerup : MonoBehaviour {

	public enum PowerupType{None = 0, Speed, Bullet};

	private GameObject powerupObject;


	void Start(){
	}

	void OnDestroy(){
	}

	public void SetPowerupType(PowerupType i_powerupType){
		switch (i_powerupType) {
		case PowerupType.Speed:
			powerupObject = Resources.Load ("Pickups/SpeedPowerup") as GameObject;
			break;
		default:
			break;
		}
	}
	
	/// <summary>
	/// Call this before calling OnDestroy on what should spawn the powerup	
	/// </summary>
	public void CreatePower(){
		//Debug.Log (powerupType);
		if (powerupObject) {
			powerupObject.transform.position = gameObject.transform.position;
			Instantiate(powerupObject);
		}
	}
	
}
