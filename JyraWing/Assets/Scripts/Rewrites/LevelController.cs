using UnityEngine;
using System.Collections;

public class LevelController : ILevelController {

	//If gameOverTImer has reached 0 in HandleGameOver, this state will determine what happens in the rest of the function
	private GameOverState _gameOverState;

	//Used by HandleGameOver
	//This is set by GameOver, FinishLevel, and HandleGameOver
	//It's purpose is to time the game over process for either clearing the level or not
	//It gets subtracted by the float passed into HandleGameOver and when it is 0 or less the process continues
	//What happens depends on _gameOverState. A flag may be set to be handled by a different module and/or _gameOverState
	//could change. GameOverTImer itself could be reset.
	private float gameOverTimer;

	//A collection of boolean set by HandleGameOver to be used by other modules
	//Turn off the player object
	bool disablePlayer;
	//Show the UI grpahic for Level Complete
	bool showLevelCompleteUI;
	//Show the UI graphic for Game Over
	bool showGameOverScreenUI;
	//Application.Load the title scene
	bool loadTitleScene;

	//Called when player finishes the level by destroying the end boss
	public void FinishLevel(float startTimer = 2.5f){
		_gameOverState = GameOverState.FinishNoEffect;
		//Time until the next phase of the gameover sequence
		gameOverTimer = startTimer;
	}

	//Called when player dies
	public void PlayerKilled(float startTimer){
	}

	// implement the GameOverState gameoverState property
	public GameOverState gameOverState{
		get{
			return _gameOverState;
		}
		//Set the internal gameoverstate
		set{
			_gameOverState = value;
		}
	}

	//Return the flags set by HandleGameOver
	//Other functions need them
	public bool ShouldDisablePlayer(){
		return disablePlayer;
	}
	public bool ShouldShowLevelCompleteUI(){
		return showLevelCompleteUI;
	}
	public bool ShouldShowGameOverUI(){
		return showGameOverScreenUI;
	}
	public bool ShouldLoadTitleScene(){
		return loadTitleScene;
	}

	//Needs to be kept up to date with the time.deltaTime in the MonoBehaviour
	//Advance the process of losing or finishing the level and transitioning to a new scene
	public void HandleGameOver(float timeChange){
		//We are not in any level ending process
		//Return early
		if (_gameOverState == GameOverState.None) {
			return;
		}
		//Advance time
		gameOverTimer -= timeChange;
		//If time is up then make progress in whatever stage of the transition sequence we are in
		if(gameOverTimer <= 0.0f){
			//Make the change for the current state
			switch(_gameOverState){
			//Pause after level has been finished is over, display the level complete message
			case GameOverState.FinishNoEffect:
				gameOverState = GameOverState.FinishShowScreen;
				showLevelCompleteUI = true;
				gameOverTimer = 3.0f;
				break;
			//Level complete message has been showing, load the title scene now.
			case GameOverState.FinishShowScreen:
				loadTitleScene = true;
				break;
			//Player destroy animation is done
			case GameOverState.KillAnimation:
				gameOverState = GameOverState.KillNoEffect;
				disablePlayer = true;
				break;
			//Show the game over screen
			case GameOverState.KillNoEffect:
				gameOverState = GameOverState.KillShowScreen;
				showGameOverScreenUI = true;
				gameOverTimer = 3.0f;
				break;
			//Load the title scene after showing game over
			case GameOverState.KillShowScreen:
				loadTitleScene = true;
				break;
			}
		}
	}
}
