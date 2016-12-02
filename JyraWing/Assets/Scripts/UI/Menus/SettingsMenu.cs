using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenu : Menu {

    private GameObject uiCanvas;

    private GameObject darkPanel;

    //All of the controls
    private GameObject shootButton;
    private GameObject shieldButton;
    private GameObject startButton;
    /*
    private GameObject upButton;
    private GameObject downButton;
    private GameObject leftButton;
    private GameObject rightButton;
    */

    //Text for controls
    private Text shootButtonText;
    private Text shieldButtonText;
    private Text startButtonText;
    private Text upButtonText;
    private Text downButtonText;
    private Text leftButtonText;
    private Text rightButtonText;


    //Initial candidate controls
    private KeyCode shootKeyCode;
    private KeyCode shieldKeyCode;
    private KeyCode startKeyCode;
    /*
    private KeyCode upKeyCode;
    private KeyCode downKeyCode;
    private KeyCode leftKeyCode;
    private KeyCode rightKeyCode;
    */


    /* The available resolutions
     * 1980 x 1280
     * 1600 x 900
     * 1366 x 768
     * 1280 x 720
     * 1174 x 664
     */

    //In game video settings
    private GameObject resolutionTextObject;
    private GameObject windowedTextObject;

    //Text for video settings
    private Text resolutionText;
    private Text windowedText;

    //Initial candidate videosettings
    private int resolutionX, resolutionY;
    private bool isWindowed;
    private int resolutionChoice;


    //Other menu options
    private GameObject saveText;
    private GameObject resetToDefaultsText;
    private GameObject backText;


    public enum KEYS {
        up,
        left,
        right,
        down,
        shoot,
        shield,
        start
    };

    public KEYS key;
    private bool gettingNextKey;


	// Use this for initialization
	void Start () {
	    InitMenu();
        numberOfItems = 12;
        isVertical = true;
        uiCanvas = GameObject.Find("Canvas");
        gettingNextKey = false;

        darkPanel = Resources.Load ("UIObjects/ControlsMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (uiCanvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);

        CreateAllObjects();
        InitControls();
        InitTextFields();

        int currentXResolution = GetCurrentResolutionChoice(SaveData.Instance.resolutionX);
        ChangeResolution(currentXResolution);

        menuLocations.Add(new Vector2(shootButton.transform.position.x, shootButton.transform.position.y));
        menuLocations.Add(new Vector2(shieldButton.transform.position.x, shieldButton.transform.position.y));
        menuLocations.Add(new Vector2(startButton.transform.position.x, startButton.transform.position.y));
        /*
        menuLocations.Add(new Vector2(upButton.transform.position.x, upButton.transform.position.y));
        menuLocations.Add(new Vector2(downButton.transform.position.x, downButton.transform.position.y));
        menuLocations.Add(new Vector2(leftButton.transform.position.x, leftButton.transform.position.y));
        menuLocations.Add(new Vector2(rightButton.transform.position.x, rightButton.transform.position.y));
        */

        menuLocations.Add(new Vector2(resolutionTextObject.transform.position.x, resolutionTextObject.transform.position.y));
        menuLocations.Add(new Vector2(windowedTextObject.transform.position.x, windowedTextObject.transform.position.y));

        menuLocations.Add(new Vector2(saveText.transform.position.x, saveText.transform.position.y));
        menuLocations.Add(new Vector2(resetToDefaultsText.transform.position.x, resetToDefaultsText.transform.position.y));
        menuLocations.Add(new Vector2(backText.transform.position.x, backText.transform.position.y));

        gameObject.transform.position = menuLocations[0];

	}

	// Update is called once per frame
	void Update () {
        if(!gettingNextKey) {
	        MenuScroll();
        }

        if(gettingNextKey) {
            KeyCode currentKey = fetchKey();
            if(currentKey != KeyCode.None) {
                Debug.Log("currentKey is: " + currentKey.ToString());
                switch(key) {
                case KEYS.shoot:
                    shootKeyCode = currentKey;
                    shootButtonText.text = "Shoot: " + shootKeyCode.ToString();
                    break;
                case KEYS.shield:
                    shieldKeyCode = currentKey;
                    shieldButtonText.text = "Shield: " + shieldKeyCode.ToString();
                    break;
                case KEYS.start:
                    startKeyCode = currentKey;
                    startButtonText.text = "Pause: " + startKeyCode.ToString();
                    break;
                /*
                case KEYS.up:
                    upKeyCode = currentKey;
                    upButtonText.text = "Up: " + upKeyCode.ToString();
                    break;
                case KEYS.down:
                    downKeyCode = currentKey;
                    downButtonText.text = "Down: " + downKeyCode.ToString();
                    break;
                case KEYS.left:
                    leftKeyCode = currentKey;
                    leftButtonText.text = "Left: " + leftKeyCode.ToString();
                    break;
                case KEYS.right:
                    rightKeyCode = currentKey;
                    rightButtonText.text = "Right: " + rightKeyCode.ToString();
                    break;
                */
                }
                gettingNextKey = false;
            }
        }

        //Select start the game
        if (Input.GetKeyDown(SaveData.Instance.AutoFireButtonKeyCode) || Input.GetKeyDown(SaveData.Instance.AutoFireButtonKeyCode)) {
            switch(curSelect) {
            case 0:
                gettingNextKey = true;
                key = KEYS.shoot;
                break;
            case 1:
                gettingNextKey = true;
                key = KEYS.shield;
                break;
            case 2:
                gettingNextKey = true;
                key = KEYS.start;
                break;
            case 3:
                gettingNextKey = true;
                key = KEYS.up;
                break;
            case 4:
                gettingNextKey = true;
                key = KEYS.down;
                break;
            case 5:
                gettingNextKey = true;
                key = KEYS.left;
                break;
            case 6:
                gettingNextKey = true;
                key = KEYS.right;
                break;
            case 7:
                break;
            case 8:
                isWindowed = !isWindowed;
                if(isWindowed) {
                    windowedText.text = "Windowed";
                } else {
                    windowedText.text = "Not Windowed";
                }
                break;
            case 9:
                Debug.Log("Saved Game from menu");
                SaveCurrentControls();
                ApplyVideoSettings();
                SaveData.Instance.SaveGame();
                ResetAllMenuPositions();
                break;
            case 10:
                Debug.Log("Initialize Defaults");
                SaveData.Instance.InitDefaults();
                break;
            case 11:
                StartCoroutine(LoadTitleScreenMenu());
                break;
            default:
                break;
            }
        }

        switch(curSelect) {
            case 7:
            if (Input.GetKeyDown(SaveData.Instance.LeftButtonKeyCode)) {
                if(resolutionChoice > 0) {
                    resolutionChoice--;
                    ChangeResolution(resolutionChoice);
                    resolutionText.text = resolutionX + "x" + resolutionY;
                }
            } else if(Input.GetKeyDown(SaveData.Instance.RightButtonKeyCode)) {
                if(resolutionChoice < 4) {
                    resolutionChoice++;
                    ChangeResolution(resolutionChoice);
                    resolutionText.text = resolutionX + "x" + resolutionY;
                }
            }
            break;
        }

	}

    private KeyCode fetchKey() {
        var e = System.Enum.GetNames(typeof(KeyCode)).Length;
        for(int i = 0; i < e; i++){
            if(Input.GetKeyDown((KeyCode)i)){
                return (KeyCode)i;
            }
        }
        //Unfortunatly for joystick this must all be done in a big if else, there is no better way.
        if(Input.GetKeyDown("joystick 1 button 0")) {
            return KeyCode.Joystick1Button0;
        } else if(Input.GetKeyDown("joystick 1 button 1")) {
            return KeyCode.Joystick1Button1;
        }  else if(Input.GetKeyDown("joystick 1 button 2")) {
            return KeyCode.Joystick1Button2;
        }  else if(Input.GetKeyDown("joystick 1 button 3")) {
            return KeyCode.Joystick1Button3;
        }  else if(Input.GetKeyDown("joystick 1 button 4")) {
            return KeyCode.Joystick1Button4;
        }  else if(Input.GetKeyDown("joystick 1 button 5")) {
            return KeyCode.Joystick1Button5;
        }  else if(Input.GetKeyDown("joystick 1 button 6")) {
            return KeyCode.Joystick1Button6;
        }  else if(Input.GetKeyDown("joystick 1 button 7")) {
            return KeyCode.Joystick1Button7;
        }  else if(Input.GetKeyDown("joystick 1 button 8")) {
            return KeyCode.Joystick1Button8;
        }  else if(Input.GetKeyDown("joystick 1 button 9")) {
            return KeyCode.Joystick1Button9;
        }  else if(Input.GetKeyDown("joystick 1 button 10")) {
            return KeyCode.Joystick1Button10;
        }  else if(Input.GetKeyDown("joystick 1 button 11")) {
            return KeyCode.Joystick1Button11;
        }  else if(Input.GetKeyDown("joystick 1 button 12")) {
            return KeyCode.Joystick1Button12;
        }  else if(Input.GetKeyDown("joystick 1 button 13")) {
            return KeyCode.Joystick1Button13;
        }  else if(Input.GetKeyDown("joystick 1 button 14")) {
            return KeyCode.Joystick1Button14;
        }  else if(Input.GetKeyDown("joystick 1 button 15")) {
            return KeyCode.Joystick1Button15;
        }  else if(Input.GetKeyDown("joystick 1 button 16")) {
            return KeyCode.Joystick1Button16;
        }  else if(Input.GetKeyDown("joystick 1 button 17")) {
            return KeyCode.Joystick1Button17;
        }  else if(Input.GetKeyDown("joystick 1 button 18")) {
            return KeyCode.Joystick1Button18;
        }  else if(Input.GetKeyDown("joystick 1 button 19")) {
            return KeyCode.Joystick1Button19;
        }
        return KeyCode.None;
    }

    private void InitControls() {
        shootKeyCode = SaveData.Instance.AutoFireButtonKeyCode;
        shieldKeyCode = SaveData.Instance.ShieldButtonKeyCode;
        startKeyCode = SaveData.Instance.PauseButtonKeyCode;
        /*
        upKeyCode = SaveData.Instance.UpButtonKeyCode;
        downKeyCode = SaveData.Instance.DownButtonKeyCode;
        leftKeyCode = SaveData.Instance.LeftButtonKeyCode;
        rightKeyCode = SaveData.Instance.RightButtonKeyCode;
        */

        resolutionX = SaveData.Instance.resolutionX;
        resolutionY = SaveData.Instance.resolutionY;
        isWindowed = SaveData.Instance.isWindowed;
    }

    private void SaveCurrentControls() {
        SaveData.Instance.AutoFireButtonKeyCode = shootKeyCode;
        SaveData.Instance.ShieldButtonKeyCode = shieldKeyCode;
        SaveData.Instance.PauseButtonKeyCode = startKeyCode;

        /*
        SaveData.Instance.UpButtonKeyCode = upKeyCode;
        SaveData.Instance.DownButtonKeyCode = downKeyCode;
        SaveData.Instance.LeftButtonKeyCode = leftKeyCode;
        SaveData.Instance.RightButtonKeyCode = rightKeyCode;
        */


        SaveData.Instance.resolutionX = resolutionX;
        SaveData.Instance.resolutionY = resolutionY;
        SaveData.Instance.isWindowed = isWindowed;
    }

    private void InitTextFields() {
        shootButtonText = shootButton.GetComponent<Text>();

        shieldButtonText = shieldButton.GetComponent<Text>();

        startButtonText = startButton.GetComponent<Text>();

        /*
        upButtonText = upButton.GetComponent<Text>();
        downButtonText = downButton.GetComponent<Text>();
        leftButtonText = leftButton.GetComponent<Text>();
        rightButtonText = rightButton.GetComponent<Text>();
        */

        resolutionText = resolutionTextObject.GetComponent<Text>();
        windowedText = windowedTextObject.GetComponent<Text>();

        SetAllTextFields();
    }

    private void SetAllTextFields() {
        shootButtonText.text = "Shoot: " + shootKeyCode.ToString();

        shieldButtonText.text = "Shield: " + shieldKeyCode.ToString();

        startButtonText.text = "Pause: " + startKeyCode.ToString();

        /*
        upButtonText.text = "Up: " + upKeyCode.ToString();
        downButtonText.text = "Down: " + downKeyCode.ToString();
        leftButtonText.text = "Left: " + leftKeyCode.ToString();
        rightButtonText.text = "Right: " + rightKeyCode.ToString();
        */


        resolutionText.text = resolutionX + "x" + resolutionY;
        if(isWindowed) {
            windowedText.text = "Windowed";
        } else {
            windowedText.text = "Not Windowed";
        }
    }

    private void CreateAllObjects() {
        shootButton = Resources.Load("UIObjects/ControlsMenu/ShootButtonText") as GameObject;
        shootButton = Instantiate(shootButton);
        shootButton.transform.SetParent(uiCanvas.transform, false);

        shieldButton = Resources.Load("UIObjects/ControlsMenu/ShieldButtonText") as GameObject;
        shieldButton = Instantiate(shieldButton);
        shieldButton.transform.SetParent(uiCanvas.transform, false);

        startButton = Resources.Load("UIObjects/ControlsMenu/PauseButtonText") as GameObject;
        startButton = Instantiate(startButton);
        startButton.transform.SetParent(uiCanvas.transform, false);


        /*
        upButton = Resources.Load("UIObjects/ControlsMenu/UpButtonText") as GameObject;
        upButton = Instantiate(upButton);
        upButton.transform.SetParent(uiCanvas.transform, false);

        downButton = Resources.Load("UIObjects/ControlsMenu/DownButtonText") as GameObject;
        downButton = Instantiate(downButton);
        downButton.transform.SetParent(uiCanvas.transform, false);

        leftButton = Resources.Load("UIObjects/ControlsMenu/LeftButtonText") as GameObject;
        leftButton = Instantiate(leftButton);
        leftButton.transform.SetParent(uiCanvas.transform, false);

        rightButton = Resources.Load("UIObjects/ControlsMenu/RightButtonText") as GameObject;
        rightButton = Instantiate(rightButton);
        rightButton.transform.SetParent(uiCanvas.transform, false);
        */


        resolutionTextObject = Resources.Load("UIObjects/ControlsMenu/ResolutionPickerText") as GameObject;
        resolutionTextObject = Instantiate(resolutionTextObject);
        resolutionTextObject.transform.SetParent(uiCanvas.transform, false);

        windowedTextObject = Resources.Load("UIObjects/ControlsMenu/WindowedToggleText") as GameObject;
        windowedTextObject = Instantiate(windowedTextObject);
        windowedTextObject.transform.SetParent(uiCanvas.transform, false);

        saveText = Resources.Load("UIObjects/ControlsMenu/Save") as GameObject;
        saveText = Instantiate(saveText);
        saveText.transform.SetParent(uiCanvas.transform, false);

        resetToDefaultsText = Resources.Load("UIObjects/ControlsMenu/ResetDefaults") as GameObject;
        resetToDefaultsText = Instantiate(resetToDefaultsText);
        resetToDefaultsText.transform.SetParent(uiCanvas.transform, false);

        backText = Resources.Load("UIObjects/ControlsMenu/Back") as GameObject;
        backText = Instantiate(backText);
        backText.transform.SetParent(uiCanvas.transform, false);

    }

    IEnumerator LoadTitleScreenMenu(){
        PlayConfirm();
        Destroy(darkPanel);
        Destroy(shootButton);
        Destroy(shieldButton);
        Destroy(startButton);
        /*
        Destroy(upButton);
        Destroy(downButton);
        Destroy(leftButton);
        Destroy(rightButton);
        */
        Destroy(resolutionTextObject);
        Destroy(windowedTextObject);
        Destroy(saveText);
        Destroy(resetToDefaultsText);
        Destroy(backText);
        yield return new WaitForSeconds(0.05f);
        GameObject optionsMenu = Resources.Load("UIObjects/OptionsMenu/OptionsMenu") as GameObject;
        optionsMenu = Instantiate(optionsMenu);
        optionsMenu.transform.SetParent(uiCanvas.transform, false);
        Destroy(gameObject);
        yield return null;
    }

    public void ChangeResolution(int value) {
        switch(value) {
        case 0:
            resolutionX = 1920;
            resolutionY = 1280;
            break;
        case 1:
            resolutionX = 1600;
            resolutionY = 900;
            break;
        case 2:
            resolutionX = 1366;
            resolutionY = 768;
            break;
        case 3:
            resolutionX = 1280;
            resolutionY = 720;
            break;
        case 4:
            resolutionX = 1174;
            resolutionY = 664;
            break;
        }
    }

    private int GetCurrentResolutionChoice(int resolutionX) {
        switch(resolutionX) {
        case 1920:
            return 0;
        case 1600:
            return 1;
        case 1366:
            return 2;
        case 1280:
            return 3;
        case 1174:
            return 4;
        default:
            return -1;
        }
    }

    private void ApplyVideoSettings() {
        Screen.SetResolution(resolutionX, resolutionY, !isWindowed);
    }

    private void ResetAllMenuPositions() {
        menuLocations.Clear();
        menuLocations.Add(new Vector2(shootButton.transform.position.x, shootButton.transform.position.y));
        menuLocations.Add(new Vector2(shieldButton.transform.position.x, shieldButton.transform.position.y));
        menuLocations.Add(new Vector2(startButton.transform.position.x, startButton.transform.position.y));
        /*
        menuLocations.Add(new Vector2(upButton.transform.position.x, upButton.transform.position.y));
        menuLocations.Add(new Vector2(downButton.transform.position.x, downButton.transform.position.y));
        menuLocations.Add(new Vector2(leftButton.transform.position.x, leftButton.transform.position.y));
        menuLocations.Add(new Vector2(rightButton.transform.position.x, rightButton.transform.position.y));
        */

        menuLocations.Add(new Vector2(resolutionTextObject.transform.position.x, resolutionTextObject.transform.position.y));
        menuLocations.Add(new Vector2(windowedTextObject.transform.position.x, windowedTextObject.transform.position.y));

        menuLocations.Add(new Vector2(saveText.transform.position.x, saveText.transform.position.y));
        menuLocations.Add(new Vector2(resetToDefaultsText.transform.position.x, resetToDefaultsText.transform.position.y));
        menuLocations.Add(new Vector2(backText.transform.position.x, backText.transform.position.y));

        gameObject.transform.position = menuLocations[curSelect];
    }
}
