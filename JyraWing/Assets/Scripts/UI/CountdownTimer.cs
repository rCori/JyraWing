﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent (typeof (Text))]
public class CountdownTimer : MonoBehaviour {

	private bool countdownStarted;
	private int countdownVal;

	private float secondTimer;
	private static float SECOND_LENGTH = 1.2f;

	public delegate void PlayerKilledDelegate();
	public static event PlayerKilledDelegate PlayerContinueEvent;

	private Text textDisplay;

	private IEnumerator gameOverRoutine;

	private bool _paused;
	private bool gameOverInProgress;

	// Use this for initialization
	void Start () {
		countdownStarted = false;
		textDisplay = GetComponent<Text> ();
		LevelControllerBehavior.PlayerKilledEvent += EndGame;
	}

	// Update is called once per frame
	void Update () {
		if (countdownStarted) {
			if(ButtonInput.Instance().StartButtonDown() ){
				countdownStarted = false;
				countdownVal = 9;
				textDisplay.text = "";
				//Respawn player
				StopCoroutine (gameOverRoutine);
				PlayerContinueEvent();
			}

            if(ButtonInput.Instance().FireButtonDown() || ButtonInput.Instance().ShieldButtonDown()) {
                if(countdownVal != 0) {
                    countdownVal--;
                    textDisplay.text = countdownVal + "";
                    CheckIfTimerFinished();
                }
            }
		}
	}

	public void EndGame() {
		countdownStarted = true;
		countdownVal = 9;
		textDisplay.text = countdownVal + "";
		gameOverRoutine = GameOverRoutine ();
		StartCoroutine(gameOverRoutine);
	}

	void OnDestroy() {
		LevelControllerBehavior.PlayerKilledEvent -= EndGame;
	}

	IEnumerator GameOverRoutine() {
		//Fuck you I will write a while loop when it makes sense to do so not everything needs to be a for
		while(countdownVal != 0) {
			textDisplay.text = countdownVal + "";
			yield return new WaitForSeconds (SECOND_LENGTH);
			countdownVal--;
            CheckIfTimerFinished();
		}
	}

    private void CheckIfTimerFinished() {
        if (countdownVal == 0) {
            countdownStarted = false;
            if(ScoreController.GetHasScoreToEnter()) {
                SceneManager.LoadScene("HighScore");
            } else {
		        SceneManager.LoadScene("titleScene");
            }
        }
    }
		
}