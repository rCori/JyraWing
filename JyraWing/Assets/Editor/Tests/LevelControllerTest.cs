using System;
using NUnit.Framework;
using UnityEngine;

public class LevelControllerTest {

	//Test that after calling Finish Level and having time pass the level complete UI will show
	[Test]
	public void GameState_FinishNoEffect_ShowLevelCompleteUI(){
		//Arrange
		LevelController controller = new LevelController();
		
		//Act
		//Finish the level
		controller.FinishLevel (2.5f);
		//Handle game over after 5 seconds have passed
		controller.HandleGameOver (5.0f);

		//Assert
		//The show level complete UI flag should be set to true now
		bool ShowLevelCompleteUIFlag = controller.ShouldShowLevelCompleteUI ();
		Assert.That (ShowLevelCompleteUIFlag == true);

	}

	//Test that after calling Finish Level and having time pass the GameOverState will advance to the next state
	[Test]
	public void GameState_FinishNoEffect_Transition(){
		//Arrange
		LevelController controller = new LevelController();

		//Act
		//Finish the level
		controller.FinishLevel (2.5f);
		//Handle game over after 5 seconds have passed
		controller.HandleGameOver (5.0f);
		GameOverState curState = controller.gameOverState;

		//Assert
		//After 5 seconds from finishing the level the game over state should be
		//FinishShowScreen state
		Assert.That(curState == GameOverState.FinishShowScreen);
	}

	//Test that after calling FinishLevel and having time pass for both the FinishNoEffect state and the FinishShowScreen
	//state the application will load the title scene
	[Test]
	public void GameState_FinishShowScreen_LoadTitleScene(){
		//Arrange
		LevelController controller = new LevelController ();

		//Act
		//Finish the level
		controller.FinishLevel (2.5f);
		//Handle the game over after 5 seconds. That will transition to start of FinishShowScreen state
		controller.HandleGameOver (5.0f);
		//Wait 5 more seconds to the end of the FinishShowScreen state to set the load TitleScene flag.
		controller.HandleGameOver (5.0f);
		bool LoadTitleSceneFlag = controller.ShouldLoadTitleScene ();

		//Assert
		Assert.That (LoadTitleSceneFlag == true);
	}

	//Test that after calling GameOver and having time pass the player disable flag will be set
	[Test]
	public void GameState_KillAnimation_DisablePlayer(){
		//Arrange
		LevelController controller = new LevelController ();
		
		//Act
		//Player gets game over
		controller.PlayerKilled (2.5f);
		//Handle the game after 5 seconds. That will transition to KillNoEffect state
		controller.HandleGameOver (5.0f);
		bool DisablePlayer = controller.ShouldDisablePlayer ();

		//Assert
		Assert.That (DisablePlayer == true);
	}

	//Test that after calling GameOver and having time pass GameOverState will transition to KillNoEffect state
	[Test]
	public void GameState_KillAnimation_Transition(){
		//Arrange
		LevelController controller = new LevelController ();
		
		//Act
		//Player gets game over
		controller.PlayerKilled (2.5f);
		//Handle the game after 5 seconds. That will transition to KillNoEffect state
		controller.HandleGameOver (5.0f);
		GameOverState state = controller.gameOverState;
		
		//Assert
		Assert.That (state == GameOverState.KillNoEffect);
	}

	//Test that after calling GameOver and having time pass for both KillAnimation and KillNoEffect states that the flag
	//for showing the game over ui will be set
	[Test]
	public void GameState_KillNoEffect_DisablePlayer(){
		//Arrange
		LevelController controller = new LevelController ();
		
		//Act
		//Player gets game over
		controller.PlayerKilled (2.5f);
		//Handle the game after 5 seconds. That will transition to KillNoEffect state
		controller.HandleGameOver (5.0f);
		//After another 5 seconds we are at the end of the KillNoEffect state and are in KillShowScreen state
		controller.HandleGameOver (5.0f);
		//The show game over ui flag should be set
		bool ShowGameOverUI = controller.ShouldShowGameOverUI ();
		
		//Assert
		Assert.That (ShowGameOverUI == true);
	}

	//Test that after calling GameOver and having time pass for both KillAnimation and KillNoEffect the state will
	//transition to KillShowScreen
	[Test]
	public void GameState_KillNoEffect_Transition(){
		//Arrange
		LevelController controller = new LevelController ();
		
		//Act
		//Player gets game over
		controller.PlayerKilled (2.5f);
		//Handle the game after 5 seconds. That will transition to KillNoEffect state
		controller.HandleGameOver (5.0f);
		//After another 5 seconds we are at the end of the KillNoEffect state and are in KillShowScreen state
		controller.HandleGameOver (5.0f);
		//GameOverState will be KillShowScreen now
		GameOverState state = controller.gameOverState;
		
		//Assert
		Assert.That (state == GameOverState.KillShowScreen);
	}

	//Test that after calling GameOver and having time pass for both KillAnimation and KillNoEffect the state will
	//transition to KillShowScreen
	[Test]
	public void GameState_KillShowScreen_LoadTitleScene(){
		//Arrange
		LevelController controller = new LevelController ();
		
		//Act
		//Player gets game over
		controller.PlayerKilled (2.5f);
		//Handle the game after 5 seconds. That will transition to KillNoEffect state
		controller.HandleGameOver (5.0f);
		//After another 5 seconds we are at the end of the KillNoEffect state and are in KillShowScreen state
		controller.HandleGameOver (5.0f);
		//After another 5 seconds wer are at the end of KillShowScreen and the title scene should be loaded
		controller.HandleGameOver (5.0f);
		//The load title scene flag should be set now.
		bool LoadTitleSceneFlag = controller.ShouldLoadTitleScene ();
		
		//Assert
		Assert.That (LoadTitleSceneFlag == true);
	}

}
