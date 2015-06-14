using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed;
	public bool infinite;
	private float pixelsToUnits;
	private float width;

	// Use this for initialization
	void Start(){
		pixelsToUnits = 0.01f;
		width = GetComponent<Renderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
	}

	void OnBecameInvisible(){
		if (infinite) {
			transform.position = new Vector2((pixelsToUnits *Screen.width) + (width/2), 0);
		}
	}
}
