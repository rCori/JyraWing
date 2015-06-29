using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps track of what powerup if any that an enemy should spawn if it is destroyed.
/// </summary>
public class SpawnPowerup : MonoBehaviour {

	public enum PowerupType{None = 0, Speed};

	private PowerupType powerupType;

	private GameObject powerupObject;

	void Start(){
		powerupType = PowerupType.None;
	}

	void OnDestroy(){
		Debug.Log ("SpawnPowerup");
	}

	void SetPowerupType(PowerupType i_powerupType){
		powerupType = i_powerupType;
	}

	PowerupType GetPowerupType(){
		return powerupType;
	}

	/// <summary>
	/// Call this before calling OnDestroy on what should spawn the powerup	
	/// </summary>
	void CreatePower(){
		if (powerupObject && powerupType != PowerupType.None) {
			powerupObject.transform.position = gameObject.transform.position;
			Instantiate(powerupObject);
		}
	}
}
