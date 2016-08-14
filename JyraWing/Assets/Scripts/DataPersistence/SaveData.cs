using UnityEngine;
using System.Collections;
using System.IO;

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

	public void LoadGame() {
		if (!File.Exists (Application.dataPath + "/savegame.json")) {
			SaveGame ();
		}
		FileStream saveFile = File.Open (Application.dataPath + "/savegame.json", System.IO.FileMode.Open);
		StreamReader reader = new StreamReader (saveFile);
		instance = JsonUtility.FromJson<SaveData> (reader.ReadToEnd ());
	}

	public void SaveGame() {
		Debug.Log ("Saving game...");
		string jsonString = JsonUtility.ToJson (this);
		File.WriteAllText (Application.dataPath+"/savegame.json", jsonString);
	}
}
