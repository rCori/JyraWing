using UnityEngine;
using System.Collections;
using System.IO;

public class LoadDataOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SaveData.Instance.LoadGame ();
		ScoreController.ResetScore ();
        Cursor.visible = false;
	}
}
