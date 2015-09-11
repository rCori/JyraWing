using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour {

	private int curSelect;
	private float selectTimer;
	private float selectTimeLimit;
	private AudioSource beep;
	
	private float spaceBetweenItems;
	private int numberOfItems;

	private GameObject uiCanvas;
	private GameObject yesText;
	private GameObject noText;
	private GameObject title;

	// Use this for initialization
	void Start () {
		curSelect = 0;
		selectTimer = 0f;
		selectTimeLimit = 0.5f;
		beep = gameObject.GetComponent<AudioSource> ();
		spaceBetweenItems = 350.0f;
		numberOfItems = 2;
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

	}

	// Update is called once per frame
	void Update () {
		//Timer prevents the options from being scrolled through as fast as this update happens.
		selectTimer += Time.deltaTime;
		//move selection down one
		float axis = Input.GetAxis ("Horizontal");
		if (axis > 0 && (selectTimer > selectTimeLimit) && curSelect != numberOfItems - 1) {
			curSelect++;
			transform.position = new Vector2 (transform.position.x + spaceBetweenItems, transform.position.y);
			selectTimer = 0f;
			beep.Play ();
		}
		
		//move selection up one
		if (axis < 0 && (selectTimer > selectTimeLimit) && curSelect != 0) {
			curSelect--;
			transform.position = new Vector2 (transform.position.x - spaceBetweenItems, transform.position.y);
			selectTimer = 0f;
			beep.Play ();
		}
		
		//Select start the game
		if (Input.GetButton ("Fire1")) {
			if (curSelect == 0) {
				beep.Play ();
				Destroy (title);
				Destroy (noText);
				Destroy (yesText);
				GameObject.Find ("GameController").GetComponent<GameController>().Unpause();
				Destroy (gameObject);

			} else if (curSelect == 1) {
				beep.Play ();
				Application.LoadLevel ("titleScene");
			}
		}
	}
}
