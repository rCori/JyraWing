using UnityEngine;
using System.Collections;

public interface ILevelController {
	

	GameOverState gameOverState {
		get;
		set;
	}

	//Called when the player successfully finishes the level
	void FinisheLevel();
	//Called when the player is killed.
	void PlayerKilled();

	//Return flags set during the stages of Finishing a level or game over
	bool ShouldDisablePlayer();
	bool ShouldShowLevelCompleteUI();
	bool ShouldShowGameOverUI();
	bool ShouldLoadTitleScene();

	//Time change should be time.deltaTime
	void HandleGameOver(float timeChange);

}
