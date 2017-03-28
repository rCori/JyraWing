#define ASSERTOPTIONSMENU

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

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
    private GameObject highScoreMenu;

    private bool lockScreen;
    private bool selectionSwitch;

    private VolumeSettings volumeSettings;

    // Use this for initialization
    void Start() {
        //ForceWindowed ();
        InitMenu();
        numberOfItems = 6;
        isVertical = true;
        lockScreen = false;
        selectionSwitch = false;

        //create the menu text stuff
        uiCanvas = GameObject.Find("Canvas");

        controlsMenu = Resources.Load("UIObjects/OptionsMenu/ControlsText") as GameObject;
        controlsMenu = Instantiate(controlsMenu);
        controlsMenu.transform.SetParent(uiCanvas.transform, false);

        highScoreMenu = Resources.Load("UIObjects/OptionsMenu/HighScoreText") as GameObject;
        highScoreMenu = Instantiate(highScoreMenu);
        highScoreMenu.transform.SetParent(uiCanvas.transform, false);

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

        volumeSettings = GameObject.Find("VolumeSettings").GetComponent<VolumeSettings>();
        Assert.IsNotNull(volumeSettings);

        menuLocations.Clear();

        menuLocations.Add(new Vector2(controlsMenu.transform.position.x, controlsMenu.transform.position.y));
        menuLocations.Add(new Vector2(highScoreMenu.transform.position.x, highScoreMenu.transform.position.y));
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
                else if(curSelect == 1) {
                    SaveData.Instance.SaveGame();
                    StartCoroutine(LoadHighScoreView());
                }
                else if (curSelect == 5) {
                    //Back
                    SaveData.Instance.SaveGame();
                    StartCoroutine(LoadTitleScreenMenu());
                }
            }
            if (AxisInput.Instance().GetHorizontal() == 1.0f) {
                if(curSelect == 2 && !selectionSwitch) {
                    if (SaveData.Instance.livesPerCredit < 6) {
                        SaveData.Instance.livesPerCredit++;
                        lifeCountText.text = "Lives: " + SaveData.Instance.livesPerCredit;
                    }
                } else if (curSelect == 3 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel < 10) {
                        SaveData.Instance.BGMLevel++;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                        volumeSettings.SetBGMAudio(SaveData.Instance.BGMLevel);
                    }
                } else if (curSelect == 4 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel < 10) {
                        SaveData.Instance.SFXLevel++;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
                        volumeSettings.SetSFXAudio(SaveData.Instance.SFXLevel);
                    }
                }
                selectionSwitch = true;
            } else if(AxisInput.Instance().GetHorizontal() == -1.0f) {
                if (curSelect == 2 && !selectionSwitch) {
                    if (SaveData.Instance.livesPerCredit > 1) {
                        SaveData.Instance.livesPerCredit--;
                        lifeCountText.text = "Lives: " + SaveData.Instance.livesPerCredit;
                    }
                }
                else if (curSelect == 3 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel > 0) {
                        SaveData.Instance.BGMLevel--;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                        volumeSettings.SetBGMAudio(SaveData.Instance.BGMLevel);
                    }
                } else if (curSelect == 4 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel > 0) {
                        SaveData.Instance.SFXLevel--;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
                        volumeSettings.SetSFXAudio(SaveData.Instance.SFXLevel);
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
        Destroy(highScoreMenu);
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

    IEnumerator LoadHighScoreView() {
        PlayConfirm();
        Destroy(controlsMenu);
        Destroy(highScoreMenu);
        Destroy(lifeCount);
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(back);
        yield return new WaitForSeconds(0.05f);
#if ASSERTOPTIONSMENU
        Assert.IsFalse(ScoreController.GetHasScoreToEnter());
#endif
        SceneManager.LoadScene("HighScore");
        yield return null;
    }

    IEnumerator LoadControlsMenu() {
        PlayConfirm();
        Destroy(controlsMenu);
        Destroy(highScoreMenu);
        Destroy(lifeCount);
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(back);
        yield return new WaitForSeconds(0.05f);
        GameObject controlsSelector = Resources.Load("UIObjects/ControlsMenu/ControlsSelector") as GameObject;
        controlsSelector = Instantiate(controlsSelector);
        controlsSelector.transform.SetParent(uiCanvas.transform, false);
        controlsSelector.GetComponent<SettingsMenu>().SetContext(SettingsMenu.MENUCONTEXT.titleScreen);
        Destroy(gameObject);
        yield return null;
    }

}
