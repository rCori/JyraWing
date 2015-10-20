using UnityEngine;
using System.Collections;

public interface IPowerupGroupController {

	void InitializePowerupGroup();

	bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID);

	int GetNextSquadID();
}
