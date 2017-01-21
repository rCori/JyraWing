//#define DEBUGNAMEENTRYMENU

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NameEntryMenu : GridMenu {

    private int rowLen = 9;
    private int colLen = 3;

    private GameObject characterParent;
    private GameObject canvas;

    private int MAX_LEN = 10;

    private string currentName;

    public delegate void AddCharacterDelegate(char v);
    public static event AddCharacterDelegate AddCharEvent;

    public delegate void RemoveCharacterDelegate();
    public static event RemoveCharacterDelegate DeleteCharEvent;

    void Start() {

        canvas = GameObject.Find("Canvas");

        characterParent = Resources.Load("UIObjects/HighScoreScreen/AllCharacters") as GameObject;
        characterParent = Instantiate(characterParent);
        characterParent.transform.SetParent(canvas.transform, false);

        menuLocations = initChildrenVectorLocations(rowLen, colLen, characterParent);

        InitMenu();

        transform.position = menuLocations[curSelectX, curSelectY];

        currentName = "";

    }

    void Update() {
        MenuScroll();
        if(ButtonInput.Instance().FireButtonDown()) {
            LetterEntry(curSelectX, curSelectY);
#if DEBUGNAMEENTRYMENU
            Debug.LogError("<color=#095405>Current Name: " + currentName + "</color>");
#endif
        }

        if(ButtonInput.Instance().ShieldButtonDown()) {
            //Remove a letter here
            RemoveLetter();
#if DEBUGNAMEENTRYMENU
            Debug.LogError("<color=#095405>Current Name: " + currentName + "</color>");
#endif
        }
    }

    private Vector2[,] initChildrenVectorLocations(int xLen, int yLen, GameObject parentObj) {
        Vector2[,] locations = new Vector2[xLen,yLen];

        //Iterate through row major
        for(int y = 0; y < yLen; y++) {
            for(int x = 0; x < xLen; x++) {
                int childIndex = x + (xLen * y);
                locations[x, y] = parentObj.transform.GetChild(childIndex).transform.position;
            }
        }
        return locations;
    }

    private void LetterEntry(int x, int y) {
        switch(x) {
        case 0:
            switch(y) {
            case 0:
                UpdateCurrentName('A');
                break;
            case 1:
                UpdateCurrentName('J');
                break;
            case 2:
                UpdateCurrentName('S');
                break;
            }
            break;
         case 1:
            switch(y) {
            case 0:
                UpdateCurrentName('B');
                break;
            case 1:
                UpdateCurrentName('K');
                break;
            case 2:
                UpdateCurrentName('T');
                break;
            }
            break;
        case 2:
            switch(y) {
            case 0:
                UpdateCurrentName('C');
                break;
            case 1:
                UpdateCurrentName('L');
                break;
            case 2:
                UpdateCurrentName('U');
                break;
            }
            break;
        case 3:
            switch(y) {
            case 0:
                UpdateCurrentName('D');
                break;
            case 1:
                UpdateCurrentName('M');
                break;
            case 2:
                UpdateCurrentName('V');
                break;
            }
            break;
        case 4:
            switch(y) {
            case 0:
                UpdateCurrentName('E');
                break;
            case 1:
                UpdateCurrentName('N');
                break;
            case 2:
                UpdateCurrentName('W');
                break;
            }
            break;
        case 5:
            switch(y) {
            case 0:
                UpdateCurrentName('F');
                break;
            case 1:
                UpdateCurrentName('O');
                break;
            case 2:
                UpdateCurrentName('X');
                break;
            }
            break;
        case 6:
            switch(y) {
            case 0:
                UpdateCurrentName('G');
                break;
            case 1:
                UpdateCurrentName('P');
                break;
            case 2:
                UpdateCurrentName('Y');
                break;
            }
            break;
        case 7:
            switch(y) {
            case 0:
                UpdateCurrentName('H');
                break;
            case 1:
                UpdateCurrentName('Q');
                break;
            case 2:
                UpdateCurrentName('Z');
                break;
            }
            break;
        case 8:
            switch(y) {
            case 0:
                UpdateCurrentName('I');
                break;
            case 1:
                UpdateCurrentName('R');
                break;
            case 2:
                NameEnd();
                break;
            }
            break;
        }
    }

    private void UpdateCurrentName(char newLetter) {
        if(currentName.Length < MAX_LEN) { 
            currentName += newLetter;
            AddCharEvent(newLetter);
        }
    }

    private void RemoveLetter() {
        if(currentName.Length > 0) {
            currentName = currentName.Substring(0, currentName.Length - 1);
            DeleteCharEvent();
        }
    }

    private void NameEnd() {
#if DEBUGNAMEENTRYMENU
            Debug.LogError("<color=#FF0000>Finished inputting name</color>");
#endif
        StartCoroutine(LoadTitleSceneCoroutine());
    }

    IEnumerator LoadTitleSceneCoroutine(){
		//PlayConfirm ();
        //SaveData.Instance.EnterScore(ScoreController.GetScore());
        HighScoreData.Instance.EnterScore(ScoreController.GetScore(), currentName);
        HighScoreData.Instance.SaveGame();
		//lockScreen = true;
        yield return StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.1f));
        Time.timeScale = 1f;
		SceneManager.LoadScene("titleScene");
	}
}
