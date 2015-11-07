using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A test double for the GameController class. The idea here is to redefine some functions
/// and put some logging in them as a first pass on testing the GameController.
/// </summary>
/// Since creating this class every member of GameController that was private is now protected
/// so this calss can have access.
public class GameControllerTestDouble : GameController{

	protected int totalItemsPaused;
	protected int totalRegisteredSquads;
	protected bool powerupWasSpawned;

	void Awake()
	{
		pauseList = new List<PauseableItem> ();
		totalItemsPaused = 0;
		totalRegisteredSquads = 0;
		powerupWasSpawned = false;
	}

	///Allows the user to pause all items that have been registered to pause
	public new void PauseAllItems()
	{
		foreach(PauseableItem item in pauseList)
		{
			item.paused = true;
			totalItemsPaused++;
		}
		isPaused = true;
	}

	public new void AddSquad(PowerupGroup i_powerupGroup){
		totalRegisteredSquads++;
		squadList.Add (i_powerupGroup);
	}

	public new bool SpawnGroupPower(int i_id, Vector3 i_position){
		if (squadList.Count > 0) {
			foreach (PowerupGroup group in squadList) {
				//If this is the group we are looking for.
				if (group.GetPowerupGroupID () == i_id) {
					//Get the powerup object
					GameObject powerup = new GameObject();
					//Find what powerup object we should be spawning
					PowerupGroup.PowerupType powerupType = group.ReturnPowerupType();
					//Use a switch case to load the correct powerup type
					switch(powerupType){
					case PowerupGroup.PowerupType.Speed:
						powerup = Resources.Load ("Pickups/SpeedPowerup") as GameObject;
						break;
					case PowerupGroup.PowerupType.Bullet:
						powerup = Resources.Load ("Pickups/BulletPowerup") as GameObject;
						break;
					default:
						break;
					}
					//GameObject powerup = group.ReturnPowerupObject ();
					//Set the position to the position given
					powerup.transform.position = i_position;
					//Instantiate the powerup
					Instantiate (powerup);
					powerupWasSpawned = true;
					return true;
				}
				
			}
		}
		return false;
	}

	public int GetTotalItemsPaused(){
		//Save the value to return
		int returnVal = totalItemsPaused;
		//Set the the number of total items paused back to 0 for the sake of testing
		totalItemsPaused = 0;
		//Return the int we stored.
		return returnVal;
	}

	public int GetTotalRegisteredSquads(){
		//Save the value to return
		int returnVal = totalRegisteredSquads;
		//Set the the number of total items paused back to 0 for the sake of testing
		totalRegisteredSquads = 0;
		//Return the int we stored.
		return returnVal;
	}

	public bool GetWasPowerupSpawned(){
		bool returnVal = powerupWasSpawned;
		powerupWasSpawned = false;
		return returnVal;
	}
}
