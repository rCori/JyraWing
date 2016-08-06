using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : Menu {


	private GameObject uiCanvas;
	private GameObject level1StartGame;
	private GameObject level2StartGame;
	private GameObject quitGame;

	// Use this for initialization
	void Start () {
		ForceWindowed ();
		InitMenu ();
		numberOfItems = 3;
		isVertical = true;
		//create the menu text stuff
		uiCanvas = GameObject.Find ("Canvas");
		level1StartGame = Resources.Load ("UIObjects/TitleScreenMenu/Level1StartText") as GameObject;
		level1StartGame = Instantiate (level1StartGame);
		level1StartGame.transform.SetParent(uiCanvas.transform, false);

		level2StartGame = Resources.Load ("UIObjects/TitleScreenMenu/Level2StartText") as GameObject;
		level2StartGame = Instantiate (level2StartGame);
		level2StartGame.transform.SetParent(uiCanvas.transform, false);

		quitGame = Resources.Load ("UIObjects/TitleScreenMenu/TitleQuitText") as GameObject;
		quitGame = Instantiate (quitGame);
		quitGame.transform.SetParent(uiCanvas.transform, false);

		//Amount to move selector over from a selection when that item is selected.
		float adjustPt = Screen.width / 10.0f;

//		menuLocations.Add (new Vector2 (level1StartGame.transform.position.x-adjustPt, level1StartGame.transform.position.y));
//		menuLocations.Add (new Vector2 (level2StartGame.transform.position.x-adjustPt, level2StartGame.transform.position.y));
//		menuLocations.Add (new Vector2 (quitGame.transform.position.x-adjustPt, quitGame.transform.position.y));

		menuLocations.Add (new Vector2 (level1StartGame.transform.position.x, level1StartGame.transform.position.y));
		menuLocations.Add (new Vector2 (level2StartGame.transform.position.x, level2StartGame.transform.position.y));
		menuLocations.Add (new Vector2 (quitGame.transform.position.x, quitGame.transform.position.y));

		gameObject.transform.position = menuLocations [0];

	}
	
	// Update is called once per frame
	void Update () {
		MenuScroll ();
		//Select start the game
		if(Input.GetButton ("Fire") || Input.GetButton ("Pause")){
			if(curSelect == 0){
				beep.Play();
				SceneManager.LoadScene("Level_1");
			}
			else if(curSelect == 1){
				beep.Play();
				SceneManager.LoadScene("Level_2");
			}
			else if(curSelect == 2){
				beep.Play();
				Application.Quit ();
			}
		}
	}

	/// <summary>
	///If fullscreen is chosen we want to force a windowed game.
	/// Resolution will stay the same.
	/// </summary>
	public void ForceWindowed()
	{
		if (Screen.fullScreen) {
			int width = Screen.width;
			int height = Screen.height;
			Screen.SetResolution(width, height, false);
			Screen.fullScreen = false;
		}
	}
}
