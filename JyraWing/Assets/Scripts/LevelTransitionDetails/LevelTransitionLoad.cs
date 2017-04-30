using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTransitionLoad : MonoBehaviour {

	public float timeToLoad = 3.0f;
	public GameObject canvas;

	private GameObject rollup1;
	string nextLevel;

	// Use this for initialization
	void Start () {
		nextLevel = LevelControllerBehavior.NextLevel;
		rollup1 = Resources.Load ("UIObjects/Rollup") as GameObject;
		CreateRollup();
	}

	private void CreateRollup() {
		rollup1 = Resources.Load ("UIObjects/Rollup") as GameObject;
		Rollup rollup1Behavior = rollup1.GetComponent<Rollup> ();
		rollup1Behavior.finalVal = ScoreController.GetScore ();
		if (rollup1Behavior.finalVal > 1000) {
			rollup1Behavior.countupIncrement = 100;
		} else {
			rollup1Behavior.countupIncrement = 10;
		}
		rollup1Behavior.countupRate = 0.001f;
		rollup1Behavior = Instantiate (rollup1Behavior);
		rollup1Behavior.transform.SetParent (canvas.transform,false);
		rollup1Behavior.TimerEndEvent += () => StartCoroutine (BeginLevelTransitionCountdown ());
		rollup1Behavior.BeginTimer ();
	}

	IEnumerator BeginLevelTransitionCountdown() {
		while (timeToLoad > 0) {
			timeToLoad -= 1.0f;
			yield return new WaitForSeconds (1.0f);
		}
        if(LevelControllerBehavior.SingleLevel) {
            SceneManager.LoadScene(LevelControllerBehavior.TitleSceneLevel);
        } else {
            /*
            if(nextLevel=="titleScene") {
                int finishScore = ScoreController.GetScore();
                HighScoreData.Instance.CheckScore(finishScore);
                if(ScoreController.GetHasScoreToEnter()) {
                    SceneManager.LoadScene("HighScore");
                    yield break;
                }
            }
            */
		    SceneManager.LoadScene (nextLevel);
        }
		yield break;
	}

}
