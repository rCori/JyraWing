using UnityEngine;
using System.Collections;

public class PlayerShield: IPlayerShield  {


	private float shieldPower;
	private float maxShieldPower;

	public Vector3 _spritePosition;

	/// <summary>
	/// Constructor that initializes maxShieldPower and sets shieldPower to be full
	/// </summary>
	public PlayerShield(){
		//this is representative of how much time the shield should last total
		maxShieldPower = 2f;
		//Intitialize shield should be full
		shieldPower = maxShieldPower;
	}

	public float GetShieldPercentage(){
		//Return this as a percentage out of 100
		return (shieldPower / maxShieldPower) * 100;
	}

	public bool HasShield(bool button){
		//If the player has shield
		if (shieldPower != 0) {
			return button;
		} else {
			return false;
		}
	}

	public void UpdateShield(float timeDifference, bool button){
		if (button && shieldPower > 0f) {
			shieldPower -= Time.deltaTime;
			if(shieldPower < 0f){
				shieldPower = 0f;
			}
		}
		else if(!button && shieldPower <= maxShieldPower){
			shieldPower += Time.deltaTime;
			if(shieldPower > maxShieldPower){
				shieldPower = maxShieldPower;
			}
		}
	}

	//property implementation is straightforward get and set
	public Vector3 spritePosition{
		get{
			return  _spritePosition;
		}
		set{
			_spritePosition = value;
		}
	}
}
