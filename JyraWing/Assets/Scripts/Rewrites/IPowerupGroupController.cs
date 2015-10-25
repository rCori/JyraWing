using UnityEngine;
using System.Collections;

public interface IPowerupGroupController {

	void InitializePowerupGroup();

	bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID);

	GameObject GetPowerupFromGroupByID(int i_powerupGroupID);

	void SpawnPowerupAtPostion(Vector3 i_position, GameObject obj);

	int GetNextSquadID();
}
