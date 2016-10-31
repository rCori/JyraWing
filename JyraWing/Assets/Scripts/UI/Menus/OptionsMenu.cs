using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : Menu {

    private GameObject uiCanvas;
    private GameObject lifeCount;
    private Text lifeCountText;
    private GameObject back;

    private bool lockScreen;
    private bool selectionSwitch;


    // Use this for initialization
    void Start() {
        //ForceWindowed ();
        InitMenu();
        numberOfItems = 2;
        isVertical = true;
        lockScreen = false;
        selectionSwitch = false;

        //create the menu text stuff
        uiCanvas = GameObject.Find("Canvas");

        lifeCount = Resources.Load("UIObjects/OptionsMenu/LivesText") as GameObject;
        lifeCount = Instantiate(lifeCount);
        lifeCount.transform.SetParent(uiCanvas.transform, false);

        lifeCountText = lifeCount.GetComponent<Text>();
        lifeCountText.text = "Lives: "+ SaveData.Instance.livesPerCredit;


        back = Resources.Load("UIObjects/OptionsMenu/BackText") as GameObject;
        back = Instantiate(back);
        back.transform.SetParent(uiCanvas.transform, false);

        //Amount to move selector over from a selection when that item is selected.
        float adjustPt = Screen.width / 10.0f;

        menuLocations.Add(new Vector2(lifeCount.transform.position.x, lifeCount.transform.position.y));
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
                else if (curSelect == 1) {
                    //Back
                    SaveData.Instance.SaveGame();
                    StartCoroutine(LoadTitleScreenMenu());
                }
            }
            if (Input.GetAxisRaw("Horizontal") == 1.0f) {
                if(curSelect == 0 && !selectionSwitch) {
                    if (SaveData.Instance.livesPerCredit < 6) {
                        SaveData.Instance.livesPerCredit++;
                        lifeCountText.text = "Lives: " + SaveData.Instance.livesPerCredit;
                    }
                    selectionSwitch = true;
                }
            } else if(Input.GetAxisRaw("Horizontal") == -1.0f) {
                if (curSelect == 0 && !selectionSwitch) {
                    if (SaveData.Instance.livesPerCredit > 1) {
                        SaveData.Instance.livesPerCredit--;
                        lifeCountText.text = "Lives: " + SaveData.Instance.livesPerCredit;
                    }
                    selectionSwitch = true;
                }
            } else if(Input.GetAxisRaw("Horizontal") == 0.0f) {
                if (selectionSwitch) {
                    selectionSwitch = false;
                }
            }
        }
    }

    IEnumerator LoadTitleScreenMenu(){
        PlayConfirm();
        Destroy(lifeCount);
        Destroy(back);
        yield return new WaitForSeconds(0.05f);
        GameObject titleScreenMenu = Resources.Load("UIObjects/TitleScreenMenu/TitleSelector") as GameObject;
        titleScreenMenu = Instantiate(titleScreenMenu);
        titleScreenMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

}
