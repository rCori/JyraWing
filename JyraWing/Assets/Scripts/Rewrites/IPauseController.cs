using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public interface IPauseController{

	//Interface properties will be captialized, the implementation versions
	//will not be

	//isPaused will be part of the interface because it is critical to
	//how this interface works. Needs to be read-only
	bool IsPaused {
		get;
	}

	List<PauseableItem> PauseList {
		get;
	}

	//Pause all items contained in PauseList
	void PauseAllItems();

	//Unpause all items contained in PauseList
	void Unpause();

	//Register a pauseable item to the list
	void RegisterPausableItem(PauseableItem item);

	//Remove a pausable item from the list
	void DelistPauseableItem(PauseableItem item);

}
