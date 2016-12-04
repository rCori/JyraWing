using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : Menu {

    private GameObject uiCanvas;
    private GameObject lifeCount;
    private Text lifeCountText;
    private GameObject back;

    private GameObject bgmLevel;
    private Text bgmLevelText;

    private GameObject sfxLevel;
    private Text sfxLevelText;

    private GameObject controlsMenu;

    private bool lockScreen;
    private bool selectionSwitch;


    // Use this for initialization
    void Start() {
        //ForceWindowed ();
        InitMenu();
        numberOfItems = 5;
        isVertical = true;
        lockScreen = false;
        selectionSwitch = false;

        //create the menu text stuff
        uiCanvas = GameObject.Find("Canvas");

        controlsMenu = Resources.Load("UIObjects/OptionsMenu/ControlsText") as GameObject;
        controlsMenu = Instantiate(controlsMenu);
        controlsMenu.transform.SetParent(uiCanvas.transform, false);

        lifeCount = Resources.Load("UIObjects/OptionsMenu/LivesText") as GameObject;
        lifeCount = Instantiate(lifeCount);
        lifeCount.transform.SetParent(uiCanvas.transform, false);

        lifeCountText = lifeCount.GetComponent<Text>();
        lifeCountText.text = "Lives: "+ SaveData.Instance.livesPerCredit;


        bgmLevel = Resources.Load("UIObjects/OptionsMenu/BGMText") as GameObject;
        bgmLevel = Instantiate(bgmLevel);
        bgmLevel.transform.SetParent(uiCanvas.transform, false);

        bgmLevelText = bgmLevel.GetComponent<Text>();
        bgmLevelText.text = "BGM: "+ SaveData.Instance.BGMLevel;


        sfxLevel = Resources.Load("UIObjects/OptionsMenu/SFXText") as GameObject;
        sfxLevel = Instantiate(sfxLevel);
        sfxLevel.transform.SetParent(uiCanvas.transform, false);

        sfxLevelText = sfxLevel.GetComponent<Text>();
        sfxLevelText.text = "SFX: "+ SaveData.Instance.SFXLevel;


        back = Resources.Load("UIObjects/OptionsMenu/BackText") as GameObject;
        back = Instantiate(back);
        back.transform.SetParent(uiCanvas.transform, false);

        //Amount to move selector over from a selection when that item is selected.
        float adjustPt = Screen.width / 10.0f;

        menuLocations.Add(new Vector2(controlsMenu.transform.position.x, controlsMenu.transform.position.y));
        menuLocations.Add(new Vector2(lifeCount.transform.position.x, lifeCount.transform.position.y));
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
            if (ButtonInput.Instance().FireButtonDown() || ButtonInput.Instance().StartButtonDown()) {
                if (curSelect == 0) {
                    StartCoroutine(LoadControlsMenu());
                }
                else if (curSelect == 4) {
                    //Back
                    SaveData.Instance.SaveGame();
                    StartCoroutine(LoadTitleScreenMenu());
                }
            }
            if (AxisInput.Instance().GetHorizontal() == 1.0f) {
                if(curSelect == 1 && !selectionSwitch) {
                    if (SaveData.Instance.livesPerCredit < 6) {
                        SaveData.Instance.livesPerCredit++;
                        lifeCountText.text = "Lives: " + SaveData.Instance.livesPerCredit;
                    }
                } else if (curSelect == 2 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel < 10) {
                        SaveData.Instance.BGMLevel++;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                    }
                } else if (curSelect == 3 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel < 10) {
                        SaveData.Instance.SFXLevel++;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
                    }
                }
                selectionSwitch = true;
            } else if(AxisInput.Instance().GetHorizontal() == -1.0f) {
                if (curSelect == 1 && !selectionSwitch) {
                    if (SaveData.Instance.livesPerCredit > 1) {
                        SaveData.Instance.livesPerCredit--;
                        lifeCountText.text = "Lives: " + SaveData.Instance.livesPerCredit;
                    }
                }
                else if (curSelect == 2 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel > 0) {
                        SaveData.Instance.BGMLevel--;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                    }
                } else if (curSelect == 3 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel > 0) {
                        SaveData.Instance.SFXLevel--;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
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

    IEnumerator LoadTitleScreenMenu(){
        PlayConfirm();
        Destroy(controlsMenu);
        Destroy(lifeCount);
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(back);
        yield return new WaitForSeconds(0.05f);
        GameObject titleScreenMenu = Resources.Load("UIObjects/TitleScreenMenu/TitleSelector") as GameObject;
        titleScreenMenu = Instantiate(titleScreenMenu);
        titleScreenMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator LoadControlsMenu() {
        PlayConfirm();
        Destroy(controlsMenu);
        Destroy(lifeCount);
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(back);
        yield return new WaitForSeconds(0.05f);
        GameObject controlsSelector = Resources.Load("UIObjects/ControlsMenu/ControlsSelector") as GameObject;
        controlsSelector = Instantiate(controlsSelector);
        controlsSelector.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

}
