using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseController : IPauseController {

	//If the game is paused or not
	bool isPaused;

	//List of objects that will respond to the pause event
	List<PauseableItem> pauseList;

	//isPaused will satisfy for the interface's requirment of
	//a readable IsPaused
	public bool IsPaused{
		get{
			return isPaused;
		}

	}

	//pauseList will be publicly readable but not writeable
	//according to the IPauseController interface
	public List<PauseableItem> PauseList{
		get{
			return pauseList;
		}
	}

	//Set default values and inittalize the list for PauseableItems
	public PauseController(){
		isPaused = false;
		pauseList = new List<PauseableItem> ();
        EnemyBehavior.RegisterPauseController += RegisterPausableItem;
        EnemyBehavior.DelistPauseController += DelistPauseableItem;
	}

	//Pause every item in pauseList
	public void PauseAllItems(){
		foreach(PauseableItem item in pauseList)
		{
			item.paused = true;
		}
		//The game is paused now
		isPaused = true;
	}
	
	//Unpuase every item in pauseList
	public void Unpause(){
		//iterate through every registered item
		foreach(PauseableItem item in pauseList)
		{
			item.paused = false;
		}
		//The game is no longer paused
		isPaused = false;
	}

	//Add a PauseableItem to pauseList
	public void RegisterPausableItem(PauseableItem item){
		pauseList.Add (item);
	}

	//Remove a PauseableItem from pauseList
	public void DelistPauseableItem(PauseableItem item){
		pauseList.Remove (item);
	}

	public void Purge() {
		pauseList.Clear ();
	}

}
