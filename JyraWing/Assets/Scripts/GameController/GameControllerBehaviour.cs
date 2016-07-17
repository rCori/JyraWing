using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerBehaviour : MonoBehaviour {

	public Player player;

	GameController gameController;

	public UIControllerBehaviour uiControllerBehaviour;

	public string NextLevel = "";

	bool initializeUI;

	// Use this for initialization
	void Awake () {
		gameController = new GameController();
		//Set all of the controller modules
		gameController.SetPauseController (new PauseController ());
		//gameController.SetLevelController (new LevelController ());
		gameController.SetPowerupGroupController (new PowerupGroupController ());
		gameController.SetUIController (new UIControllerRewrite ());
		LevelControllerBehavior.NextLevel = NextLevel;
		initializeUI = false;
		PlayerInputController.StartButton += PauseBehavior;
		CountdownTimer.PlayerContinueEvent += RestartPlayer;
		LevelControllerBehavior.DisablePlayerEvent += DisablePlayer;
	}
	
	// Update is called once per frame
	void Update () {
		//HandleGameOver is time dependent
		//gameController.HandleGameOver (Time.deltaTime);
		if (!initializeUI) {
			if(player){
				gameController.SetDefaultLifeCount(player.LifeCount());
				gameController.InitializeLifeCount();
				uiControllerBehaviour.Initialize(gameController.GetLifeCount());
				initializeUI = true;
			}
		}

		//When the flag to update lives is checked, this will get the uiControllerBehaviour to update that
		if (gameController.ShouldUpdateLifeCount (true)) {
			uiControllerBehaviour.UpdateLives(gameController.GetLifeCount());
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
			

		if (gameController.ShouldUpdateShieldPercentage ()) {
			uiControllerBehaviour.UpdatePlayerShield(gameController.ShieldPercentage);
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

	public GameController GetGameController(){
		return gameController;
	}

	public void PauseBehavior(bool down) {
		if (down) {
			if (!gameController.IsPaused/* && gameController.IsNotGameOver ()*/) {
				uiControllerBehaviour.PauseMenu ();
				gameController.PauseAllItems ();
			}
		}
	}

	public void RestartPlayer() {
		player.gameObject.SetActive (true);
		gameController.InitializeLifeCount();
	}

	public void DisablePlayer() {
		player.gameObject.SetActive (false);
	}

	void OnDestroy() {
		PlayerInputController.StartButton -= PauseBehavior;
		CountdownTimer.PlayerContinueEvent -= RestartPlayer;
		LevelControllerBehavior.DisablePlayerEvent -= DisablePlayer;
	}

}
