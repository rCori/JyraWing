#define DEBUGLOG

using UnityEngine;
using System.Collections;



public class HighScoreSceneMode : MonoBehaviour {

    public GameObject Canvas;

	// Use this for initialization
	void Start () {
        //Only uncomment to force name entry.
        //ScoreController.SetScoreToDisplay(true);
	    if(ScoreController.GetHasScoreToEnter()) {
#if DEBUGLOG
            Debug.LogError("<color=#800000>HighScoreSceneMode is displaying the score entry screen because there is a new score to enter </color>");
#endif
            GameObject nameMenuSelector = Resources.Load("UIObjects/HighScoreScreen/NameMenuSelector", typeof(GameObject)) as GameObject;
            nameMenuSelector = Instantiate(nameMenuSelector);
            nameMenuSelector.transform.SetParent(Canvas.transform,false);
            GameObject nameDisplayObject = Resources.Load("UIObjects/HighScoreScreen/NameDisplay", typeof(GameObject)) as GameObject;
            nameDisplayObject = Instantiate(nameDisplayObject);
            nameDisplayObject.transform.SetParent(Canvas.transform,false);
        } else {
#if DEBUGLOG
            Debug.LogError("<color=#800000>HighScoreSceneMode is displaying the the score display because there is no score to enter. </color>");
#endif 
            GameObject scoreDisplayObject = Resources.Load("UIObjects/HighScoreScreen/ScoreDisplay", typeof(GameObject)) as GameObject;
            scoreDisplayObject = Instantiate(scoreDisplayObject);
            scoreDisplayObject.transform.SetParent(Canvas.transform,false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
