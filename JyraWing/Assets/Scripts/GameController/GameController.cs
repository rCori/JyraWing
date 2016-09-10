using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
 * 
 * For PowerupGroupController:
 * Initialize the powerup group list.(I think the constructor can implicitly do this)
 * Signal the spawning of powerup
 * Get the powerup type from a group
 * Adding a powerup squad to the squad list
 * Remove a squad from the squad list
 * Get the next squad ID.
 * Check if a squad still exists
 * 
 * 
 * For UIController
 * This includes code from UIController and GameController
 * Initialize what the default life count is
 * Reset the life count to that default
 * Increase lives by one
 * Decrease lives by one
 * 
 * 
 * For PauseController
 * Own the isPaused flag
 * Own the List of pausable items
 * Pause all items in the pausable item list 
 * Unpause all items in the pausable item list
 * Register an item to the list of PauseableItems
 * Remove an item from the list of PauseableItems
 * 
 * 
 * Set flags from handling GameOverState for showing the level complete ui, 
 * showing the game over ui, disabling the player, and loading the title scene
 * 
 * 
 * For PlayerController
 * Get the player location
 * Set the player object enabled
 * Get the player speed count
 * Get the player speed count cap
 * Get the player life count
 * 
 * Life player count shouldn't be part of the player code, but part of the PlayerController contained
 * in the gameController. Same with the speed variables
 */

//This is used in ILevelController
public enum GameOverState{None = 0, FinishNoEffect, FinishShowScreen, KillAnimation, KillNoEffect, KillShowScreen};

public class GameController {

	IPowerupGroupController powerupGroupController;

	public Vector3 playerPosition;

	public delegate void GameControllerEvent();
	public static event GameControllerEvent GameOverEvent;

	//Set the powerup group controller for the game controller
	public void SetPowerupGroupController(IPowerupGroupController i_powerupGroupController){
		powerupGroupController = i_powerupGroupController;
	}

	public bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID){
		bool returnValue = powerupGroupController.CheckShouldSpawnPowerupGroup(i_powerupgroupID);
		return returnValue;
	}

	public PowerupGroup.PowerupType GetPowerupTypeFromGroupByID(int i_powerupGroupID){
		PowerupGroup.PowerupType returnPowerupType = powerupGroupController.GetPowerupTypeFromGroupByID (i_powerupGroupID);
		return returnPowerupType;
	}

	public void AddSquad(PowerupGroup group){
		powerupGroupController.AddSquad (group);
	}

	public void RemoveSquad(int groupID){
		powerupGroupController.RemoveSquad(groupID);
	}

	public int GetNextSquadID(){
		int returnValue = powerupGroupController.GetNextSquadID ();
		return returnValue;
	}

	public bool IsSquadListed(int groupID){
		bool returnValue = powerupGroupController.IsSquadListed(groupID);
		return returnValue;
	}

	public bool IsSquadListed(PowerupGroup group){
		bool returnValue = powerupGroupController.IsSquadListed(group);
		return returnValue;
	}

	public bool IsPowerupSpawnQueued(){
		return powerupGroupController.IsPowerupSpawnQueued ();
	}

	public void QueuePowerupSpawn(Vector3 i_position, PowerupGroup.PowerupType type){
		powerupGroupController.QueuePowerupSpawn (i_position, type);
	}

	public PowerupGroup.PowerupType QueuedPowerupType{
		get{
			return powerupGroupController.QueuedPowerupType;
		}
	}
	
	public Vector3 QueuedPowerupLocation{
		get{
			return powerupGroupController.QueuedPowerupLocation;
		}
	}
		

	public void PlayerKilled(){
		GameOverEvent ();
	}
		

}
