using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupGroup {
	private List<GameObject> squad;
	int id;
	//GameController gameController;
	GameObject powerupObject;

	public enum PowerupType{None = 0, Speed, Bullet};

	public PowerupGroup(int i_id){
		powerupObject = new GameObject ();
		id = i_id;
		squad = new List<GameObject> ();
	}

	public void AddToSquad(GameObject i_enemy){
		squad.Add (i_enemy);
		//The enemy itself will need to know what it's id is for when it is destoryed
		//and must call on the GameController to possibly spawn a powerup.
		i_enemy.GetComponent<EnemyBehavior> ().SetPowerupGroupID(id);
	}

	public bool IsSquadGone(GameObject i_lastRemaining){
		//Check to make sure every member of the squad no longer exists
		for (int i = 0; i< squad.Count; i++) {
			//If there is a squad member remaining that isn't the last one remaining.
			if(squad[i] && squad[i] != i_lastRemaining){
				return false;
			}
		}
		return true;
	}

	public GameObject ReturnPowerupObject(){
		return powerupObject;
	}

	/// <summary>
	/// Creates the appropriate GameObject for memeber powerupObject
	/// </summary>
	/// <param name="i_type">The type of powerupObject.</param>
	public void SetPowerupObject(PowerupType i_type){
		switch (i_type) {
		case PowerupType.None:
			break;
		case PowerupType.Speed:
			powerupObject = Resources.Load ("Pickups/SpeedPowerup") as GameObject;
			break;
		case PowerupType.Bullet:
			powerupObject = Resources.Load ("Pickups/BulletPowerup") as GameObject;
			break;

		}
	}

	public void AdjustSquadID(int amount){
		//typically amount will be -1
		id += amount;
		//Now adjust the id in all the enemies
		for (int i = 0; i< squad.Count; i++) {
			squad[i].GetComponent<EnemyBehavior>().SetPowerupGroupID(id);
		}
	}
}
