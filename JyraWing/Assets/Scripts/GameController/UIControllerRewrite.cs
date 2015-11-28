using UnityEngine;
using System.Collections;

public class UIControllerRewrite : IUIController {

	//local variable for AvailableSpeed in the interface
	int availableSpeed;

	//Local variable for ActiveSpeed in the interface
	int activeSpeed;

	//local variable version of ShieldPErcentage, the number
	//that shows how much shield power the player has left
	int shieldPercentage;

	//Number of lives displayed by the UI
	int lifeCount;
	//The user can set a default number of lives the player would have
	int defaultLifeCount;

	//When lifeCount changes this is set to true so the UI objects know to update
	bool updateLifeCount;
	//When anything about speed changes this is set to true so the UI objects know
	//to update
	bool updateSpeed;
	//When the shield percentage needs to be updated(which it frequently does), this is set to true
	bool updateShieldPercentage;

	public UIControllerRewrite(){
		//Set all of these variables to 0
		lifeCount = 3;
		activeSpeed = 0;
		availableSpeed = 0;
		defaultLifeCount = 3;
		updateLifeCount = false;
		updateSpeed = false;
	}

	/* Implementation of the interface properties */
	public int AvailableSpeed{
		get{
			return availableSpeed + 1;
		}
		set{
			availableSpeed = value;
			updateSpeed = true;
		}

	}
	public int ActiveSpeed{
		get{
			return activeSpeed + 1;
		}
		set{
			activeSpeed = value;
			updateSpeed = true;
		}
	}

	public int ShieldPercentage{
		get {
			return shieldPercentage;
		}
		set{
			//Only set and update if it is a new value because many times it will not be.
			if(value != shieldPercentage){
				shieldPercentage = value;
				updateShieldPercentage = true;
			}
		}
	}

	//Set the default number of lives that life count will be set to
	//when InitializeLifeCount is called.
	public void SetDefaultLifeCount(int newDefaultLifeCount){
		defaultLifeCount = newDefaultLifeCount;
	}

	/// Set the life count back to the default
	public void InitializeLifeCount(){
		lifeCount = defaultLifeCount;
		updateLifeCount = true;
	}

	public void IncreaseLifeCount(){
		lifeCount++;
		updateLifeCount = true;
	}
	
	public void DecreaseLifeCount(){
		//Life count should never go negative so prevent that
		if (lifeCount > 0) {
			lifeCount--;
			updateLifeCount = true;
		}
	}

	//Return lifeCount for use by the UI GameObject
	public int GetLifeCount(){
		updateLifeCount = true;
		return lifeCount;
	}

	//check the flag to update the life count.
	//By default also set that flag back to false if it returned true
	public bool ShouldUpdateLifeCount(bool resetFlag = true){
		bool returnValue = updateLifeCount;
		//If the  flag is set and the user has requested it be reset then do so
		if (resetFlag && updateLifeCount) {
			updateLifeCount = false;
		}
		//Return the original value of updateLifeCount
		return returnValue;
	}

	//The user can reset the updateLifeCount flag manually without checking it first
	public void FinishedLifeCountUpdate(){
		updateLifeCount = false;
	}

	//check the flag to update the speed.
	//By default also set that flag back to false if it returned true
	public bool ShouldUpdateSpeed(bool resetFlag = true){
		bool returnValue = updateSpeed;
		//If the  flag is set and the user has requested it be reset then do so
		if (resetFlag && updateSpeed) {
			updateSpeed = false;
		}
		//Return the original value of updateSpeed
		return returnValue;
	}
	
	//The user can reset the updateSpeed flag manually without checking it first
	public void FinishedSpeedUpdate(){
		updateSpeed = false;
	}

	//check the flag to update the shield percentage.
	//By default also set that flag back to false if it returned true
	public bool ShouldUpdateShieldPercentage(bool resetFlag = true){
		bool returnValue = updateShieldPercentage;
		//If the  flag is set and the user has requested it be reset then do so
		if (resetFlag && updateShieldPercentage) {
			updateShieldPercentage = false;
		}
		//Return the original value of updateSpeed
		return returnValue;
	}
	
	//The user can reset the updateShieldPercentage flag manually without checking it first
	public void FinishedShieldPercentageUpdate(){
		updateShieldPercentage = false;
	}
}
