using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameDisplayText : MonoBehaviour {

    private Text nameDisplayText;

    private string displayedName;

	// Use this for initialization
	void Start () {
        nameDisplayText = GetComponent<Text>();
        displayedName = "";
        NameEntryMenu.AddCharEvent += AddCharacter;
        NameEntryMenu.DeleteCharEvent += DeleteCharacter;
	}

    void OnDestroy() {
        NameEntryMenu.AddCharEvent -= AddCharacter;
        NameEntryMenu.DeleteCharEvent -= DeleteCharacter;
    }

    private void AddCharacter(char c) {
        displayedName += c;
        nameDisplayText.text = displayedName;
    }

    private void DeleteCharacter() {
        displayedName = displayedName.Substring(0, displayedName.Length - 1);
        nameDisplayText.text = displayedName;
    }

}
