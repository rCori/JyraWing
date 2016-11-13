using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

public class InGameOptionsMenu : Menu {

    private GameObject uiCanvas;
    private GameObject lifeCount;
    private Text lifeCountText;
    private GameObject back;

    private GameObject bgmLevel;
    private Text bgmLevelText;

    private GameObject sfxLevel;
    private Text sfxLevelText;

    private GameObject darkPanel;
    private GameObject quit;

    private VolumeSettings volumeSettings;

    private bool lockScreen;
    private bool selectionSwitch;


    public delegate void IngameOptionsMenuDelegate();
	public static event IngameOptionsMenuDelegate UnpauseEvent;

    // Use this for initialization
    void Start() {
        //ForceWindowed ();
        InitMenu();
        numberOfItems = 4;
        isVertical = true;
        lockScreen = false;
        selectionSwitch = false;

        volumeSettings = GameObject.Find("VolumeSettings").GetComponent<VolumeSettings>();
        Assert.IsNotNull(volumeSettings);

        //create the menu text stuff
        uiCanvas = GameObject.Find("Canvas");

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

        quit = Resources.Load("UIObjects/InGameOptionsMenu/QuitText") as GameObject;
        quit = Instantiate(quit);
        quit.transform.SetParent(uiCanvas.transform, false);

        back = Resources.Load("UIObjects/InGameOptionsMenu/BackText") as GameObject;
        back = Instantiate(back);
        back.transform.SetParent(uiCanvas.transform, false);

        //Amount to move selector over from a selection when that item is selected.
        float adjustPt = Screen.width / 10.0f;

        menuLocations.Add(new Vector2(bgmLevel.transform.position.x, bgmLevel.transform.position.y));
        menuLocations.Add(new Vector2(sfxLevel.transform.position.x, sfxLevel.transform.position.y));
        menuLocations.Add(new Vector2(quit.transform.position.x, quit.transform.position.y));
        menuLocations.Add(new Vector2(back.transform.position.x, back.transform.position.y));

        gameObject.transform.position = menuLocations[0];

    }

    // Update is called once per frame
    void Update() {
        if (!lockScreen) {
            MenuScroll();
            //Select start the game
            if (Input.GetButtonDown("Auto Fire") || Input.GetButtonDown("Pause")) {
                if (curSelect == 0) {
                }
                else if(curSelect == 2) {
                    StartCoroutine(QuitOption());
                    Debug.Log("Quit");
                } else if (curSelect == 3) {
                    //Back
                    SaveData.Instance.SaveGame();
                    StartCoroutine(ReturnToGame());
                    if (UnpauseEvent != null) {
					    UnpauseEvent ();
				    }
                    Debug.Log("Return to game");
                }
            }
            if (Input.GetAxisRaw("Horizontal") == 1.0f) {
                if (curSelect == 0 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel < 10) {
                        SaveData.Instance.BGMLevel++;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                        volumeSettings.SetBGMAudio(SaveData.Instance.BGMLevel);
                    }
                } else if (curSelect == 1 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel < 10) {
                        SaveData.Instance.SFXLevel++;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
                        volumeSettings.SetSFXAudio(SaveData.Instance.SFXLevel);
                        PlayConfirm();
                    }
                }
                selectionSwitch = true;
            } else if(Input.GetAxisRaw("Horizontal") == -1.0f) {
                if (curSelect == 0 && !selectionSwitch){
                    if (SaveData.Instance.BGMLevel > 0) {
                        SaveData.Instance.BGMLevel--;
                        bgmLevelText.text = "BGM: " + SaveData.Instance.BGMLevel;
                        volumeSettings.SetBGMAudio(SaveData.Instance.BGMLevel);
                    }
                } else if (curSelect == 1 && !selectionSwitch){
                    if (SaveData.Instance.SFXLevel > 0) {
                        SaveData.Instance.SFXLevel--;
                        sfxLevelText.text = "SFX: " + SaveData.Instance.SFXLevel;
                        volumeSettings.SetSFXAudio(SaveData.Instance.SFXLevel);
                        PlayConfirm();
                    }
                }
                selectionSwitch = true;
            } else if(Input.GetAxisRaw("Horizontal") == 0.0f) {
                if (selectionSwitch) {
                    selectionSwitch = false;
                }
            }
        }
    }

    IEnumerator QuitOption() {
        PlayConfirm();
        StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(lifeCount);
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(quit);
        Destroy(back);
        GameObject quitOptionSelection = Resources.Load("UIObjects/InGameQuitMenu/IngameQuitSelector") as GameObject;
        quitOptionSelection = Instantiate(quitOptionSelection);
        quitOptionSelection.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator ReturnToGame(){
        PlayConfirm();
        StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        Destroy(lifeCount);
        Destroy(bgmLevel);
        Destroy(sfxLevel);
        Destroy(quit);
        Destroy(back);
        Destroy(gameObject);
        yield return null;
        /*
        GameObject titleScreenMenu = Resources.Load("UIObjects/TitleScreenMenu/TitleSelector") as GameObject;
        titleScreenMenu = Instantiate(titleScreenMenu);
        titleScreenMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
        */
    }

}
