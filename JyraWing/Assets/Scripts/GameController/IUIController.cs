using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IUIController {

	//How many speed levels the UI will show are available
	int AvailableSpeed {
		get;
		set;
	}

	//How many speed levels the UI will show are active
	int ActiveSpeed {
		get;
		set;
	}

	//These four functions outline all of the interaction the client of the interface
	//should have to have with a life count variaible
	void SetDefaultLifeCount(int defaultLifeCount);
	
	/// Set the life count back to the default
	void InitializeLifeCount();
	
	void IncreaseLifeCount();

	void DecreaseLifeCount();

	//This will return the integer of how many lives are left. It's up the the MonoBehaviour to make a string
	//or whatever representation out of it.
	int GetLifeCount();

	//When the MonoBehaviour needs to know if the UI gameobject for life count needs to be updated they will 
	//call this to see if the state of the life count has changed
	bool ShouldUpdateLifeCount(bool resetFlag = true);

	//When the MonoBehaviour that updates the GameObject for the UI representation of the life count has
	//updated that UI element, it will call this to reset the flag.
	//I want some way to enforce this happens.
	void FinishedLifeCountUpdate();


	//The speed variables are more directly modifiable for the user so this is the only function
	//relates to speed UI that we need.

	//When the MonoBehaviour needs to know if the UI gameobjects for speed need to be updated they will 
	//call this to see if the state of the life count has changed
	bool ShouldUpdateSpeed(bool resetFlag = true);

	//When the MonoBehaviour that updates the GameObject for the UI representation of the life count has
	//updated that UI element, it will call this to reset the flag
	void FinishedSpeedUpdate();

}
