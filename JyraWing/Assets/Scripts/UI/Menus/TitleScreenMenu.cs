using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : Menu {


	private GameObject uiCanvas;
	private GameObject level1StartGame;
	//private GameObject level2StartGame;
	private GameObject quitGame;
	private GameObject saveGame;

	private string selectedLevel = "Level_1";
	private bool lockScreen;

	// Use this for initialization
	void Start () {
		//ForceWindowed ();
		InitMenu ();
		numberOfItems = 3;
		isVertical = true;
		lockScreen = false;

		//create the menu text stuff
		uiCanvas = GameObject.Find ("Canvas");
		level1StartGame = Resources.Load ("UIObjects/TitleScreenMenu/Level1StartText") as GameObject;
		level1StartGame = Instantiate (level1StartGame);
		level1StartGame.transform.SetParent(uiCanvas.transform, false);

        //level2StartGame = Resources.Load ("UIObjects/TitleScreenMenu/Level2StartText") as GameObject;
        //level2StartGame = Instantiate (level2StartGame);
        //level2StartGame.transform.SetParent(uiCanvas.transform, false);

        saveGame = Resources.Load("UIObjects/TitleScreenMenu/SaveGame") as GameObject;
        saveGame = Instantiate(saveGame);
        saveGame.transform.SetParent(uiCanvas.transform, false);

        quitGame = Resources.Load ("UIObjects/TitleScreenMenu/TitleQuitText") as GameObject;
		quitGame = Instantiate (quitGame);
		quitGame.transform.SetParent(uiCanvas.transform, false);


		//Amount to move selector over from a selection when that item is selected.
		float adjustPt = Screen.width / 10.0f;

//		menuLocations.Add (new Vector2 (level1StartGame.transform.position.x-adjustPt, level1StartGame.transform.position.y));
//		menuLocations.Add (new Vector2 (level2StartGame.transform.position.x-adjustPt, level2StartGame.transform.position.y));
//		menuLocations.Add (new Vector2 (quitGame.transform.position.x-adjustPt, quitGame.transform.position.y));

		menuLocations.Add (new Vector2 (level1StartGame.transform.position.x, level1StartGame.transform.position.y));
        //menuLocations.Add (new Vector2 (level2StartGame.transform.position.x, level2StartGame.transform.position.y));
        menuLocations.Add(new Vector2(saveGame.transform.position.x, saveGame.transform.position.y));
        menuLocations.Add (new Vector2 (quitGame.transform.position.x, quitGame.transform.position.y));

		gameObject.transform.position = menuLocations [0];

	}
	
	// Update is called once per frame
	void Update () {
		if (!lockScreen) {
			MenuScroll ();
			//Select start the game
			if (Input.GetButton ("Fire") || Input.GetButton ("Pause")) {
				if (curSelect == 0) {
					selectedLevel = "Level_1";
					StartCoroutine (loadLevel ());
				} else if (curSelect == 1) {
                    //selectedLevel = "Level_2";
                    //StartCoroutine (loadLevel ());
                //} else if (curSelect == 2) {
                } else if (curSelect == 1) {
                    SaveData.Instance.SaveGame();
                } else if (curSelect == 2) {
                    //} else if (curSelect == 3) {
                    StartCoroutine(quit());
                }
			}
		}
	}

	/// <summary>
	///If fullscreen is chosen we want to force a windowed game.
	/// Resolution will stay the same.
	/// </summary>
	public void ForceWindowed()
	{
		if (Screen.fullScreen) {
			int width = Screen.width;
			int height = Screen.height;
			Screen.SetResolution(width, height, false);
			Screen.fullScreen = false;
		}
	}

	IEnumerator loadLevel(){
		PlayConfirm();
		lockScreen = true;
		yield return new WaitForSeconds (0.05f);
		SceneManager.LoadScene (selectedLevel);
	}

	IEnumerator quit(){
		PlayConfirm ();
		lockScreen = true;
		yield return new WaitForSeconds (0.05f);
		Application.Quit ();
	}
}
