using UnityEngine;
using System.Collections;

public interface IPowerupGroupController {

	bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID);

	PowerupGroup.PowerupType GetPowerupTypeFromGroupByID(int i_powerupGroupID);
	
	void AddSquad(PowerupGroup group);

	void RemoveSquad(PowerupGroup group);

	int GetNextSquadID();

	int GetNumberOfSquads();

	bool IsSquadListed(PowerupGroup group);
	bool IsSquadListed(int groupID);


}
