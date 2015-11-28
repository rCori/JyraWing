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

	public enum PowerupType{None = 0, Speed, Bullet};

	PowerupType powerupType;

	public PowerupGroup(int i_id){
		powerupType = PowerupType.None;
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
	

	///<summary>
	/// In a redesigned version of this code, this is supposed to replace ReturnPowerupObject
	/// </summary>
	public PowerupType ReturnPowerupType(){
		return powerupType;
	}

	///<summary>
	/// In a code redesign this should replace SetPowerupObject
	/// </summary>
	public void SetPowerupType(PowerupType i_type){
		powerupType = i_type;
	}

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
