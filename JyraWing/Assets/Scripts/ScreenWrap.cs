using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {


	private double spriteWidth;
	private double horzExtent;

    public GameObject otherBackground;

	// Use this for initialization
	void Start(){
		
		//Orthagriphc size is the distance from top to middle of the screen.
		double vertExtent = Camera.main.orthographicSize*2.0;
        double screenWidth = Screen.width;
        double screenHeight = Screen.height;
		//horzontal extent is how many game units across the camera sees.
		horzExtent = vertExtent * screenWidth / screenHeight;
		//Need the width of the background sprite in game units just like the screen
		spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;

	}

	void Update(){
        CheckForRepeat();
	}

    /*
    void Method1() {
        if (transform.position.x <= -(horzExtent + spriteWidth) / 2.0) {
            float xVal = (float)(((horzExtent + spriteWidth) / 2.0) + (spriteWidth - horzExtent));
			Vector3 newPos = new Vector3(xVal, -0.52f, 0f);
			transform.position = newPos;
		}
    }
    */

    void CheckForRepeat() {
        if (transform.position.x <= -(horzExtent + spriteWidth) / 2.0000) {
            float xVal = otherBackground.transform.position.x + (float)spriteWidth - 0.01f;
            Vector3 newPos = new Vector3(xVal, -0.52f, 0f);
			transform.position = newPos;
        }
    }
		
}
