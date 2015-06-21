using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private int curSelect;
	private float selectTimer;
	private float selectTimeLimit;
	private AudioSource beep;

	// Use this for initialization
	void Start () {
		curSelect = 0;
		selectTimer = 0f;
		selectTimeLimit = 0.5f;
		beep = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		selectTimer += Time.deltaTime;
		float axis = Input.GetAxis ("Vertical");
		if (axis < 0 && (selectTimer > selectTimeLimit) && curSelect != 0) {
			curSelect++;
			transform.position = new Vector2(transform.position.x, transform.position.y - 25);
			selectTimer = 0f;
			beep.Play();
		}

		if (axis > 0 && (selectTimer > selectTimeLimit) && curSelect != 0) {
			curSelect--;
			transform.position = new Vector2(transform.position.x, transform.position.y + 25);
			selectTimer = 0f;
			beep.Play();
		}

		if(Input.GetButton("Fire1")){
			if(curSelect == 0){
				beep.Play();
				Application.LoadLevel("Level_1");
			}
			/*
			else if(curSelect == 1){
				Application.LoadLevel("testScene2");
			}
			else if(curSelect == 2){
				Application.LoadLevel("testScene3");
			}
			else if(curSelect == 3){
				Application.LoadLevel("firstLevel");
			}
			*/
		}
	}
}
