using UnityEngine;
using System.Collections;

public class PlayerShield: IPlayerShield  {


	private float shieldPower;
	private float maxShieldPower;
	private bool shieldActive;

	public Vector3 _spritePosition;
	private bool enabled;

	public delegate void ShieldEvent (int value);
	public static event ShieldEvent SetShieldPercentageEvent; 

	/// <summary>
	/// Constructor that initializes maxShieldPower and sets shieldPower to be full
	/// </summary>
	public PlayerShield(){
		//this is representative of how much time the shield should last total
		maxShieldPower = 2f;
		//Intitialize shield should be full
		shieldPower = maxShieldPower;
		shieldActive = false;
		enabled = true;
	}

	public float GetShieldPercentage(){
		//Return this as a percentage out of 100
		return (shieldPower / maxShieldPower) * 100;
	}

	public bool HasShield(){
		return shieldActive;
	}

	public void UpdateShield(float timeDifference){
		if (shieldActive && shieldPower > 0f) {
			shieldPower -= Time.deltaTime;
			if(shieldPower < 0f){
				shieldPower = 0f;
				shieldActive = false;
			}
		}
		else if(!shieldActive && shieldPower <= maxShieldPower){
			shieldPower += Time.deltaTime;
			if(shieldPower > maxShieldPower){
				shieldPower = maxShieldPower;
			}
		}
		SetShieldPercentage((shieldPower/maxShieldPower)*100.0f);
	}

	private void SetShieldPercentage(float shieldPercentage) {
		shieldPower = (shieldPercentage/100.0f)*maxShieldPower;
		SetShieldPercentageEvent((int)shieldPercentage);
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

	public bool shieldEnabled {
		get {
			return enabled;
		}
	}

	public void ActivateShield() {
		if (shieldPower > 0f && enabled) {
			shieldActive = true;
		}
	}

	public void DeactivateShield() {
		shieldActive = false;
	}

	public void EnableShield() {
		enabled = true;
	}

	public void DisableShield() {
		enabled = false;
	}
}
