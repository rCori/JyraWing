﻿using UnityEngine;
using System.Collections;

public interface ILevelController {
	

	GameOverState gameOverState {
		get;
		set;
	}

	//Called when the player successfully finishes the level
	void FinishLevel(float startTimer);
	//Called when the player is killed.
	void PlayerKilled(float startTimer);

	//Return flags set during the stages of Finishing a level or game over
	bool ShouldDisablePlayer(bool resetFlag = true);
	bool ShouldShowLevelCompleteUI(bool resetFlag = true);
	bool ShouldShowGameOverUI(bool resetFlag = true);
	bool ShouldLoadTitleScene(bool resetFlag = true);

	//Time change should be time.deltaTime
	void HandleGameOver(float timeChange);

}