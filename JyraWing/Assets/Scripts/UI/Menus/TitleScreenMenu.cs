using UnityEngine;
using System.Collections;

public class TitleScreenMenu : Menu {


	private GameObject uiCanvas;
	private GameObject startGame;
	private GameObject quitGame;

	// Use this for initialization
	void Start () {
		InitMenu ();
		numberOfItems = 2;
		isVertical = true;
		//create the menu text stuff
		uiCanvas = GameObject.Find ("Canvas");
		startGame = Resources.Load ("UIObjects/TitleScreenMenu/TitleStartText") as GameObject;
		startGame = Instantiate (startGame);
		startGame.transform.SetParent(uiCanvas.transform, false);
		quitGame = Resources.Load ("UIObjects/TitleScreenMenu/TitleQuitText") as GameObject;
		quitGame = Instantiate (quitGame);
		quitGame.transform.SetParent(uiCanvas.transform, false);

		//Amount to move selector over from a selection when that item is selected.
		float adjustPt = Screen.width / 10.0f;

		menuLocations.Add (new Vector2 (startGame.transform.position.x-adjustPt, startGame.transform.position.y));
		menuLocations.Add (new Vector2 (quitGame.transform.position.x-adjustPt, quitGame.transform.position.y));

		gameObject.transform.position = menuLocations [0];

	}
	
	// Update is called once per frame
	void Update () {
		MenuScroll ();
		//Select start the game
		if(Input.GetButton ("Fire1") || Input.GetButton ("Submit")){
			if(curSelect == 0){
				beep.Play();
				Application.LoadLevel("Level_1");
			}

			else if(curSelect == 1){
				beep.Play();
				Application.Quit ();
			}
		}
	}
}
