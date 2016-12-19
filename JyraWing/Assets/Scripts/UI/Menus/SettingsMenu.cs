using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenu : Menu {

    private GameObject uiCanvas;

    private GameObject darkPanel;

    //Keyboard controls
    private GameObject keyboardShootButton;
    private GameObject keyboardShieldButton;

    //Gamepad controls
    private GameObject gamepadShootButton;
    private GameObject gamepadShieldButton;

    //Header text for controls
    private GameObject keyboardControlsText;
    private GameObject gamepadControlsText;

    //Text for keyboard controls
    private Text keyboardShootButtonText;
    private Text keyboardShieldButtonText;

    //Text for gamepad controls
    private Text gamepadShootButtonText;
    private Text gamepadShieldButtonText;

    //Initial candidate keyboard controls
    private KeyCode keyboardShootKeyCode;
    private KeyCode keyboardShieldKeyCode;

    //Initial candidate keyboard controls
    private KeyCode gamepadShootKeyCode;
    private KeyCode gamepadShieldKeyCode;

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

    public delegate void InitializePlayerControls();
    public static event InitializePlayerControls initializePlayerControlsEvent;

    public enum KEYS {
        keyboardShoot,
        keyboardShield,
        gamePadShoot,
        gamePadShield
    };

    public enum MENUCONTEXT {
        titleScreen,
        inGame
    };

    public KEYS key;
    public MENUCONTEXT menuContext;

    private bool gettingNextKeyboardKey, gettingNextGamepadButton;
    private bool selectionSwitch;

	// Use this for initialization
	void Start () {
	    InitMenu();
        numberOfItems = 9;
        isVertical = true;
        uiCanvas = GameObject.Find("Canvas");
        gettingNextKeyboardKey = false;
        gettingNextGamepadButton = false;
        selectionSwitch = false;

        darkPanel = Resources.Load ("UIObjects/ControlsMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (uiCanvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);

        CreateAllObjects();
        InitControls();
        InitInputTextFields();
        InitResolutionTextFields();


        menuLocations.Add(new Vector2(keyboardShootButton.transform.position.x, keyboardShootButton.transform.position.y));
        menuLocations.Add(new Vector2(keyboardShieldButton.transform.position.x, keyboardShieldButton.transform.position.y));

        menuLocations.Add(new Vector2(gamepadShootButton.transform.position.x, gamepadShootButton.transform.position.y));
        menuLocations.Add(new Vector2(gamepadShieldButton.transform.position.x, gamepadShieldButton.transform.position.y));

        menuLocations.Add(new Vector2(resolutionTextObject.transform.position.x, resolutionTextObject.transform.position.y));
        menuLocations.Add(new Vector2(windowedTextObject.transform.position.x, windowedTextObject.transform.position.y));

        menuLocations.Add(new Vector2(saveText.transform.position.x, saveText.transform.position.y));
        menuLocations.Add(new Vector2(resetToDefaultsText.transform.position.x, resetToDefaultsText.transform.position.y));
        menuLocations.Add(new Vector2(backText.transform.position.x, backText.transform.position.y));

        gameObject.transform.position = menuLocations[0];
	}

	// Update is called once per frame
	void Update () {
        if(!gettingNextKeyboardKey && ! gettingNextGamepadButton) {
	        MenuScroll();
        }
        if ((ButtonInput.Instance().StartButtonDown() || ButtonInput.Instance().FireButtonDown())) {
            switch(curSelect) {
            case 0:
                if(!gettingNextKeyboardKey) {
                    gettingNextKeyboardKey = true;
                    key = KEYS.keyboardShoot;
                    return;
                }
                break;
            case 1:
                if(!gettingNextKeyboardKey) {
                    gettingNextKeyboardKey = true;
                    key = KEYS.keyboardShield;
                    return;
                }
                break;
            case 2:
                if(!gettingNextGamepadButton) {
                    gettingNextGamepadButton = true;
                    key = KEYS.gamePadShoot;
                    return;
                }
                break;
            case 3:
                if(!gettingNextGamepadButton) {
                    gettingNextGamepadButton = true;
                    key = KEYS.gamePadShield;
                    return;
                }
                break;
            case 4:
                break;
            case 5:
                isWindowed = !isWindowed;
                if(isWindowed) {
                    windowedText.text = "Windowed";
                } else {
                    windowedText.text = "Not Windowed";
                }
                break;
            case 6:
                Debug.Log("Saved Game from menu");
                SaveCurrentControls();
                ApplyVideoSettings();
                SaveData.Instance.SaveGame();
                LoadPrevMenu();
                break;
            case 7:
                Debug.Log("Initialize Defaults");
                SaveData.Instance.InitDefaults();
                break;
            case 8:
                LoadPrevMenu();
                break;
            default:
                break;
            }
        }

        switch(curSelect) {
            case 4:
            if (AxisInput.Instance().GetHorizontal() == -1.0 && !selectionSwitch) {
                if(resolutionChoice > 0) {
                    resolutionChoice--;
                    ChangeResolution(resolutionChoice);
                    resolutionText.text = resolutionX + "x" + resolutionY;
                }
                selectionSwitch = true;
            } else if(AxisInput.Instance().GetHorizontal() == 1.0 && !selectionSwitch) {
                if(resolutionChoice < 4) {
                    resolutionChoice++;
                    ChangeResolution(resolutionChoice);
                    resolutionText.text = resolutionX + "x" + resolutionY;
                }
                selectionSwitch = true;
            }
            else if(AxisInput.Instance().GetHorizontal() == 0.0f) {
                if (selectionSwitch) {
                    selectionSwitch = false;
                }
            }
            break;
        }

        if(gettingNextKeyboardKey) {
            KeyCode currentKey = fetchKeyboardKey();
            if(currentKey != KeyCode.None) {
                Debug.Log("currentKey is: " + currentKey.ToString());
                switch(key) {
                case KEYS.keyboardShoot:
                    keyboardShootKeyCode = currentKey;
                    keyboardShootButtonText.text = "Shoot: " + keyboardShootKeyCode.ToString();
                    break;
                case KEYS.keyboardShield:
                    keyboardShieldKeyCode = currentKey;
                    keyboardShieldButtonText.text = "Shield: " + keyboardShieldKeyCode.ToString();
                    break;
                }
                gettingNextKeyboardKey = false;
            }
        }

        if(gettingNextGamepadButton) {
            KeyCode currentButton = fetchJoystickKey();
            if(currentButton != KeyCode.None) {
                Debug.Log("currentButton is: " + (KeyCode) currentButton);
                switch(key) {
                case KEYS.gamePadShoot:
                    gamepadShootKeyCode = currentButton;
                    gamepadShootButtonText.text = "Shoot: " + gamepadShootKeyCode.ToString();
                    break;
                case KEYS.gamePadShield:
                    gamepadShieldKeyCode = currentButton;
                    gamepadShieldButtonText.text = "Shield: " + gamepadShieldKeyCode.ToString();
                    break;
                }
                gettingNextGamepadButton = false;
            }
        }
	}

    private KeyCode fetchKeyboardKey() {
        var e = System.Enum.GetNames(typeof(KeyCode)).Length;
        for(int i = 0; i < e; i++){
            if(Input.GetKeyDown((KeyCode)i)){
                KeyCode candidate = (KeyCode)i;
                //Prevent the arrow keys
                if(candidate != KeyCode.UpArrow && 
                    candidate != KeyCode.DownArrow && 
                    candidate != KeyCode.LeftArrow &&
                    candidate != KeyCode.RightArrow) {
                    return candidate;
                }
            }
        }
        return KeyCode.None;
    }

    private KeyCode fetchJoystickKey() {
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
        keyboardShootKeyCode = SaveData.Instance.AutoFireButtonKeyCode;
        keyboardShieldKeyCode = SaveData.Instance.ShieldButtonKeyCode;

        gamepadShootKeyCode = SaveData.Instance.AutoFireGamepadButtonKeyCode;
        gamepadShieldKeyCode = SaveData.Instance.ShieldGamepadButtonKeyCode;

        resolutionX = SaveData.Instance.resolutionX;
        resolutionY = SaveData.Instance.resolutionY;
        isWindowed = SaveData.Instance.isWindowed;
    }

    private void SaveCurrentControls() {
        SaveData.Instance.AutoFireButtonKeyCode = keyboardShootKeyCode;
        SaveData.Instance.ShieldButtonKeyCode = keyboardShieldKeyCode;

        SaveData.Instance.AutoFireGamepadButtonKeyCode = gamepadShootKeyCode;
        SaveData.Instance.ShieldGamepadButtonKeyCode = gamepadShieldKeyCode;

        SaveData.Instance.resolutionX = resolutionX;
        SaveData.Instance.resolutionY = resolutionY;
        SaveData.Instance.isWindowed = isWindowed;
    }

    private void InitInputTextFields() {
        keyboardShootButtonText = keyboardShootButton.GetComponent<Text>();
        keyboardShieldButtonText = keyboardShieldButton.GetComponent<Text>();

        gamepadShootButtonText = gamepadShootButton.GetComponent<Text>();
        gamepadShieldButtonText = gamepadShieldButton.GetComponent<Text>();

        resolutionText = resolutionTextObject.GetComponent<Text>();
        windowedText = windowedTextObject.GetComponent<Text>();

        SetAllTextFields();
    }

    private void SetAllTextFields() {
        keyboardShootButtonText.text = "Shoot: " + keyboardShootKeyCode.ToString();
        keyboardShieldButtonText.text = "Shield: " + keyboardShieldKeyCode.ToString();

        gamepadShootButtonText.text = "Shoot: " + gamepadShootKeyCode.ToString();
        gamepadShieldButtonText.text = "Shield: " + gamepadShieldKeyCode.ToString();

        resolutionText.text = resolutionX + "x" + resolutionY;
        if(isWindowed) {
            windowedText.text = "Windowed";
        } else {
            windowedText.text = "Not Windowed";
        }
    }

    private void CreateAllObjects() {

        keyboardControlsText = Resources.Load("UIObjects/ControlsMenu/KeyboardText") as GameObject;
        keyboardControlsText = Instantiate(keyboardControlsText);
        keyboardControlsText.transform.SetParent(uiCanvas.transform, false);

        gamepadControlsText = Resources.Load("UIObjects/ControlsMenu/GamepadText") as GameObject;
        gamepadControlsText = Instantiate(gamepadControlsText);
        gamepadControlsText.transform.SetParent(uiCanvas.transform, false);

        keyboardShootButton = Resources.Load("UIObjects/ControlsMenu/KeyboardShootButtonText") as GameObject;
        keyboardShootButton = Instantiate(keyboardShootButton);
        keyboardShootButton.transform.SetParent(uiCanvas.transform, false);

        keyboardShieldButton = Resources.Load("UIObjects/ControlsMenu/KeyboardShieldButtonText") as GameObject;
        keyboardShieldButton = Instantiate(keyboardShieldButton);
        keyboardShieldButton.transform.SetParent(uiCanvas.transform, false);

        gamepadShootButton = Resources.Load("UIObjects/ControlsMenu/GamepadShootButtonText") as GameObject;
        gamepadShootButton = Instantiate(gamepadShootButton);
        gamepadShootButton.transform.SetParent(uiCanvas.transform, false);

        gamepadShieldButton = Resources.Load("UIObjects/ControlsMenu/GamepadShieldButtonText") as GameObject;
        gamepadShieldButton = Instantiate(gamepadShieldButton);
        gamepadShieldButton.transform.SetParent(uiCanvas.transform, false);

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

        backText = Resources.Load("UIObjects/ControlsMenu/ExitNoSave") as GameObject;
        backText = Instantiate(backText);
        backText.transform.SetParent(uiCanvas.transform, false);

    }

    IEnumerator LoadTitleScreenMenu(){
        PlayConfirm();
        Destroy(darkPanel);
        Destroy(keyboardControlsText);
        Destroy(keyboardShootButton);
        Destroy(keyboardShieldButton);
        Destroy(gamepadControlsText);
        Destroy(gamepadShootButton);
        Destroy(gamepadShieldButton);
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

    IEnumerator LoadInGameMenu() {
        Debug.Log("Load in game menu");
        PlayConfirm();
        Destroy(darkPanel);
        Destroy(keyboardControlsText);
        Destroy(keyboardShootButton);
        Destroy(keyboardShieldButton);
        Destroy(gamepadControlsText);
        Destroy(gamepadShootButton);
        Destroy(gamepadShieldButton);
        Destroy(resolutionTextObject);
        Destroy(windowedTextObject);
        Destroy(saveText);
        Destroy(resetToDefaultsText);
        Destroy(backText);
        StartCoroutine(PauseControllerBehavior.WaitForRealSeconds(0.05f));
        GameObject inGameOptionsMenu = Resources.Load("UIObjects/InGameOptionsMenu/InGameOptionsMenu") as GameObject;
        inGameOptionsMenu = Instantiate(inGameOptionsMenu);
        inGameOptionsMenu.transform.SetParent(uiCanvas.transform, false);
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

    private void InitResolutionTextFields() {
        resolutionText.text = SaveData.Instance.resolutionX + "x" + SaveData.Instance.resolutionY;
        isWindowed = SaveData.Instance.isWindowed;
        if(isWindowed) {
            windowedText.text = "Windowed";
        } else {
            windowedText.text = "Not Windowed";
        }
        resolutionChoice = GetCurrentResolutionChoice(SaveData.Instance.resolutionX);
        resolutionText.text = resolutionX + "x" + resolutionY;
    }

    public void SetContext(MENUCONTEXT menuContext) {
        this.menuContext = menuContext;
    }

    private void LoadPrevMenu() {
        switch(menuContext) {
        case MENUCONTEXT.titleScreen:
            StartCoroutine(LoadTitleScreenMenu());
            break;
        case MENUCONTEXT.inGame:
            SaveData.Instance.LoadGame();
            initializePlayerControlsEvent();
            StartCoroutine(LoadInGameMenu());
            break;
        }
    }

    /*
    private void ResetAllMenuPositions() {

        //Destroy(darkPanel);
        //Destroy(keyboardControlsText);
        Destroy(keyboardShootButton);
        Destroy(keyboardShieldButton);
        //Destroy(gamepadControlsText);
        Destroy(gamepadShootButton);
        Destroy(gamepadShieldButton);
        Destroy(resolutionTextObject);
        Destroy(windowedTextObject);
        Destroy(saveText);
        Destroy(resetToDefaultsText);
        Destroy(backText);

        keyboardShootButton = Resources.Load("UIObjects/ControlsMenu/KeyboardShootButtonText") as GameObject;
        keyboardShootButton = Instantiate(keyboardShootButton);
        keyboardShootButton.transform.SetParent(uiCanvas.transform, false);

        keyboardShieldButton = Resources.Load("UIObjects/ControlsMenu/KeyboardShieldButtonText") as GameObject;
        keyboardShieldButton = Instantiate(keyboardShieldButton);
        keyboardShieldButton.transform.SetParent(uiCanvas.transform, false);

        gamepadShootButton = Resources.Load("UIObjects/ControlsMenu/GamepadShootButtonText") as GameObject;
        gamepadShootButton = Instantiate(gamepadShootButton);
        gamepadShootButton.transform.SetParent(uiCanvas.transform, false);

        gamepadShieldButton = Resources.Load("UIObjects/ControlsMenu/GamepadShieldButtonText") as GameObject;
        gamepadShieldButton = Instantiate(gamepadShieldButton);
        gamepadShieldButton.transform.SetParent(uiCanvas.transform, false);

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

        menuLocations.Clear();
        menuLocations.Add(new Vector2(keyboardShootButton.transform.position.x, keyboardShootButton.transform.position.y));
        menuLocations.Add(new Vector2(keyboardShieldButton.transform.position.x, keyboardShieldButton.transform.position.y));

        menuLocations.Add(new Vector2(gamepadShootButton.transform.position.x, gamepadShootButton.transform.position.y));
        menuLocations.Add(new Vector2(gamepadShieldButton.transform.position.x, gamepadShieldButton.transform.position.y));

        menuLocations.Add(new Vector2(resolutionTextObject.transform.position.x, resolutionTextObject.transform.position.y));
        menuLocations.Add(new Vector2(windowedTextObject.transform.position.x, windowedTextObject.transform.position.y));

        menuLocations.Add(new Vector2(saveText.transform.position.x, saveText.transform.position.y));
        menuLocations.Add(new Vector2(resetToDefaultsText.transform.position.x, resetToDefaultsText.transform.position.y));
        menuLocations.Add(new Vector2(backText.transform.position.x, backText.transform.position.y));

        gameObject.transform.position = menuLocations[curSelect];
    }
    */
}
