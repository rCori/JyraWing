using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : Menu {


	private GameObject uiCanvas;
	private GameObject startGame;

	private GameObject quitGame;
    private GameObject options;
    private GameObject howToPlay;
    private GameObject creditsText;

    private GameObject helpImage;

	private string selectedLevel = "Level_1";
	private bool lockScreen;
    private bool showingHelp;

	// Use this for initialization
	void Start () {
		InitMenu ();
		numberOfItems = 5;
		isVertical = true;
		showingHelp = false;

        helpImage = null;

        //create the menu text stuff
        CreateUIObjects();

		gameObject.transform.position = menuLocations [0];
    }
	
	// Update is called once per frame
	void Update () {
		if (!lockScreen) {
			MenuScroll ();
            //Select start the game
            if (ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().FireButtonDown()) {
				if (curSelect == 0) {
					StartCoroutine (startGameMenu ());
				} else if (curSelect == 1) {
                    StartCoroutine(loadOptionsMenu());
                } else if (curSelect == 2) {
                    StartCoroutine(showHowToPlay());
                } else if (curSelect == 3) {
                    StartCoroutine(showCredits());
                } else if (curSelect == 4) {
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

    private void CreateUIObjects() {
        uiCanvas = GameObject.Find ("Canvas");
		startGame = Resources.Load ("UIObjects/TitleScreenMenu/StartText") as GameObject;
		startGame = Instantiate (startGame);
		startGame.transform.SetParent(uiCanvas.transform, false);

        options = Resources.Load("UIObjects/TitleScreenMenu/OptionsMenu") as GameObject;
        options = Instantiate(options);
        options.transform.SetParent(uiCanvas.transform, false);

        howToPlay = Resources.Load("UIObjects/TitleScreenMenu/HowToPlayText") as GameObject;
        howToPlay = Instantiate(howToPlay);
        howToPlay.transform.SetParent(uiCanvas.transform, false);

        creditsText = Resources.Load("UIObjects/TitleScreenMenu/CreditsText") as GameObject;
        creditsText = Instantiate(creditsText);
        creditsText.transform.SetParent(uiCanvas.transform, false);

        quitGame = Resources.Load ("UIObjects/TitleScreenMenu/TitleQuitText") as GameObject;
		quitGame = Instantiate (quitGame);
		quitGame.transform.SetParent(uiCanvas.transform, false);

        menuLocations.Clear();

        menuLocations.Add (new Vector2 (startGame.transform.position.x, startGame.transform.position.y));
        menuLocations.Add(new Vector2(options.transform.position.x, options.transform.position.y));
        menuLocations.Add(new Vector2(howToPlay.transform.position.x, howToPlay.transform.position.y));
        menuLocations.Add(new Vector2(creditsText.transform.position.x, creditsText.transform.position.y));
        menuLocations.Add (new Vector2 (quitGame.transform.position.x, quitGame.transform.position.y));

		gameObject.transform.position = menuLocations [0];
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
        Destroy(startGame);
        Destroy(options);
        Destroy(quitGame);
        Destroy(howToPlay);
        Destroy(creditsText);
        yield return new WaitForSeconds(0.05f);
        GameObject startGameMenu = Resources.Load("UIObjects/StartGameMenu/StartGameMenuSelector") as GameObject;
        startGameMenu = Instantiate(startGameMenu);
        startGameMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
    }

    IEnumerator showHowToPlay() {
        PlayConfirm();
        lockScreen = true;
        Destroy(startGame);
        Destroy(options);
        Destroy(quitGame);
        Destroy(howToPlay);
        Destroy(creditsText);
        yield return new WaitForSeconds(0.05f);
        helpImage = Resources.Load("UIObjects/HelpImage") as GameObject;
        helpImage = Instantiate(helpImage);
        helpImage.GetComponent<HelpImageSimpleScript>().helpImageContext = HelpImageSimpleScript.HelpImageContext.TITLE_SCREEN;
        helpImage.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
    }

    IEnumerator showCredits() {
        PlayConfirm();
        lockScreen = true;
        Destroy(startGame);
        Destroy(options);
        Destroy(quitGame);
        Destroy(howToPlay);
        Destroy(creditsText);
        yield return new WaitForSeconds(0.05f);
        creditsText = Resources.Load("UIObjects/CreditsImage") as GameObject;
        creditsText = Instantiate(creditsText);
        creditsText.GetComponent<HelpImageSimpleScript>().helpImageContext = HelpImageSimpleScript.HelpImageContext.TITLE_SCREEN;
        creditsText.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
    }

    IEnumerator loadOptionsMenu() {
        PlayConfirm();
        lockScreen = true;
        Destroy(startGame);
        Destroy(options);
        Destroy(quitGame);
        Destroy(howToPlay);
        Destroy(creditsText);
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
