﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameMenu : Menu {

    private GameObject uiCanvas;

    private GameObject mainGameObject;
    private GameObject levelSelectObject;
    private GameObject backObject;
    private Text levelSelectText;

    private int currentLevelSelect;
    private string selectedLevel;

    private bool selectionSwitch = false;

    private int SELECTABLE_LEVELS = 5;

    void Start() {
        InitMenu();
        numberOfItems = 3;
        isVertical = true;
        selectionSwitch = false;
        currentLevelSelect = 1;
        uiCanvas = GameObject.Find("Canvas");

        mainGameObject = Resources.Load("UIObjects/StartGameMenu/MainGameText") as GameObject;
        mainGameObject = Instantiate(mainGameObject);
        mainGameObject.transform.SetParent(uiCanvas.transform, false);

        levelSelectObject = Resources.Load("UIObjects/StartGameMenu/LevelSelectText") as GameObject;
        levelSelectObject = Instantiate(levelSelectObject);
        levelSelectObject.transform.SetParent(uiCanvas.transform, false);

        levelSelectText = levelSelectObject.GetComponent<Text>();
        levelSelectText.text = "Level: " + currentLevelSelect;

        backObject = Resources.Load("UIObjects/StartGameMenu/BackText") as GameObject;
        backObject = Instantiate(backObject);
        backObject.transform.SetParent(uiCanvas.transform, false);

        selectedLevel = "Level_1";

        menuLocations.Add(new Vector2(mainGameObject.transform.position.x, mainGameObject.transform.position.y));
        menuLocations.Add(new Vector2(levelSelectObject.transform.position.x, levelSelectObject.transform.position.y));
        menuLocations.Add(new Vector2(backObject.transform.position.x, backObject.transform.position.y));

    }

    void Update() {
        MenuScroll();
        //Select start the game
        if (ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().FireButtonDown()) {
            switch(curSelect) {
            case 0:
                selectedLevel = "Level_1";
                LevelControllerBehavior.SingleLevel = false;
                StartCoroutine(loadLevel());
                break;
            case 1:
                ChangeSelectedLevel();
                LevelControllerBehavior.SingleLevel = true;
                StartCoroutine(loadLevel());
                break;
            case 2:
                StartCoroutine(LoadTitleScreenMenu());
                break;
            default:
                break;
            }
        }
        if (AxisInput.Instance().GetHorizontal() == 1.0f) {
            if (curSelect == 1 && !selectionSwitch) {
                if (currentLevelSelect < SELECTABLE_LEVELS) {
                    currentLevelSelect++;
                    levelSelectText.text = "Level: " + currentLevelSelect;
                }
                selectionSwitch = true;
            }
        } else if (AxisInput.Instance().GetHorizontal() == -1.0f) {
            if (curSelect == 1 && !selectionSwitch) {
                if (currentLevelSelect > 1) {
                    currentLevelSelect--;
                    levelSelectText.text = "Level: " + currentLevelSelect;
                }
                selectionSwitch = true;
            }
        } else if (AxisInput.Instance().GetHorizontal() == 0.0f) {
            if (selectionSwitch) {
                selectionSwitch = false;
            }
        }

    }

    IEnumerator LoadTitleScreenMenu() {
        PlayConfirm();
        Destroy(mainGameObject);
        Destroy(levelSelectObject);
        Destroy(backObject);
        yield return new WaitForSeconds(0.05f);
        GameObject titleScreenMenu = Resources.Load("UIObjects/TitleScreenMenu/TitleSelector") as GameObject;
        titleScreenMenu = Instantiate(titleScreenMenu);
        titleScreenMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator loadLevel(){
		PlayConfirm();
		yield return new WaitForSeconds (0.05f);
        PlayerLives.Instance.ResetLives();
		SceneManager.LoadScene (selectedLevel);
	}

    private void ChangeSelectedLevel() {
        switch(currentLevelSelect) {
        case 1:
            Debug.Log("Level_1");
            selectedLevel = "Level_1";
            break;
        case 2:
            Debug.Log("Level_2");
            selectedLevel = "Level_2";
            break;
        case 3:
            Debug.Log("Level_3");
            selectedLevel = "Level_3";
            break;
        case 4:
            Debug.Log("Level_4");
            selectedLevel = "Level_4";
            break;
        case 5:
            Debug.Log("Level_5");
            selectedLevel = "Level_5";
            break;
        default:
            break;
        }
    }

}
