using System;
using NUnit.Framework;
using UnityEngine;

public class PowerupGroupControllerTest{
	[Test]
	public void SquadList_IsListedAfterAddSquad(){
		//Arrange
		PowerupGroupController powerupGroupController = new PowerupGroupController ();
		PowerupGroup group = new PowerupGroup (powerupGroupController.GetNextSquadID());
		//Act
		powerupGroupController.AddSquad (group);
		//Assert
		//Check that the group is present in the PowerupGroupController
		bool isGroupPresent = powerupGroupController.IsSquadListed (group);
		Assert.That (isGroupPresent);
	}

	[Test]
	public void SquadList_IsDeListedAfterRemoveSquad(){
		//Arrange
		PowerupGroupController powerupGroupController = new PowerupGroupController ();
		PowerupGroup group = new PowerupGroup (powerupGroupController.GetNextSquadID());
		//Act
		powerupGroupController.AddSquad (group);
		powerupGroupController.RemoveSquad(group.GetPowerupGroupID());
		//Assert
		//Check that the group is present in the PowerupGroupController
		bool isGroupPresent = powerupGroupController.IsSquadListed (group);
		Assert.That (!isGroupPresent);
	}

	[Test]
	public void SquadID_NoRepeatIDs(){
		//Arrange
		PowerupGroupController powerupGroupController = new PowerupGroupController ();
		//Act
		int groupID1 = powerupGroupController.GetNextSquadID ();
		int groupID2 = powerupGroupController.GetNextSquadID ();
		//Assert
		//The two group IDs should not be the same
		bool groupIDsRepeated = groupID1 == groupID2;
		Assert.That (!groupIDsRepeated);
	}

	//I cannot do further testing until PowerupGroup is decoupled from dependency on GameObject.
	
}
