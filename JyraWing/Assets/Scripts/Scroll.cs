using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed;
	public bool infinite;
	private float spriteWidth;
	//If the background is wider than the camera's viewport and it needs to infinite scroll
	//We must move the background farther than just the edge of the camera, but farther to compensate.
	//This should show all of the background each time.
	private float extraWidth;
	private float horzExtent;

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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
	}

	/// <summary>
	/// Handle if the screen needs to loop forever
	/// </summary>
	void OnBecameInvisible(){
		if (infinite) {
			Vector3 newPos = new Vector3(horzExtent + (extraWidth*3/2), 0f, 0f);
			transform.position = newPos;
		}
	}
}
