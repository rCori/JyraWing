using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/// <summary>
/// A powerup group is a collection of enemies that when all destroyed by the
/// player, will drop a specified powerup. Those powerups can be Speed or
/// Bullet
/// </summary>
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

	/// <summary>
	/// Register a an enemy to the squad.
	/// Requires the gameObject has an EnemyBehaviour component.
	/// </summary>
	/// <param name="i_enemy">I_enemy.</param>
	public void AddToSquad(GameObject i_enemy){
		Debug.Assert (i_enemy.GetComponent<EnemyBehavior> () != null);
		squad.Add (i_enemy);
		//The enemy itself will need to know what it's id is for when it is destoryed
		//and must call on the GameController to possibly spawn a powerup.
		if (i_enemy.GetComponent<EnemyBehavior> () != null) {
			i_enemy.GetComponent<EnemyBehavior> ().SetPowerupGroupID (id);
		}
	}

	public bool IsSquadGone(){
		//Check to make sure every member of the squad no longer exists
		for (int i = 0; i < squad.Count; i++) {
			if(squad[i]){
				EnemyBehavior enemy = squad[i].GetComponent<EnemyBehavior>();
				//If there is a squad member remaining that isn't the last one remaining.
				//if(squad[i] && squad[i] != i_lastRemaining){
				if(!enemy.GetIsDestroyed()){
					return false;
				}
			}
		}
		return true;
	}


	/// <summary>
	/// Returns the powerup object.
	/// This is the object that would spawn and is needed by the gameController
	/// for it to spawn the object.
	/// </summary>
	/// <returns>The powerup object.</returns>
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

	/// <summary>
	/// Adjusts the squad I.
	/// If two groups are present at the same time and the group
	/// with the smaller id is destroyed, the group ID of the remaining
	/// group must be adjusted. 
	/// </summary>
	/// <param name="amount">Amount.</param>
//	public void AdjustSquadID(int amount){
//		//typically amount will be -1
//		id += amount;
//		//Now adjust the id in all the enemies
//		for (int i = 0; i< squad.Count; i++) {
//			if(squad[i]){
//				squad[i].GetComponent<EnemyBehavior>().SetPowerupGroupID(id);
//			}
//		}
//	}

	///<summary> Return powerup group id</summary>
	public int GetPowerupGroupID(){
		return id;
	}

	/// <summary>
	/// By setting the group ID's of all the groups members to -1,
	/// we effectivly remove them from the group
	/// </summary>
	public void RemoveAllFromSquad()
	{
		for (int i= 0; i < squad.Count; i++) {
			//This is some safety from null pointers I am getting on close more than anyhting else.
			//Shouldn't affect gameplay because really squad[i] should not be null but just for good practice.
			if(squad[i] != null && squad[i].GetComponent<EnemyBehavior> () != null)
			{
				squad[i].GetComponent<EnemyBehavior> ().SetPowerupGroupID (-1);
			}
		}
	}
}
