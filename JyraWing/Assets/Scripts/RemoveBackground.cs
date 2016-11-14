using UnityEngine;
using System.Collections;

public class RemoveBackground : MonoBehaviour {

	private float spriteWidth;
	private float horzExtent;

    private bool showing;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start(){
		
		//Orthagriphc size is the distance from top to middle of the screen.
		float vertExtent = Camera.main.orthographicSize*2;
		//horzontal extent is how many game units across the camera sees.
		horzExtent = vertExtent * Screen.width / Screen.height;
		//Need the width of the background sprite in game units just like the screen
		spriteWidth = GetComponent<Renderer>().bounds.size.x;
        showing = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x <= -(horzExtent + spriteWidth) / 2) {
            Destroy(gameObject);
		}
        if(transform.position.x > (horzExtent+spriteWidth)/2) {
            spriteRenderer.enabled = false;
        }
        if(transform.position.x < (horzExtent+spriteWidth)/2) {
            if(!showing) {
                spriteRenderer.enabled = true;
            }
        }
	}
}
