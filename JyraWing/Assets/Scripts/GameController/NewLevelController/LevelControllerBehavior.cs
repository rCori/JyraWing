using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
		Debug.Log ("Starting game over coroutine");
		yield return new WaitForSeconds (2f);
		DisablePlayerEvent ();
		yield return new WaitForSeconds (1.2f);
		GameOverEvent();
		yield return new WaitForSeconds (3.0f);
		PlayerKilledEvent ();
		yield break;
	}

	IEnumerator levelFinishedRoutine() {
		Debug.Log ("Starting level finished coroutine");
		yield return new WaitForSeconds (2f);
		FinishLevelEvent();
		Debug.Log ("Level Finished  2 seconds later");
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("LevelTransition");
		yield break;
	}

	void OnDestroy() {
		GameController.GameOverEvent -= HandleGameOver;
	}
}
