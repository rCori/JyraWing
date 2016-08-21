﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IngameMenu : Menu {
	private GameObject uiCanvas;
	private GameObject yesText;
	private GameObject noText;
	private GameObject title;
	private GameObject darkPanel;

	public delegate void IngameMenuDelegate();
	public static event IngameMenuDelegate UnpauseEvent;

	private bool lockScreen;

	// Use this for initialization
	void Start () {
		InitMenu ();
		numberOfItems = 2;
		isVertical = false;
		lockScreen = false;
		//create the menu text stuff
		uiCanvas = GameObject.Find ("Canvas");
		darkPanel = Resources.Load ("UIObjects/InGameMenu/IngamePanel") as GameObject;
		darkPanel = Instantiate (darkPanel);
		darkPanel.transform.SetParent (uiCanvas.transform, false);
		darkPanel.transform.SetSiblingIndex (darkPanel.transform.GetSiblingIndex () - 1);
		yesText = Resources.Load ("UIObjects/InGameMenu/YesText") as GameObject;
		yesText = Instantiate (yesText);
		yesText.transform.SetParent(uiCanvas.transform, false);
		noText = Resources.Load ("UIObjects/InGameMenu/NoText") as GameObject;
		noText = Instantiate (noText);
		noText.transform.SetParent(uiCanvas.transform, false);
		title = Resources.Load ("UIObjects/InGameMenu/IngameMenuTitle") as GameObject;
		title = Instantiate (title);
		title.transform.SetParent (uiCanvas.transform, false);
		//Amount to move selector over from a selection when that item is selected.
		float adjustPt = Screen.width / 10.0f;

		menuLocations.Add(new Vector2(noText.transform.position.x, noText.transform.position.y));
		menuLocations.Add(new Vector2(yesText.transform.position.x, yesText.transform.position.y));

		gameObject.transform.position = menuLocations [0];

	}

	// Update is called once per frame
	void Update () {
		if (!lockScreen) {
			MenuScroll ();

			//No: Continue game, unpausing it.
			if (Input.GetButtonDown ("Fire")) {
				if (curSelect == 0) {
					if (UnpauseEvent != null) {
						UnpauseEvent ();
					}
					BackOut ();
					//Yes: Go back to main menu
				} else if (curSelect == 1) {
					StartCoroutine (LoadTitleSceneCoroutine ());
				}
			}
			if (Input.GetButtonDown ("Pause")) {
				if (UnpauseEvent != null) {
					UnpauseEvent ();
				}
				BackOut ();
			}
		}
	}

	public void RemoveMenu() {
		PlayConfirm ();
		Destroy (title);
		Destroy (noText);
		Destroy (yesText);
		Destroy (gameObject);
		Destroy (darkPanel);
	}

	IEnumerator LoadTitleSceneCoroutine(){
		PlayConfirm ();
		lockScreen = true;
		yield return new WaitForSeconds (0.1f);
		SceneManager.LoadScene("titleScene");
	}

	void BackOut(){
		PlayConfirm ();
		RemoveMenu ();
	}
}
