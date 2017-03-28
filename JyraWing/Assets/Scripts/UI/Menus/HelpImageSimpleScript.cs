using UnityEngine;
using System.Collections;

public class HelpImageSimpleScript : Menu {

    private GameObject uiCanvas;
    private GameObject darkPanel;

    public enum HelpImageContext{
        TITLE_SCREEN = 0,
        IN_GAME,
        OTHER
    }

    public HelpImageContext helpImageContext;

	// Use this for initialization
	void Start () {
	    uiCanvas = GameObject.Find ("Canvas");

        darkPanel = Resources.Load ("UIObjects/InGameQuitMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (uiCanvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);
	}
	
	// Update is called once per frame
	void Update () {
        InitMenu ();
	    if(ButtonInput.Instance().FireButtonDown() || ButtonInput.Instance().StartButtonDown()) {
            if(helpImageContext == HelpImageContext.TITLE_SCREEN) {
                StartCoroutine(loadTitleScreenMenu());
            } else if(helpImageContext == HelpImageContext.IN_GAME) {
                StartCoroutine(loadInGameOptionsMenu());
            }
        }
	}

    IEnumerator loadTitleScreenMenu(){
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.1f));
        GameObject titleScreenMenu = Resources.Load("UIObjects/TitleScreenMenu/TitleSelector") as GameObject;
        titleScreenMenu = Instantiate(titleScreenMenu);
        titleScreenMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(darkPanel);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator loadInGameOptionsMenu() {
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.1f));
        GameObject optionsMenu = Resources.Load("UIObjects/InGameOptionsMenu/InGameOptionsMenu") as GameObject;
        optionsMenu = Instantiate(optionsMenu);
        optionsMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(darkPanel);
        Destroy(gameObject);
        yield return null;
    }
}
