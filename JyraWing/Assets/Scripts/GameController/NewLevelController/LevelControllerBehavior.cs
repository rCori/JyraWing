using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelControllerBehavior : MonoBehaviour, ILevelController {

	public delegate void LevelControllerDelegate();
	public static event LevelControllerDelegate FinishLevelEvent, DisablePlayerEvent, GameOverEvent, PlayerKilledEvent;

	public static string NextLevel;

	// Use this for initialization
	void Start () {
		GameController.GameOverEvent += HandleGameOver;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandleGameOver() {
		StartCoroutine (gameOverRoutine());
	}

	public void HandleLevelFinished() {
		StartCoroutine (levelFinishedRoutine());
	}


	IEnumerator gameOverRoutine() {
		yield return new WaitForSeconds (2f);
		DisablePlayerEvent ();
		yield return new WaitForSeconds (3.0f);
		PlayerKilledEvent ();
		yield break;
	}

	IEnumerator levelFinishedRoutine() {
		yield return new WaitForSeconds (2f);
		FinishLevelEvent();
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("LevelTransition");
		yield break;
	}

	void OnDestroy() {
		GameController.GameOverEvent -= HandleGameOver;
	}
}
