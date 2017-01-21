using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IngameQuitMenu : Menu {
	private GameObject uiCanvas;
	private GameObject yesText;
	private GameObject noText;
	private GameObject title;
	private GameObject darkPanel;

	private bool lockScreen;

	// Use this for initialization
	void Start () {
		InitMenu ();
		numberOfItems = 2;
		isVertical = false;
		lockScreen = false;
		//create the menu text stuff
		uiCanvas = GameObject.Find ("Canvas");
        
		darkPanel = Resources.Load ("UIObjects/InGameQuitMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (uiCanvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);
        
		yesText = Resources.Load ("UIObjects/InGameQuitMenu/YesText") as GameObject;
		yesText = Instantiate (yesText);
		yesText.transform.SetParent(uiCanvas.transform, false);
		noText = Resources.Load ("UIObjects/InGameQuitMenu/NoText") as GameObject;
		noText = Instantiate (noText);
		noText.transform.SetParent(uiCanvas.transform, false);
		title = Resources.Load ("UIObjects/InGameQuitMenu/IngameMenuTitle") as GameObject;
		title = Instantiate (title);
		title.transform.SetParent (uiCanvas.transform, false);
		//Amount to move selector over from a selection when that item is selected.
		float adjustPt = Screen.width / 10.0f;

		menuLocations.Add(new Vector2(noText.transform.position.x, noText.transform.position.y));
		menuLocations.Add(new Vector2(yesText.transform.position.x, yesText.transform.position.y));

		gameObject.transform.position = menuLocations [0];

	}

	// Update is called once per frame
	void Update () {
		if (!lockScreen) {
			MenuScroll ();

			
			if (ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().FireButtonDown()) {
                //No: Continue game, unpausing it.
				if (curSelect == 0) {
					StartCoroutine(BackOut ());
				//Yes: Go back to main menu
				} else if (curSelect == 1) {
					StartCoroutine (LoadTitleSceneCoroutine ());
				}
			}
			if (Input.GetButtonDown ("Pause")) {
				BackOut ();
			}
		}
	}

	public void RemoveMenu() {
		PlayConfirm ();
		Destroy (title);
		Destroy (noText);
		Destroy (yesText);
		//Destroy (gameObject);
		Destroy (darkPanel);
	}

	IEnumerator LoadTitleSceneCoroutine(){
		PlayConfirm ();
        //SaveData.Instance.EnterScore(ScoreController.GetScore());
        //HighScoreData.Instance.EnterScore(ScoreController.GetScore(), "Test");
        //HighScoreData.Instance.SaveGame();
        HighScoreData.Instance.CheckScore(ScoreController.GetScore());

		lockScreen = true;
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.1f));
        Time.timeScale = 1f;
        if(ScoreController.GetHasScoreToEnter()) {
            SceneManager.LoadScene("HighScore");
        } else {
		    SceneManager.LoadScene("titleScene");
        }
	}

	IEnumerator BackOut(){
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.1f));
		RemoveMenu ();
        lockScreen = true;
        //yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.1f));
        GameObject titleScreenMenu = Resources.Load("UIObjects/InGameOptionsMenu/InGameOptionsMenu") as GameObject;
        titleScreenMenu = Instantiate(titleScreenMenu);
        titleScreenMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
	}
}
