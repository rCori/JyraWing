using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IUIController {
		
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

	int GetStartingLifeCount();

	void SetShieldPercentage(int percentage);

	int GetShieldPercentage();

}
