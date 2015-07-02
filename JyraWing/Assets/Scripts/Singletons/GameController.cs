using UnityEngine;
using System.Collections;

//Not yet implemented

public class GameController : MonoBehaviour {

	public Player player;
	public UIController uiController;

	private float gameOverTimer;
	private bool isGameOver;
	// Use this for initialization
	void Start () {
		gameOverTimer = 0.0f;
		isGameOver = false;
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
		uiController.UpdateActivatedSpeed(speedCount+1);
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
			return new Vector3();
		}
	}

}
