using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

	public Player player;
	public UIController uiController;

	private float gameOverTimer;
	private bool isGameOver;

	/// <summary>
	/// Keep track of and handle every PowerupGroup that currently exists.
	/// </summary>
	private List<PowerupGroup> squadList;

	// Use this for initialization
	void Start () {
		gameOverTimer = 0.0f;
		isGameOver = false;
		squadList = new List<PowerupGroup> ();
		//pixelPerfectCamera ();
	}
	
	// Update is called once per frame
	void Update () {
		if(isGameOver) {
			gameOverTimer -= Time.deltaTime;
			if (gameOverTimer <= 0.0) {
				Application.LoadLevel ("titleScene");
			}
		}
	}

	/// <summary>
	/// Updates the player lives.
	/// </summary>
	public void UpdatePlayerLives(){
		int lifeCount = player.LifeCount ();
		uiController.UpdateLives(lifeCount);
		if (lifeCount == 0) {
			GameOver();
		}

	}

	public void UpdatePlayerSpeed(){
		int speedCount = player.SpeedCount ();
		int speedCountCap = player.SpeedCountCap ();
		uiController.UpdateAvailableSpeed(speedCountCap+1);
		uiController.UpdateActivatedSpeed(speedCount+1, speedCountCap+1);
	}
	

	public void GameOver(){
		uiController.ShowGameOver ();
		player.gameObject.SetActive (false);
		gameOverTimer = 2.0f;
		isGameOver = true;
	}

	/// <summary>
	/// Show a little UI results panel wait a bit and then go back to level select.
	/// </summary>
	public void LevelFinished(){
		uiController.ShowLevelComplete();
		gameOverTimer = 4.5f;
		isGameOver = true;
	}

	//A safe way for other objects to get the position of the player
	public Vector3 GetPlayerPosition(){
		if (player) {
			return player.transform.position;
		} else {
			return new Vector3 ();
		}
	}


	/* Power Ups and spawning them from enemies */


	/// <summary>
	/// Add a PowerupGroup to our list of PowerupGroups
	/// </summary>
	/// <param name="i_powerupGroup">PowerupGroup to add.</param>
	public void AddSquad(PowerupGroup i_powerupGroup){
		squadList.Add (i_powerupGroup);
	}


	//REmove th powerupgroup but don't spawn anything.
	public bool CheckSquadAndRemove(int i_id, GameObject i_lastRemaining){
		//If the squad exists
		if (/*squadList[i_id]!= null*/squadList.Count > i_id) {
			//If Squad has everything gone except the last enemy
			if(squadList[i_id].IsSquadGone(i_lastRemaining))
			{
				squadList.RemoveAt(i_id);
				adjustSquadIDs(i_id);
				
			}
		}
		return false;
	}


	//Returns what the ID for the next squad should be.
	public int GetNextSquadID(){
		return squadList.Count;
	}


	public bool CheckSquadAndSpawn(int i_id, GameObject i_lastRemaining){
		//If the squad exists
		if (/*squadList[i_id]!= null*/squadList.Count > i_id) {
			//If Squad has everything gone except the last enemy
			if(squadList[i_id].IsSquadGone(i_lastRemaining))
			{
				//Get the powerup object
				GameObject powerup = squadList[i_id].ReturnPowerupObject();
				//Set the position to the last enemy.
				powerup.transform.position = i_lastRemaining.transform.position;
				//Instantiate the powerup
				Instantiate(powerup);
				squadList.RemoveAt(i_id);
				adjustSquadIDs(i_id);

			}
		}
		return false;
	}

	private void adjustSquadIDs(int i_id){
		//Check each PowerupGroup if  it's ID needs to change.
		for(int i = 0; i < squadList.Count; i++) {
			//If the id of the squad was above that which we removed, it needs
			//to be brought down one to "fill the hole"
			if( i >= i_id){
				squadList[i].AdjustSquadID(-1);
			}
		}

	}
}
