using UnityEngine;
using System.Collections;

/*
 * Goals:
 * Rewrite GameController to be more testable.
 * To do this it would contain a series of different interfaces.
 * The other option would to have an interface for this class itself and then have an implementation of it.
 * The suggested action is to implement all of the interfaces in GameControllerBehaviour, but I don't like that
 * I will make those seperate concreate classes, where I can write custom test double besides them if I need to.
 * The other responsibility of GameControllerBehaviour would be to handle all Unity API dependencies that are hard to test
 * Every call here would be a direct call to one of those interfaces
 * This class would also contain as many of the members as possible that wouldn't belong to the interfaces
 * As few as possible would be in the behaviour api handling class.
 * 
 * First lets list all of the responsibilities of this class
 * Spawning enemy powerups
 * Handling enemy powerup groups
 * Registering enemy groups to a list.
 * Handling UI elements and events.
 * Pausing all pausable items
 * Registering pausable items to a list
 * Receive the event of the level being finished
 * Handle the event of the level being finished
 * Receive the event of a player game over
 * Handle the event of a player game over
 * Safe return of the player position
 * 
 * Good candidates for interfaces:
 * IPowerupGroupController
 * IUIController
 * IPauseController
 * IPlayerController
 * ILevelController
 * 
 * Now in all of these responsibilities, what are some individual units of function we can think of?
 * 
 * For powerups:
 * Initialize the powerup group.(I think the constructor can implicitly do this)
 * Signal the spawning of powerup
 * Get the powerup gameobject from a group
 * Position and spawn a powerup
 * Adding a powerup squad to the squad list
 * Remove a squad from the squad list
 * Get the length of the squad list
 * Get the next squad ID.
 * Check if a squad still exists
 * Owns the squad list.
 * Owns the next squad ID.
 */

public class GameControllerRewrite {

	IPowerupGroupController powerupGroupController;

	public void InitializePowerupGroup(){
		powerupGroupController.InitializePowerupGroup ();
	}

	public bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID){
		bool returnValue = powerupGroupController.CheckShouldSpawnPowerupGroup(i_powerupgroupID);
		return returnValue;
	}

	public GameObject GetPowerupFromGroupByID(int i_powerupGroupID){
		GameObject returnObject = powerupGroupController.GetPowerupFromGroupByID (i_powerupGroupID);
		return returnObject;
	}

	public void SpawnPowerupAtPostion(Vector3 i_position, GameObject obj){

	}

	public int GetNextSquadID(){
		int returnValue = powerupGroupController.GetNextSquadID ();
		return returnValue;
	}

	public void SetPowerupGroupController(IPowerupGroupController i_powerupGroupController)
	{
		powerupGroupController = i_powerupGroupController;
	}
}
