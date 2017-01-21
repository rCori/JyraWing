using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {


	protected int curSelect;
    protected bool directionUp;
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
        directionUp = true;
		beep = gameObject.GetComponent<AudioSource> ();
	}


	public void MenuScroll(){

		//move selection down one
		float axis;
		if(isVertical){
            axis = AxisInput.Instance().GetVertical();
		}
		else{
            axis = AxisInput.Instance().GetHorizontal();
		}

		//Move the selector down(vertical) or right(horizontal)
		if (((isVertical && axis < 0)||(!isVertical && axis > 0)) && directionUp && curSelect != numberOfItems-1) {
			curSelect++;
			transform.position = menuLocations[curSelect];
            directionUp = false;
			PlayMove ();
		}

		//Move the selector up(veritcal) or left(horizontal)
		//move selection up one
		if (((isVertical && axis > 0)||(!isVertical && axis < 0)) && directionUp && curSelect != 0) {
			curSelect--;
			transform.position = menuLocations[curSelect];
			directionUp = false;
			PlayMove ();
		}

        if(axis == 0 && !directionUp) {
            directionUp = true;
        }

	}

	protected void PlayConfirm() {
		sfxPlayer.PlayClip (confirm);
	}

	protected void PlayMove() {
		sfxPlayer.PlayClip (move);
	}
}
