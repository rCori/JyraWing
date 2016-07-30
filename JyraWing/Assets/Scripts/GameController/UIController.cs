using UnityEngine;
using System.Collections;

public class UIController : IUIController {

	//local variable version of ShieldPErcentage, the number
	//that shows how much shield power the player has left
	int shieldPercentage;

	//Number of lives displayed by the UI
	int lifeCount;
	//The user can set a default number of lives the player would have
	int startingLifeCount;

	public UIController(){
		//Set all of these variables to 0
		lifeCount = 3;
		shieldPercentage = 100;
		startingLifeCount = 3;
	}
		
	//Set the default number of lives that life count will be set to
	//when InitializeLifeCount is called.
	public void SetDefaultLifeCount(int newDefaultLifeCount){
		startingLifeCount = newDefaultLifeCount;
	}

	/// Set the life count back to the default
	public void InitializeLifeCount(){
		lifeCount = startingLifeCount;
	}

	public void IncreaseLifeCount(){
		lifeCount++;
	}
	
	public void DecreaseLifeCount(){
		//Life count should never go negative so prevent that
		if (lifeCount > 0) {
			lifeCount--;
		}
	}
		

	//Return lifeCount for use by the UI GameObject
	public int GetLifeCount(){
		return lifeCount;
	}

	public int GetStartingLifeCount() {
		return startingLifeCount;
	}

	public void SetShieldPercentage(int percentage) {
		shieldPercentage = percentage;
	}

	public int GetShieldPercentage() {
		return shieldPercentage;
	}

}
