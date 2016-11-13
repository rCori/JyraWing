using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ALL OF THIS CODE NEEDS TO BE CLEANED UP AND EXPANDED ON
public class OnScreenDialog : MonoBehaviour {

    public delegate void OnScreenDialogStart();
	public static event OnScreenDialogStart PauseOnScreenDialogStartEvent, PauseOnScreenDialogEndEvent;

    public GameObject canvas;
    
    public Text uiText;
    private GameObject darkPanel;

	// Use this for initialization
	void Start () {
        uiText = GetComponent<Text>();
       
	}
	
    public void ShowDialog(string dialog) {

        darkPanel = Resources.Load ("UIObjects/InGameMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (canvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);
        PauseOnScreenDialogStartEvent();
        uiText.transform.SetSiblingIndex(darkPanel.transform.GetSiblingIndex () + 1);
        uiText.text = dialog;

        PlayerInputController.AutoFireButton += RemoveDialog;
    }

    public void RemoveDialog(bool down) {
        if(down) {
            PauseOnScreenDialogEndEvent();
            uiText.text = "";
            Destroy(darkPanel);
            PlayerInputController.AutoFireButton -= RemoveDialog;
        }
    }
}
