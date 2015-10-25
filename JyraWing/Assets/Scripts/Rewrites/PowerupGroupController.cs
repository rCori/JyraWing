using UnityEngine;
using System.Collections;

public class PowerupGroupController : IPowerupGroupController {

	public void InitializePowerupGroup(){
	}

	bool CheckShouldSpawnPowerupGroup(int i_powerupgroupID){
		return false;
	}
	
	GameObject GetPowerupFromGroupByID(int i_powerupGroupID){
		GameObject obj = new GameObject();
		return obj
	}
	
	void SpawnPowerupAtPostion(Vector3 i_position, GameObject obj){
	}
	
	int GetNextSquadID();

}
