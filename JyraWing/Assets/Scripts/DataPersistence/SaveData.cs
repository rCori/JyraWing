using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

[System.Serializable]
public class SaveData  {

	private static SaveData instance;
	private SaveData() {}

	public static SaveData Instance {
		get{
			if (instance == null) {
				instance = new SaveData ();
                instance.LoadGame();
			}
			return instance;
		}
	}

	public int livesPerCredit = 3;
	public int highScore = 1000;
    public int BGMLevel = 10;
    public int SFXLevel = 10;

    //Keycodes for the keyboard input.
    public KeyCode AutoFireButtonKeyCode;
    public KeyCode ShieldButtonKeyCode;

    //Keycodes for the controller input
    public KeyCode AutoFireGamepadButtonKeyCode;
    public KeyCode ShieldGamepadButtonKeyCode;

    public int resolutionX, resolutionY;
    public bool isWindowed;

	public void LoadGame() {
		if (!File.Exists (Application.dataPath + "/savegame.json")) {
            InitDefaults();
			SaveGame ();
		}
		FileStream saveFile = File.Open (Application.dataPath + "/savegame.json", System.IO.FileMode.Open);
		StreamReader reader = new StreamReader (saveFile);
		instance = JsonUtility.FromJson<SaveData> (reader.ReadToEnd ());
        saveFile.Close();
	}

	public void SaveGame() {
		Debug.Log ("Saving game...");
		string jsonString = JsonUtility.ToJson (this);
        using (StreamWriter outputFile = new StreamWriter(Application.dataPath + "/savegame.json")) {
            outputFile.Flush();
            outputFile.Write(jsonString);
        }
	}

    public void InitDefaults() {
        AutoFireButtonKeyCode = KeyCode.X;
        ShieldButtonKeyCode = KeyCode.Z;

        AutoFireGamepadButtonKeyCode = KeyCode.Joystick1Button0;
        ShieldGamepadButtonKeyCode = KeyCode.Joystick1Button4;

        resolutionX = 1920;
        resolutionY = 1080;
        isWindowed = false;
    }

    public void EnterScore(int score) {
        if(score > highScore && !LevelControllerBehavior.SingleLevel) {
            Debug.LogError("<color=#000080ff>SaveData.EnterScore called. New score of " + score + 
                " will overwrite old high score "+ highScore +"</color>");
            highScore = score;
        } else if(LevelControllerBehavior.SingleLevel) {
            Debug.LogError("<color=#000080ff>SaveData.EnterScore called but this is a single "+
                 "level being played so no highscore will save</color>");
        } else {
            Debug.LogError("<color=#000080ff>SaveData.EnterScore called. New score of " + score + 
                " is smaller than previous high score of "+ highScore +"</color>");
        }
        SaveGame();
    }
}
