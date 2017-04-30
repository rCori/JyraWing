//#define DEBUGHIGHSCORESCENEMODE

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreSceneMode : MonoBehaviour {

    public GameObject Canvas;

    public Text Title;

	// Use this for initialization
	void Start () {

        NameEntryMenu.DisplayScoreEvent += DisplayScoresMode;

        //Only uncomment to force name entry.
	    if(ScoreController.GetHasScoreToEnter()) {
#if DEBUGHIGHSCORESCENEMODE
            Debug.LogError("<color=#800000>HighScoreSceneMode is displaying the score entry screen because there is a new score to enter </color>");
#endif
            EnterNameMode();
        } else {
#if DEBUGHIGHSCORESCENEMODE
            Debug.LogError("<color=#800000>HighScoreSceneMode is displaying the the score display because there is no score to enter. </color>");
#endif
            DisplayScoresMode();
        }
	}

    void OnDestroy() {
        NameEntryMenu.DisplayScoreEvent -= DisplayScoresMode;
    }

    private void DisplayScoresMode() {
        GameObject scoreDisplayObject = Resources.Load("UIObjects/HighScoreScreen/ScoreDisplay", typeof(GameObject)) as GameObject;
        scoreDisplayObject = Instantiate(scoreDisplayObject);
        scoreDisplayObject.transform.SetParent(Canvas.transform,false);

        Title.text = "RANKING";
    }

    private void EnterNameMode() {
        GameObject nameMenuSelector = Resources.Load("UIObjects/HighScoreScreen/NameMenuSelector", typeof(GameObject)) as GameObject;
        nameMenuSelector = Instantiate(nameMenuSelector);
        nameMenuSelector.transform.SetParent(Canvas.transform,false);
        GameObject nameDisplayObject = Resources.Load("UIObjects/HighScoreScreen/NameDisplay", typeof(GameObject)) as GameObject;
        nameDisplayObject = Instantiate(nameDisplayObject);
        nameDisplayObject.transform.SetParent(Canvas.transform,false);

        nameMenuSelector.GetComponent<NameEntryMenu>().NameDisplayObject = nameDisplayObject;

        Title.text = "NAME ENTRY";
    }


}
