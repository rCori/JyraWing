using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupGroupController : IPowerupGroupController {

	/// <summary>
	/// The next squad ID.
	/// Returned by GetNextSquadID and modified when a squad
	/// is added or removed from the list
	/// </summary>
	private int nextSquadID;
	/// <summary>
	/// Keep track of and handle every PowerupGroup that currently exists.
	/// </summary>
	private List<PowerupGroup> squadList;

	//Constructor. All it needs to do is initialize two fields
	PowerupGroupController(){
		nextSquadID = 0;
		squadList = new List<PowerupGroup>();
	}

	public void InitializePowerupGroup(){
	}

	public bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID){
		//Iterate through all PowerupGroups in squadList
		foreach (PowerupGroup currentGroup in squadList) {
			//If the group searched for is found
			if(currentGroup.GetPowerupGroupID() == i_powerupgroupID){
				//If the group has been destroyed without the group being
				//removed without having the squad itself removed, then a
				//powerup should be spawned
				if(currentGroup.IsSquadGone ()){
					return true;
				}
				//If not, the group was found but we should spawn a powerup
				//so return false now.
				else{
					return false;
				}
			}
		}
		//If the group was never found, no powerup should spawn
		return false;
	}
	
	public GameObject GetPowerupFromGroupByID(int i_powerupGroupID){
		//Iterate through all PowerupGroups in squadList
		foreach (PowerupGroup currentGroup in squadList) {
			//Check if we have founf the selected PowerupGroup
			if(currentGroup.GetPowerupGroupID() == i_powerupGroupID){
				//Return that PowerupGroup's GameObject
				return currentGroup.ReturnPowerupObject();
			}
		}
		//If the PowerupGroup was never found then return a null object
		GameObject obj = new GameObject();
		return obj;
	}
	

	public void AddSquad(PowerupGroup group){
		//Check if the group is not already present
		bool alreadyPresent = IsSquadListed (group);
		//If it is, return now
		if (alreadyPresent) {
			return;
		}
		//If not, push the group onto the stack
		else {
			squadList.Add(group);
		}
	}
	
	public void RemoveSquad(PowerupGroup group){
		//Make sure the group is present
		bool isPresent = IsSquadListed (group);
		//If the squad is not listed, return early
		if (!isPresent) {
			return;
		}
		//If it is handle it
		else {
			//We must set the squad IDs of any remaining squad members 
			//to -1, taking them out of the squad before removing it
			group.RemoveAllFromSquad ();
			//Now remove the group from the actual list
			squadList.Remove(group);
		}
	}

	public int GetNextSquadID(){
		//Everytime this is requested, it is requested for making the 
		//next squad. We increase it each time for this reason
		nextSquadID++;
		return nextSquadID;
	}

	public int GetNumberOfSquads(){
		//Return the count of the list
		return squadList.Count;
	}

	//We need to know if a squad is present in squadList
	public bool IsSquadListed(PowerupGroup group){
		//Iterate through each group in the squadList
		foreach(PowerupGroup currentGroup in squadList){
			//determine if this is the argument group by using ID
			if(currentGroup.GetPowerupGroupID() == group.GetPowerupGroupID()){
				//It's the same group. We found it. Return true.
				return true;
			}
		}
		//If we have gone through squadList and not found the group
		//it is not present so return false.
		return false;
	}

	public bool IsSquadListed(int squadID){
		//Iterate through each group in the squadList
		foreach(PowerupGroup currentGroup in squadList){
			//Determine if this is the group ID being searched for.
			if(currentGroup.GetPowerupGroupID() == squadID){
				//Group found. Return true.
				return true;
			}
		}
		//If we have gone through squadList and not found the group
		//it is not present so return false.
		return false;
	}

}
