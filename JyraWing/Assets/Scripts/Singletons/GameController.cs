﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

	/// <summary>
	/// The GameController has a reference to the player and the Player holds a reference to it.
	/// </summary>
	public Player player;

	/// <summary>
	/// false if the UI elements in the scene have been created, true if they have been. 
	/// </summary>
	private bool initializeUI;

	/// <summary>
	/// The user interface controller that is in the scene
	/// </summary>
	public UIController uiController;

	/// <summary>
	/// The AudioSource of the GameObject in scene that should be playing the background music.
	/// </summary>
	//public AudioSource bgmPlayer;

	protected float gameOverTimer;

	protected enum GameOverState{None = 0, FinishNoEffect, FinishShowScreen, KillAnimation, KillNoEffect, KillShowScreen};
	GameOverState gameOverState;

	protected bool isPaused;

	int nextSquadID;
	 
	/// <summary>
	/// Keep track of and handle every PowerupGroup that currently exists.
	/// </summary>
	protected List<PowerupGroup> squadList;


	/// <summary>
	/// Keep track of all objects that must be paused when
	/// the game is paused by the player
	/// </summary>
	protected List<PauseableItem> pauseList;

	void Awake()
	{
		pauseList = new List<PauseableItem> ();
	}

	// Use this for initialization
	void Start () {
		gameOverTimer = 0.0f;
		gameOverState = GameOverState.None;
		squadList = new List<PowerupGroup> ();
		isPaused = false;
		nextSquadID = 0;
		initializeUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		//We will continue to try to initializeUI until it finally happens and then we wont do it again.
		if (!initializeUI) {
			if(player != null)
			{
				uiController.Initialize(player.LifeCount ());
				initializeUI = true;
			}
		}
		if(Input.GetButtonDown("Pause"))
		{
			if (!isPaused && gameOverState == GameOverState.None) {
				uiController.PauseMenu();
				PauseAllItems();
			}
		}
		handleGameOver ();
	}

	/// <summary>
	/// Updates the player lives.
	/// </summary>
	public void UpdatePlayerLives(){
		int lifeCount = player.LifeCount ();
		uiController.UpdateLives(lifeCount);
		if (lifeCount == 0) {
			GameOver(2.5f);
		}

	}

	public void UpdatePlayerSpeed(){
		int speedCount = player.SpeedCount ();
		int speedCountCap = player.SpeedCountCap ();
		uiController.UpdateAvailableSpeed(speedCountCap+1);
		uiController.UpdateActivatedSpeed(speedCount+1, speedCountCap+1);
	}
	

	/// <summary>
	/// Show the GameOverScreen
	/// </summary>
	/// <param name="i_gameOverTimer">I_game over timer.</param>
	public void GameOver(float i_gameOverTimer = 0.0f){
		//bgmPlayer.volume = 0.5f;
		gameOverState = GameOverState.KillAnimation;
		gameOverTimer = i_gameOverTimer;
	}

	/// <summary>
	/// Show a little UI results panel wait a bit and then go back to level select.
	/// </summary>
	public void LevelFinished(float i_gameOverTimer = 0.0f){
		gameOverState = GameOverState.FinishNoEffect;
		gameOverTimer = i_gameOverTimer;
	}

	///<summary>
	///A safe way for other objects to get the position of the player
	///</summary>
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
		//Debug.LogError ("Adding squad with ID " + i_powerupGroup.GetPowerupGroupID ());
		squadList.Add (i_powerupGroup);
	}


	///<summary>
	/// Remove the powerupgroup but don't spawn anything.
	///</summary>
	public bool RemoveSquad(int i_id){
		//If the squad exists
		if (squadList.Count > 0) {
			foreach (PowerupGroup group in squadList) {
				if (group.GetPowerupGroupID () == i_id) {
					//I may be able to get rid of this. I will try.
					group.RemoveAllFromSquad ();
					squadList.Remove (group);
					return true;
				}
			}
		}
		return false;
	}


	/// <summary>
	/// Returns what the ID for the next squad should be.
	/// </summary>
	public int GetNextSquadID(){
		nextSquadID++;
		return nextSquadID;
	}

	public bool CheckIsSquadGone(int i_id){
		if (squadList.Count > 0) {
			foreach (PowerupGroup group in squadList) {
				//If this is the group we are looking for.
				if (group.GetPowerupGroupID () == i_id) {
					//If Squad has everything gone except the last enemy
					if (group.IsSquadGone ()) {
						//Debug.LogError ("Spawning powerup ID " + group.GetPowerupGroupID ());
						return true;
					}
				}
			}
		}
		return false;
	}


	public bool SpawnGroupPower(int i_id, Vector3 i_position){
		if (squadList.Count > 0) {
			foreach (PowerupGroup group in squadList) {
				//If this is the group we are looking for.
				if (group.GetPowerupGroupID () == i_id) {
					//Get the powerup object
					GameObject powerup = new GameObject();
					//Find what powerup object we should be spawning
					PowerupGroup.PowerupType powerupType = group.ReturnPowerupType();
					//Use a switch case to load the correct powerup type
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
					//GameObject powerup = group.ReturnPowerupObject ();
					//Set the position to the position given
					powerup.transform.position = i_position;
					//Instantiate the powerup
					Instantiate (powerup);
					return true;
				}

			}
		}
		return false;
	}
	

	protected void handleGameOver(){
		switch (gameOverState) {
		case(GameOverState.FinishNoEffect):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				gameOverState = GameOverState.FinishShowScreen;
				uiController.ShowLevelComplete();
				gameOverTimer = 3.0f;
			}
			break;
		case (GameOverState.FinishShowScreen):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				Application.LoadLevel ("titleScene");
			}
			break;
		case (GameOverState.KillAnimation):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				player.gameObject.SetActive (false);
				gameOverState = GameOverState.KillNoEffect;
			}
			break;
		case (GameOverState.KillNoEffect):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				gameOverState = GameOverState.KillShowScreen;
				uiController.ShowGameOver();
				gameOverTimer = 3.0f;
			}
			break;
		case (GameOverState.KillShowScreen):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				Application.LoadLevel ("titleScene");
			}
			break;
		}
	}

	///Allows the user to pause all items that have been registered to pause
	public void PauseAllItems()
	{
		foreach(PauseableItem item in pauseList)
		{
			item.paused = true;
		}
		isPaused = true;
	}

	///Allows the user to unpause all items that have been registered to pause and resume the game
	public void Unpause()
	{
		foreach(PauseableItem item in pauseList)
		{
			item.paused = false;
		}
		isPaused = false;
	}

	/// <summary>
	/// Registers and item to be globablly paused
	/// </summary>
	/// <param name="item">Item to register.</param>
	public void RegisterPause(PauseableItem item)
	{
		pauseList.Add (item);
	}

	/// <summary>
	/// Remove and item from the pause list
	/// </summary>
	/// <param name="item">Item.</param>
	public void DelistPause(PauseableItem item)
	{
		pauseList.Remove (item);
	}
	
}
