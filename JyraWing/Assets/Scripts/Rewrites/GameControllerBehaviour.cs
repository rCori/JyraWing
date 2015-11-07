using UnityEngine;
using System.Collections;
public class GameControllerBehaviour : MonoBehaviour {


	GameControllerRewrite gameController;

	// Use this for initialization
	void Awake () {
		gameController = new GameControllerRewrite ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//HandleGameOver is time dependent
		gameController.HandleGameOver (Time.deltaTime);
	}

	//Not sure about this yet
	public void SpawnPowerupAtPostion(Vector3 i_position, int squadID){
		//Get the powerup gameobject itself with the squad ID we have
		PowerupGroup.PowerupType powerupType = gameController.GetPowerupTypeFromGroupByID (squadID);
		GameObject powerup = new GameObject ();
		switch(powerupType){
		case PowerupGroup.PowerupType.Speed:
			powerup = Resources.Load ("Pickups/SpeedPowerup") as GameObject;
			break;
		case PowerupGroup.PowerupType.Bullet:
			powerup = Resources.Load ("Pickups/BulletPowerup") as GameObject;
			break;
		default:
			break;
		}
		//If the powerup is null, the input squad ID is invalid so throw
		//an exception
		try{
			//If the powerup is null throw the exception
			if (powerup == null) {
				//It's an arugment of the function so I will call it an ArgumentException
				throw new System.ArgumentException("The squad id is invalid. No squad found.");
			}
		}
		//This will catch if the powerup GameObject is null
		catch(System.ArgumentException e){
			Debug.Log (e.Message);
		}

		//CHange the position of the GameObject so it spawns in the desired location
		powerup.transform.position = i_position;
		//Instantiate the powerup GameObject
		Instantiate (powerup);

	}

}
