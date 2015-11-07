using UnityEngine;
using System.Collections;

public interface IPowerupGroupController {

	void InitializePowerupGroup();

	bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID);

	PowerupGroup.PowerupType GetPowerupTypeFromGroupByID(int i_powerupGroupID);

	//This is heavily Unity API dependent. It may have to be part
	//of GameControllerBehaviour.
	//void SpawnPowerupAtPostion(Vector3 i_position, GameObject obj);
	
	void AddSquad(PowerupGroup group);

	void RemoveSquad(PowerupGroup group);

	int GetNextSquadID();

	int GetNumberOfSquads();

	bool IsSquadListed(PowerupGroup group);
	bool IsSquadListed(int groupID);


}
