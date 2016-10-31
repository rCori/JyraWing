using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : Menu {


	private GameObject uiCanvas;
	private GameObject level1StartGame;
	//private GameObject level2StartGame;
	private GameObject quitGame;
	private GameObject saveGame;
    private GameObject options;

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

        options = Resources.Load("UIObjects/TitleScreenMenu/OptionsMenu") as GameObject;
        options = Instantiate(options);
        options.transform.SetParent(uiCanvas.transform, false);

        quitGame = Resources.Load ("UIObjects/TitleScreenMenu/TitleQuitText") as GameObject;
		quitGame = Instantiate (quitGame);
		quitGame.transform.SetParent(uiCanvas.transform, false);

		menuLocations.Add (new Vector2 (level1StartGame.transform.position.x, level1StartGame.transform.position.y));
        menuLocations.Add(new Vector2(options.transform.position.x, options.transform.position.y));
        menuLocations.Add (new Vector2 (quitGame.transform.position.x, quitGame.transform.position.y));

		gameObject.transform.position = menuLocations [0];
    }
	
	// Update is called once per frame
	void Update () {
		if (!lockScreen) {
			MenuScroll ();
            //Select start the game
            if (Input.GetButtonDown("Auto Fire") || Input.GetButtonDown("Pause")) {
				if (curSelect == 0) {
					StartCoroutine (startGameMenu ());
				} else if (curSelect == 1) {
                    StartCoroutine(loadOptionsMenu());
                } else if (curSelect == 2) {
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

    IEnumerator startGameMenu() {
        PlayConfirm();
        lockScreen = true;
        Destroy(level1StartGame);
        Destroy(options);
        Destroy(quitGame);
        yield return new WaitForSeconds(0.05f);
        GameObject startGameMenu = Resources.Load("UIObjects/StartGameMenu/StartGameMenuSelector") as GameObject;
        startGameMenu = Instantiate(startGameMenu);
        startGameMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
    }

    IEnumerator loadOptionsMenu() {
        PlayConfirm();
        lockScreen = true;
        Destroy(level1StartGame);
        Destroy(options);
        Destroy(quitGame);
        yield return new WaitForSeconds(0.05f);
        GameObject optionsMenu = Resources.Load("UIObjects/OptionsMenu/OptionsMenu") as GameObject;
        optionsMenu = Instantiate(optionsMenu);
        optionsMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
    }

	IEnumerator quit(){
		PlayConfirm ();
		lockScreen = true;
		yield return new WaitForSeconds (0.05f);
		Application.Quit ();
	}
}
