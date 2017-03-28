using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

public class InGameOptionsMenu : Menu {

    private GameObject uiCanvas;
    private GameObject back;

    private GameObject controlsSelector;

    private GameObject bgmLevel;
    private Text bgmLevelText;

    private GameObject sfxLevel;
    private Text sfxLevelText;

    private GameObject darkPanel;
    private GameObject quit;

    private GameObject howToPlayText;

    private GameObject helpImage;

    private VolumeSettings volumeSettings;

    private bool lockScreen;
    private bool selectionSwitch;


    // Use this for initialization
    void Start() {
        InitMenu();
        numberOfItems = 5;
        isVertical = true;
        lockScreen = false;
        selectionSwitch = false;

        volumeSettings = GameObject.Find("VolumeSettings").GetComponent<VolumeSettings>();
        Assert.IsNotNull(volumeSettings);

        //create the menu text stuff
        uiCanvas = GameObject.Find("Canvas");

        darkPanel = Resources.Load ("UIObjects/InGameQuitMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (uiCanvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);

        controlsSelector = Resources.Load("UIObjects/InGameOptionsMenu/ControlsText") as GameObject;
        controlsSelector = Instantiate(controlsSelector);
        controlsSelector.transform.SetParent(uiCanvas.transform, false);

        howToPlayText = Resources.Load("UIObjects/InGameOptionsMenu/HowToPlayText") as GameObject;
        howToPlayText = Instantiate(howToPlayText);
        howToPlayText.transform.SetParent(uiCanvas.transform, false);

        bgmLevel = Resources.Load("UIObjects/InGameOptionsMenu/BGMText") as GameObject;
        bgmLevel = Instantiate(bgmLevel);
        bgmLevel.transform.SetParent(uiCanvas.transform, false);

        bgmLevelText = bgmLevel.GetComponent<Text>();
        bgmLevelText.text = "BGM: "+ SaveData.Instance.BGMLevel;

        sfxLevel = Resources.Load("UIObjects/InGameOptionsMenu/SFXText") as GameObject;
        sfxLevel = Instantiate(sfxLevel);
        sfxLevel.transform.SetParent(uiCanvas.transform, false);

        sfxLevelText = sfxLevel.GetComponent<Text>();
        sfxLevelText.text = "SFX: "+ SaveData.Instance.SFXLevel;

        /*
        quit = Resources.Load("UIObjects/InGameOptionsMenu/QuitText") as GameObject;
        quit = Instantiate(quit);
        quit.transform.SetParent(uiCanvas.transform, false);
        */

        back = Resources.Load("UIObjects/InGameOptionsMenu/BackText") as GameObject;
        back = Instantiate(back);
        back.transform.SetParent(uiCanvas.transform, false);

        //Amount to move selector over from a selection when that item is selected.
        //float adjustPt = Screen.width / 10.0f;

        menuLocations.Clear();
    
        menuLocations.Add(new Vector2(controlsSelector.transform.position.x, controlsSelector.transform.position.y));
        menuLocations.Add(new Vector2(howToPlayText.transform.position.x, howToPlayText.transform.position.y));
        menuLocations.Add(new Vector2(bgmLevel.transform.position.x, bgmLevel.transform.position.y));
        menuLocations.Add(new Vector2(sfxLevel.transform.position.x, sfxLevel.transform.position.y));
        menuLocations.Add(new Vector2(back.transform.position.x, back.transform.position.y));

        gameObject.transform.position = menuLocations[0];
    }

    // Update is called once per frame
    void Update() {
        if (!lockScreen) {
            MenuScroll();
            //Select start the game
            if (ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().FireButtonDown()) {
                if (curSelect == 0) {
                    StartCoroutine(ControlsMenu());
                } else if(curSelect == 1) {
                    StartCoroutine(ShowHowToPlay());
                }
                /*
                else if(curSelect == 3) {
                    StartCoroutine(QuitOption());
                    Debug.Log("Quit");
                }
                */ 
                //else if (curSelect == 4) {
                else if (curSelect == 4) {
                    //Back
                    SaveData.Instance.SaveGame();
                    StartCoroutine(StartMenu());
                    /*
                    if (UnpauseEvent != null) {
					    UnpauseEvent ();
				    }
                    */
                    Debug.Log("Return to game");
                }
            }
            if (AxisInput.Instance().GetHorizontal() == 1.0f) {
                if (curSelect == 2 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel < 10) {
                        SaveData.Instance.BGMLevel++;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                        volumeSettings.SetBGMAudio(SaveData.Instance.BGMLevel);
                    }
                } else if (curSelect == 3 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel < 10) {
                        SaveData.Instance.SFXLevel++;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
                        volumeSettings.SetSFXAudio(SaveData.Instance.SFXLevel);
                        PlayConfirm();
                    }
                }
                selectionSwitch = true;
            } else if(AxisInput.Instance().GetHorizontal() == -1.0f) {
                if (curSelect == 2 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel > 0) {
                        SaveData.Instance.BGMLevel--;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                        volumeSettings.SetBGMAudio(SaveData.Instance.BGMLevel);
                    }
                } else if (curSelect == 3 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel > 0) {
                        SaveData.Instance.SFXLevel--;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
                        volumeSettings.SetSFXAudio(SaveData.Instance.SFXLevel);
                        PlayConfirm();
                    }
                }
                selectionSwitch = true;
            } else if(AxisInput.Instance().GetHorizontal() == 0.0f) {
                if (selectionSwitch) {
                    selectionSwitch = false;
                }
            }
        }
    }

    IEnumerator ShowHowToPlay() {
        PlayConfirm();
        lockScreen = true;
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(quit);
        Destroy(back);
        Destroy(howToPlayText);
        Destroy(controlsSelector);
        Destroy (darkPanel);
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        helpImage = Resources.Load("UIObjects/HelpImage") as GameObject;
        helpImage = Instantiate(helpImage);
        helpImage.GetComponent<HelpImageSimpleScript>().helpImageContext = HelpImageSimpleScript.HelpImageContext.IN_GAME;
        helpImage.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
    }

    IEnumerator QuitOption() {
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(quit);
        Destroy(back);
        Destroy(howToPlayText);
        Destroy(controlsSelector);
        Destroy (darkPanel);
        GameObject quitOptionSelection = Resources.Load("UIObjects/InGameQuitMenu/IngameQuitSelector") as GameObject;
        quitOptionSelection = Instantiate(quitOptionSelection);
        quitOptionSelection.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator ControlsMenu() {
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(quit);
        Destroy(back);
        Destroy(howToPlayText);
        Destroy(controlsSelector);
        Destroy (darkPanel);
        GameObject controlsOption = Resources.Load("UIObjects/ControlsMenu/ControlsSelector") as GameObject;
        controlsOption = Instantiate(controlsOption);
        controlsOption.transform.SetParent(uiCanvas.transform, false);
        controlsOption.GetComponent<SettingsMenu>().SetContext(SettingsMenu.MENUCONTEXT.inGame);
        Destroy(gameObject);
    }

    IEnumerator StartMenu(){
        PlayConfirm();
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(quit);
        Destroy(back);
        Destroy(howToPlayText);
        Destroy(controlsSelector);
        Destroy (darkPanel);
        GameObject startMenu = Resources.Load("UIObjects/InGameStartMenu/InGameStartMenu") as GameObject;
        startMenu = Instantiate(startMenu);
        startMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

}
