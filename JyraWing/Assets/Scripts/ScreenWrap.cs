using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {


	private float spriteWidth;
	private float horzExtent;

	// Use this for initialization
	void Start(){
		
		//Orthagriphc size is the distance from top to middle of the screen.
		float vertExtent = Camera.main.orthographicSize*2;
		//horzontal extent is how many game units across the camera sees.
		horzExtent = vertExtent * Screen.width / Screen.height;
		//Need the width of the background sprite in game units just like the screen
		spriteWidth = GetComponent<Renderer>().bounds.size.x;

	}

	void Update(){
		if (transform.position.x <= -(horzExtent + spriteWidth) / 2) {
			Vector3 newPos = new Vector3((horzExtent + spriteWidth) / 2, -0.52f, 0f);
			transform.position = newPos;
		}
	}
		
}
