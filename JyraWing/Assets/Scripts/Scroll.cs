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
		float vertExtent = Camera.main.orthographicSize*2;
		//horzontal extent is how many game units across the camera sees.
		horzExtent = vertExtent * Screen.width / Screen.height;
		spriteWidth = GetComponent<Renderer>().bounds.size.x;
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

	void OnBecameInvisible(){
		if (infinite) {
			Vector3 newPos = new Vector3(horzExtent + (extraWidth*3/2), 0f, 0f);
			transform.position = newPos;
		}
	}
}
