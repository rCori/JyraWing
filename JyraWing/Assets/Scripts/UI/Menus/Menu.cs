using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {


	protected int curSelect;
	protected float selectTimer;
	protected float selectTimeLimit;
	protected AudioSource beep;
	protected AudioClip confirm;
	protected AudioClip move;
	protected SoundEffectPlayer sfxPlayer;

	public int numberOfItems;
	public List<Vector2> menuLocations; 
	public bool isVertical;

	public void InitMenu()
	{
		sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
		confirm = Resources.Load ("Audio/SFX/Confirm") as AudioClip;
		move = Resources.Load ("Audio/SFX/Cursor") as AudioClip;
		curSelect = 0;
		selectTimer = 0f;
		selectTimeLimit = 0.15f;
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

		//Move the selector down(veritcal) or right(horizontal)
		if (((isVertical && axis < 0)||(!isVertical && axis > 0)) && (selectTimer > selectTimeLimit) && curSelect != numberOfItems-1) {
			curSelect++;
			transform.position = menuLocations[curSelect];
			selectTimer = 0f;
			PlayMove ();
		}

		//Move the selector up(veritcal) or left(horizontal)
		//move selection up one
		if (((isVertical && axis > 0)||(!isVertical && axis < 0)) && (selectTimer > selectTimeLimit) && curSelect != 0) {
			curSelect--;
			transform.position = menuLocations[curSelect];
			selectTimer = 0f;
			PlayMove ();

		}

	}

	protected void PlayConfirm() {
		sfxPlayer.PlayClip (confirm);
	}

	protected void PlayMove() {
		sfxPlayer.PlayClip (move);
	}
}
