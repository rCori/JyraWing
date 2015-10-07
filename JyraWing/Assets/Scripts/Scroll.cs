using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour, PauseableItem {

	public float speed;
	public bool infinite;
	private float spriteWidth;
	//If the background is wider than the camera's viewport and it needs to infinite scroll
	//We must move the background farther than just the edge of the camera, but farther to compensate.
	//This should show all of the background each time.
	private float extraWidth;
	private float horzExtent;

	//We need to safely register this item to the gameController
	//This item might get created before the gameController so this ensures safety
	//private bool listSet;

	private bool _paused;

	// Use this for initialization
	void Start(){
		//Orthagriphc size is the distance from top to middle of the screen.
		float vertExtent = Camera.main.orthographicSize*2;
		//horzontal extent is how many game units across the camera sees.
		horzExtent = vertExtent * Screen.width / Screen.height;
		//Need the width of the background sprite in game units just like the screen
		spriteWidth = GetComponent<Renderer>().bounds.size.x;
		//Get the extra width difference of the background and the screen in game units.
		extraWidth = spriteWidth - horzExtent;
		if (extraWidth < 0 && infinite) {
			Debug.Log ("Scrolling background is not wide enough");
			extraWidth = 0;
		}
		_paused = false;
		RegisterToList ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!paused) {
			transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
	}

	/// <summary>
	/// Handle if the screen needs to loop forever
	/// </summary>
	void OnBecameInvisible(){
		if (infinite) {
			Vector3 newPos = new Vector3(horzExtent + (extraWidth*3/2)-0.5f, 0f, 0f);
			transform.position = newPos;
		}
	}

	void OnDestroy()
	{
		RemoveFromList ();
	}

	/* Implementation of PauseableItem interface */
	public bool paused
	{
		get
		{
			return _paused;
		}
		
		set
		{
			_paused = value;
		}
	}
	
	public void RegisterToList()
	{
		if (GameObject.Find ("GameController")) {
			GameObject.Find ("GameController").GetComponent<GameController> ().RegisterPause (this);
		}
	}

	//We can remove from the list without checking, it will be safe.
	public void RemoveFromList()
	{
		if (GameObject.Find ("GameController")) {
			GameObject.Find ("GameController").GetComponent<GameController> ().DelistPause (this);
		}
	}
}
