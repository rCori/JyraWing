﻿using UnityEngine;
using System.Collections;

public class IngameMenu : Menu {
	


	private GameObject uiCanvas;
	private GameObject yesText;
	private GameObject noText;
	private GameObject title;

	// Use this for initialization
	void Start () {
		InitMenu ();
		numberOfItems = 2;
		isVertical = false;

		//create the menu text stuff
		uiCanvas = GameObject.Find ("Canvas");
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

		menuLocations.Add(new Vector2(noText.transform.position.x - adjustPt, noText.transform.position.y));
		menuLocations.Add(new Vector2(yesText.transform.position.x - adjustPt, yesText.transform.position.y));

		gameObject.transform.position = menuLocations [0];

	}

	// Update is called once per frame
	void Update () {
		MenuScroll ();

		//No: Continue game, unpausing it.
		if (Input.GetButton ("Fire")) {
			if (curSelect == 0) {
				beep.Play ();
				Destroy (title);
				Destroy (noText);
				Destroy (yesText);
				GameObject.Find ("GameController").GetComponent<GameController>().Unpause();
				Destroy (gameObject);

			//Yes: Go back to main menu
			} else if (curSelect == 1) {
				beep.Play ();
				Application.LoadLevel ("titleScene");
			}
		}
		if (Input.GetButton ("Toggle Speed")) {
			beep.Play ();
			Destroy (title);
			Destroy (noText);
			Destroy (yesText);
			GameObject.Find ("GameController").GetComponent<GameController>().Unpause();
			Destroy (gameObject);
		}
	}
}
