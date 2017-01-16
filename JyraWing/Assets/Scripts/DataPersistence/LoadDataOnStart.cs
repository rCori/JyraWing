using UnityEngine;
using System.Collections;
using System.IO;

public class LoadDataOnStart : MonoBehaviour {

    public bool LoadHighScores = true;

	// Use this for initialization
	void Start () {
		SaveData.Instance.LoadGame ();
        if(LoadHighScores) {
            HighScoreData.Instance.LoadGame();
        }
		ScoreController.ResetScore ();
        Cursor.visible = false;
	}
}
