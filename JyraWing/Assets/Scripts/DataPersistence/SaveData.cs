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
			}
			return instance;
		}
	}

	public int livesPerCredit = 3;
	public int highScore = 1000;
    public int BGMLevel = 10;
    public int SFXLevel = 10;

    public KeyCode AutoFireButtonKeyCode;
    public KeyCode ShieldButtonKeyCode;
    public KeyCode PauseButtonKeyCode;
    public KeyCode StartButtonKeyCode;
    public KeyCode UpButtonKeyCode;
    public KeyCode DownButtonKeyCode;
    public KeyCode LeftButtonKeyCode;
    public KeyCode RightButtonKeyCode;

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
        StartButtonKeyCode = KeyCode.Return;
        UpButtonKeyCode = KeyCode.UpArrow;
        DownButtonKeyCode = KeyCode.DownArrow;
        LeftButtonKeyCode = KeyCode.LeftArrow;
        RightButtonKeyCode = KeyCode.RightArrow;

        resolutionX = 1920;
        resolutionY = 1080;
        isWindowed = false;
    }

}
