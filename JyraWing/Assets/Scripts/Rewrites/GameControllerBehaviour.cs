using UnityEngine;
using System.Collections;
public class GameControllerBehaviour : MonoBehaviour {

	public Player player;

	GameControllerRewrite gameController;

	public UIControllerBehaviour uiControllerBehaviour;

	bool initializeUI;
	
	// Use this for initialization
	void Awake () {
		gameController = new GameControllerRewrite ();
		//Set all of the controller modules
		gameController.SetPauseController (new PauseController ());
		gameController.SetLevelController (new LevelController ());
		gameController.SetPowerupGroupController (new PowerupGroupController ());
		gameController.SetUIController (new UIControllerRewrite ());
		initializeUI = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		//HandleGameOver is time dependent
		gameController.HandleGameOver (Time.deltaTime);
		if (!initializeUI) {
			if(player){
				gameController.SetDefaultLifeCount(player.LifeCount());
				gameController.InitializeLifeCount();
				uiControllerBehaviour.Initialize(gameController.GetLifeCount());
				initializeUI = true;
			}
		}
		//When the pause button is pressed, the uiCOntrollerBehvaiour will create
		//the ingame menu and all items will pause
		if (Input.GetButtonDown ("Pause")) {
			if(gameController.IsPaused && gameController.IsNotGameOver())
			{
				uiControllerBehaviour.PauseMenu();
				gameController.PauseAllItems();
			}
		}
		//When the flag to update lives is checked, this will get the uiControllerBehaviour to update that
		if (gameController.ShouldUpdateLifeCount (true)) {
			uiControllerBehaviour.UpdateLives(gameController.GetLifeCount());
		}
		//When the flag to update speed values is checked, this will get the uiControllerBehaviour to update that.
		if (gameController.ShouldUpdateSpeed (true)) {
			//uiControllerBehaviour.UpdateAvailableSpeed(gameController.AvailableSpeed+1);
			uiControllerBehaviour.UpdateActivatedSpeed(gameController.ActiveSpeed, gameController.AvailableSpeed);
		}

		//The gameController has a null-checked player position at all times
		//Set the player position in GameController.
		if (player) {
			gameController.playerPosition = player.transform.position;
		} else {
			gameController.playerPosition = new Vector3(0f,0f,0f);

		}

		if (gameController.IsPowerupSpawnQueued()) {
			SpawnPowerupAtPostion(gameController.QueuedPowerupLocation, gameController.QueuedPowerupType);
		}

		//Check levelController flags for game state changes
		//Disable the player
		if (gameController.ShouldDisablePlayer ()) {
			player.gameObject.SetActive (false);
		}

		//Load the title scene
		if (gameController.ShouldLoadTitleScene ()) {
			Application.LoadLevel("TitleScene");
		}

		//Show the game over message
		if (gameController.ShouldShowGameOverUI ()) {
			uiControllerBehaviour.ShowGameOver();
		}

		//Show the level complete ui
		if (gameController.ShouldShowLevelCompleteUI ()) {
			uiControllerBehaviour.ShowLevelComplete();
		}
	}

	//Not sure about this yet
	public void SpawnPowerupAtPostion(Vector3 i_position, PowerupGroup.PowerupType powerupType){
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

	public GameControllerRewrite GetGameController(){
		return gameController;
	}

}
