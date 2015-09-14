using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {


	protected int curSelect;
	protected float selectTimer;
	protected float selectTimeLimit;
	protected AudioSource beep;

	public int numberOfItems;
	public List<Vector2> menuLocations; 
	public bool isVertical;
	

	public void InitMenu()
	{
		curSelect = 0;
		selectTimer = 0f;
		selectTimeLimit = 0.5f;
		beep = gameObject.GetComponent<AudioSource> ();
	}


	public void MenuScroll(){
		//Timer prevents the options from being scrolled through as fast as this update happens.
		selectTimer += Time.deltaTime;

		//move selection down one
		float axis;
		if(isVertical){
			axis = Input.GetAxis ("Vertical");
		}
		else{
			axis = Input.GetAxis ("Horizontal");
		}

		//Move menu selector up and down
		if (((isVertical && axis < 0)||(!isVertical && axis > 0)) && (selectTimer > selectTimeLimit) && curSelect != numberOfItems-1) {
			curSelect++;
			transform.position = menuLocations[curSelect];
			selectTimer = 0f;
			beep.Play();
		}
		
		//move selection up one
		if (((isVertical && axis > 0)||(!isVertical && axis < 0)) && curSelect != 0) {
			curSelect--;
			transform.position = menuLocations[curSelect];
			selectTimer = 0f;
			beep.Play();

		}

	}

}
