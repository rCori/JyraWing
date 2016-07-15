using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent (typeof (Text))]
public class CountdownTimer : MonoBehaviour {

	private bool countdownStarted;
	private int countdownVal;

	private float secondTimer;
	private static float SECOND_LENGTH = 2.0f;

	public delegate void PlayerKilledDelegate();
	public static event PlayerKilledDelegate PlayerContinueEvent;

	private Text textDisplay;

	// Use this for initialization
	void Start () {
		countdownStarted = false;
		textDisplay = GetComponent<Text> ();
		LevelController.PlayerKilledEvent += EndGame;
	}

	// Update is called once per frame
	void Update () {
		if (countdownStarted) {
			CountdownRoutine (Time.deltaTime);
			if(Input.GetButtonDown("Pause") ){
				ContinueGame(true);
			}
		}
	}

	public void ContinueGame(bool down) {
		if (countdownStarted && down) {
			countdownStarted = false;
			countdownVal = 9;
			textDisplay.text = "";
			//Respawn player
			PlayerContinueEvent();
		}
	}

	public void EndGame() {
		countdownStarted = true;
		countdownVal = 9;
		textDisplay.text = countdownVal + "";
	}

	private void CountdownRoutine(float delta) {
		secondTimer += delta;
		if (secondTimer >= SECOND_LENGTH) {
			secondTimer = 0.0f;
			countdownVal--;
			if (countdownVal == 0) {
				SceneManager.LoadScene ("titleScene");
				countdownStarted = false;
			}
			textDisplay.text = countdownVal + "";
		}
	}
}