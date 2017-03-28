using UnityEngine;
using System.Collections;

public class InGameStartMenu : Menu {

    private GameObject uiCanvas;

    private GameObject darkPanel;
    private GameObject options;
    private GameObject back;
    private GameObject quit;

    public delegate void IngameStartMenuDelegate();
	public static event IngameStartMenuDelegate UnpauseEvent;

	// Use this for initialization
	void Start () {
	    InitMenu();

        numberOfItems = 3;
        isVertical = true;

        uiCanvas = GameObject.Find("Canvas");

        darkPanel = Resources.Load("UIObjects/InGameQuitMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (uiCanvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);

        options = Resources.Load("UIObjects/InGameStartMenu/OptionsText") as GameObject;
        options = Instantiate (options);
		options.transform.SetParent (uiCanvas.transform, false);

        back = Resources.Load("UIObjects/InGameStartMenu/BackText") as GameObject;
        back = Instantiate (back);
		back.transform.SetParent (uiCanvas.transform, false);

        quit = Resources.Load("UIObjects/InGameStartMenu/QuitText") as GameObject;
        quit = Instantiate (quit);
        quit.transform.SetParent(uiCanvas.transform, false);

        menuLocations.Clear();
    
        menuLocations.Add(new Vector2(options.transform.position.x, options.transform.position.y));
        menuLocations.Add(new Vector2(back.transform.position.x, back.transform.position.y));
        menuLocations.Add(new Vector2(quit.transform.position.x, quit.transform.position.y));

        gameObject.transform.position = menuLocations[0];
	}
	
	// Update is called once per frame
	void Update () {
        MenuScroll();
        if (ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().FireButtonDown()) {
            if (curSelect == 0) {
                StartCoroutine(OptionsMenu());
            } else if(curSelect == 1) {
                StartCoroutine(ReturnToGame());
                if (UnpauseEvent != null) {
			        UnpauseEvent ();
				}
            } else if(curSelect == 2) {
                StartCoroutine(QuitOption());
            }
        }
	}

    IEnumerator OptionsMenu() {
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(options);
        Destroy(darkPanel);
        Destroy(quit);
        Destroy(back);
        Destroy (darkPanel);
        GameObject optionsMenu = Resources.Load("UIObjects/InGameOptionsMenu/InGameOptionsMenu") as GameObject;
        optionsMenu = Instantiate(optionsMenu);
        optionsMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator ReturnToGame(){
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(options);
        Destroy(quit);
        Destroy(back);
        Destroy (darkPanel);

        /*
        GameObject startSelector = Resources.Load("UIObjects/InGameStartMenu/InGameStartSelector") as GameObject;
        startSelector = Instantiate(startSelector);
        startSelector.transform.SetParent(uiCanvas.transform, false);
        //startSelector.GetComponent<SettingsMenu>().SetContext(SettingsMenu.MENUCONTEXT.inGame);
        */
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator QuitOption() {
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(options);
        Destroy(quit);
        Destroy(back);
        Destroy (darkPanel);
        GameObject quitOptionSelection = Resources.Load("UIObjects/InGameQuitMenu/IngameQuitSelector") as GameObject;
        quitOptionSelection = Instantiate(quitOptionSelection);
        quitOptionSelection.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }
}
