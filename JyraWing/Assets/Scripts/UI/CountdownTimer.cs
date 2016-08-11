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

	private IEnumerator gameOverRoutine;

	// Use this for initialization
	void Start () {
		countdownStarted = false;
		textDisplay = GetComponent<Text> ();
		LevelControllerBehavior.PlayerKilledEvent += EndGame;
	}

	// Update is called once per frame
	void Update () {
		if (countdownStarted) {
			//CountdownRoutine (Time.deltaTime);
			if(Input.GetButtonDown("Pause") ){
				Debug.Log ("Stop GameOverRoutine");
				countdownStarted = false;
				countdownVal = 9;
				textDisplay.text = "";
				//Respawn player
				StopCoroutine (gameOverRoutine);
				PlayerContinueEvent();
			}
		}
	}

	public void EndGame() {
		Debug.Log ("EndGame");
		countdownStarted = true;
		countdownVal = 9;
		Debug.Log ("coutdownVal: " + countdownVal);
		textDisplay.text = countdownVal + "";
		gameOverRoutine = GameOverRoutine ();
		StartCoroutine(gameOverRoutine);
	}

	void OnDestroy() {
		LevelControllerBehavior.PlayerKilledEvent -= EndGame;
	}

	IEnumerator GameOverRoutine() {
		//Fuck you I will write a while loop when it makes sense to do so not everything needs to be a for
		Debug.Log("GameOverRoutine");
		while(countdownVal != 0) {
			Debug.Log("GameOverRoutine continues on!: " + countdownVal);
			textDisplay.text = countdownVal + "";
			yield return new WaitForSeconds (SECOND_LENGTH);
			countdownVal--;
			if (countdownVal == -1) {
				countdownStarted = false;
				SceneManager.LoadScene ("titleScene");
			}
		}
	}
}