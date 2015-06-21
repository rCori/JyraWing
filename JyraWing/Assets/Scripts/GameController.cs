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
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver) {
			UpdatePlayerLives ();
		} else{
			gameOverTimer -= Time.deltaTime;
			if(gameOverTimer <= 0.0){
				Application.LoadLevel("titleScene");
			}
		}
	}

	/// <summary>
	/// Updates the player lives.
	/// </summary>
	void UpdatePlayerLives(){
		int lifeCount = player.LifeCount ();
		uiController.UpdateLives(lifeCount);
		if (lifeCount == 0) {
			GameOver();
		}

	}

	void GameOver(){
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

}
