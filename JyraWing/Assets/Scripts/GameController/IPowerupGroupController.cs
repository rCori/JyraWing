using UnityEngine;
using System.Collections;

public interface IPowerupGroupController {

	PowerupGroup.PowerupType QueuedPowerupType {
		get;
	}

	Vector3 QueuedPowerupLocation {
		get;
	}

	bool IsPowerupSpawnQueued();

	void QueuePowerupSpawn(Vector3 i_position, PowerupGroup.PowerupType type);

	bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID);

	PowerupGroup.PowerupType GetPowerupTypeFromGroupByID(int i_powerupGroupID);
	
	void AddSquad(PowerupGroup group);

	void RemoveSquad(int groupID);

	int GetNextSquadID();

	int GetNumberOfSquads();

	bool IsSquadListed(PowerupGroup group);
	bool IsSquadListed(int groupID);


}
