//#define DEBUGGRIDMENU

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridMenu : MonoBehaviour {

    public Vector2[,] menuLocations; 
    protected AudioSource beep;
	protected AudioClip confirm;
	protected AudioClip move;
    protected SoundEffectPlayer sfxPlayer;

    protected int curSelectX, curSelectY;
    protected bool selectDownX, selectDownY;

    public void InitMenu()
	{
		sfxPlayer = GameObject.Find ("SoundEffectPlayer").GetComponent<SoundEffectPlayer>();
		confirm = Resources.Load ("Audio/SFX/Confirm") as AudioClip;
		move = Resources.Load ("Audio/SFX/Cursor") as AudioClip;
		curSelectX = 0;
        curSelectY = 0;
		beep = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void MenuScroll () {

        float vertAxis, horizAxis;

        vertAxis = AxisInput.Instance().GetVertical();
        horizAxis = AxisInput.Instance().GetHorizontal();

        if(horizAxis > 0 && menuLocations.GetLength(0) -1  > curSelectX && !selectDownX) {
            curSelectX++;
            selectDownX = true;
            gameObject.transform.position = menuLocations[curSelectX, curSelectY];
#if DEBUGGRIDMENU
            Debug.LogError("<color=#377533>X selection++ </color>");
            Debug.LogError("<color=#1E6A6B>(" + curSelectX + ", " + curSelectY + ") </color>");
#endif
        } else if(horizAxis < 0 && curSelectX > 0 && !selectDownX) {
            curSelectX--;
            selectDownX = true;
            gameObject.transform.position = menuLocations[curSelectX, curSelectY];
#if DEBUGGRIDMENU
            Debug.LogError("<color=#377533>X selection-- </color>");
            Debug.LogError("<color=#1E6A6B>(" + curSelectX + ", " + curSelectY + ") </color>");
#endif
        } else if(horizAxis == 0 && selectDownX) {
            selectDownX = false;
#if DEBUGGRIDMENU
            Debug.LogError("<color=#377533>X selection up </color>");
            Debug.LogError("<color=#1E6A6B>(" + curSelectX + ", " + curSelectY + ") </color>");
#endif
        }

        if(vertAxis < 0 && menuLocations.GetLength(1) -1  > curSelectY && !selectDownY) {
            curSelectY++;
            selectDownY = true;
            gameObject.transform.position = menuLocations[curSelectX, curSelectY];
#if DEBUGGRIDMENU
            Debug.LogError("<color=#6D3375>Y selection++ </color>");
            Debug.LogError("<color=#1E6A6B>(" + curSelectX + ", " + curSelectY + ") </color>");
#endif
        } else if(vertAxis > 0 && curSelectY > 0 && !selectDownY) {
            curSelectY--;
            selectDownY = true;
            gameObject.transform.position = menuLocations[curSelectX, curSelectY];
#if DEBUGGRIDMENU
            Debug.LogError("<color=#6D3375>Y selection-- </color>");
            Debug.LogError("<color=#1E6A6B>(" + curSelectX + ", " + curSelectY + ") </color>");
#endif
        } else if(vertAxis == 0 && selectDownY) {
            selectDownY = false;
#if DEBUGGRIDMENU
            Debug.LogError("<color=#6D3375>Y selection up </color>");
            Debug.LogError("<color=#1E6A6B>(" + curSelectX + ", " + curSelectY + ") </color>");
#endif
        }

	}
}
