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
	private bool stopGameOverRoutine;

	// Use this for initialization
	void Start () {
		countdownStarted = false;
		stopGameOverRoutine = false;
		textDisplay = GetComponent<Text> ();
		LevelControllerBehavior.PlayerKilledEvent += EndGame;
	}

	// Update is called once per frame
	void Update () {
		if (countdownStarted) {
			//CountdownRoutine (Time.deltaTime);
			if(Input.GetButtonDown("Pause") ){
				Debug.Log ("Stop GameOverRoutine");
				stopGameOverRoutine = true;
				countdownStarted = false;
				countdownVal = 9;
				textDisplay.text = "";
				//Respawn player
				PlayerContinueEvent();
			}
		}
	}

	public void EndGame() {
		Debug.Log ("EndGame");
		countdownStarted = true;
		countdownVal = 9;
		textDisplay.text = countdownVal + "";
		StartCoroutine(GameOverRoutine());
	}

	void OnDestroy() {
		LevelControllerBehavior.PlayerKilledEvent -= EndGame;
	}

	IEnumerator GameOverRoutine() {
		//Fuck you I will write a while loop when it makes sense to do so not everything needs to be a for
		Debug.Log("GameOverRoutine");
		while(countdownVal !=0) {
			if (stopGameOverRoutine) {
				yield break;
			}
			Debug.Log("GameOverRoutine continues on!");
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