using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

	public Player player;


	public UIController uiController;
	public AudioSource bgmPlayer;

	private float gameOverTimer;

	private enum GameOverState{None = 0, FinishSoundEffect, FinishShowScreen, KillAnimation, KillSoundEffect, KillShowScreen};
	GameOverState gameOverState;

	private bool isPaused;

	/// <summary>
	/// Keep track of and handle every PowerupGroup that currently exists.
	/// </summary>
	private List<PowerupGroup> squadList;
	


	/// <summary>
	/// Keep track of all objects that must be paused when
	/// the game is paused by the player
	/// </summary>
	private List<PauseableItem> pauseList;

	void Awake()
	{
		pauseList = new List<PauseableItem> ();
	}

	// Use this for initialization
	void Start () {
		gameOverTimer = 0.0f;
		gameOverState = GameOverState.None;
		squadList = new List<PowerupGroup> ();
		bgmPlayer = GameObject.Find ("BGMPlayer").GetComponent<AudioSource> ();
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
//		if(isGameOver) {
//			gameOverTimer -= Time.deltaTime;
//			if (gameOverTimer <= 0.0) {
//				Application.LoadLevel ("titleScene");
//			}
//		}
		if(Input.GetButtonDown("Submit"))
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
		//Prevents a crash on exit.
//		if (bgmPlayer) {
//			bgmPlayer.volume = 0.5f;
//		}
		gameOverState = GameOverState.FinishSoundEffect;
		//uiController.ShowLevelComplete();
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
		squadList.Add (i_powerupGroup);
	}


	///<summary>
	/// Remove the powerupgroup but don't spawn anything.
	///</summary>
	public bool RemoveSquad(int i_id){
		//If the squad exists
		if (squadList.Count > i_id) {
			squadList[i_id].RemoveAllFromSquad();
			squadList.RemoveAt(i_id);
			adjustSquadIDs(i_id);
		}
		return false;
	}


	/// <summary>
	/// Returns what the ID for the next squad should be.
	/// </summary>
	public int GetNextSquadID(){
		return squadList.Count;
	}


	public bool CheckSquadAndSpawn(int i_id, GameObject i_lastRemaining){
		//If the squad exists
		if (squadList.Count > i_id) {
			//I am going to start converting all of this stuff to not rely on the index into the list and treat the PowerupGroupID as something else.
			//foreach(PowerupGroup group in squadList)
			{
				//If Squad has everything gone except the last enemy
				if(squadList[i_id].IsSquadGone())
				{
					//Get the powerup object
					GameObject powerup = squadList[i_id].ReturnPowerupObject();
					//Set the position to the last enemy.
					powerup.transform.position = i_lastRemaining.transform.position;
					//Instantiate the powerup
					Instantiate(powerup);
					squadList.RemoveAt(i_id);
					adjustSquadIDs(i_id);
					return true;
					//Debug.LogError ("spawned and removed powerup with id " + i_id);

				}
			}
		}
		return false;
	}

	/// <summary>
	/// Adjusts the squad IDs of every squad with an ID less than 
	/// </summary>
	/// <param name="i_id">I_id.</param>
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



	private void handleGameOver(){
		switch (gameOverState) {
		case(GameOverState.FinishSoundEffect):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				gameOverState = GameOverState.FinishShowScreen;
				uiController.ShowLevelComplete();
				gameOverTimer = 5.0f;
//				bgmPlayer.clip = Resources.Load ("Audio/BGM/victoryJingle") as AudioClip;
//				bgmPlayer.volume = 1.0f;
//				bgmPlayer.PlayOneShot(bgmPlayer.clip);
			}
			break;
		case (GameOverState.FinishShowScreen):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				gameOverTimer = 3.0f;
				Application.LoadLevel ("titleScene");
			}
			break;
		case (GameOverState.KillAnimation):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				player.gameObject.SetActive (false);
				gameOverState = GameOverState.KillSoundEffect;
			}
			break;
		case (GameOverState.KillSoundEffect):
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0f){
				gameOverState = GameOverState.KillShowScreen;
				uiController.ShowGameOver();
				gameOverTimer = 5.0f;
//				bgmPlayer.clip = Resources.Load ("Audio/BGM/losingTheme") as AudioClip;
//				bgmPlayer.volume = 1.0f;
//				bgmPlayer.PlayOneShot(bgmPlayer.clip);
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
	void PauseAllItems()
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
