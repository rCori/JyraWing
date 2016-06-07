using UnityEngine;
using System.Collections;

public class PlayerInputController {

	float autoFireTimer;
	const float AUTOFIRETIMELIMIT = 1/3f;
	bool autoFireState;

	bool disableControls;
	bool disableShield;

	int horizontalVel;
	int verticalVel;

	// Use this for initialization
	public PlayerInputController () {
		autoFireTimer = 0.0f;
		autoFireState = false;
		disableControls = false;
		horizontalVel = 0;
		verticalVel = 0;
	}
	
	// Update is called once per frame
	public void PlayerInputUpdate() {
		//update the auto fire button state
		autoFireState = autoFireUpdate ();
		updateMovement ();
	}

	/// <summary>
	/// update the state of the player using the auto fire button
	/// </summary>
	/// <returns><c>true</c>, If a bullet should be fired by the player by auto firing <c>false</c> otherwise.</returns>
	private bool autoFireUpdate(){
		if (Input.GetButton("Auto Fire")) {
			autoFireTimer -= Time.deltaTime;
			//If the autoFire has reached it's timer
			if(autoFireTimer <= 0.0f){
				//Reset the time limit and return that the player should fire. 
				autoFireTimer = AUTOFIRETIMELIMIT;
				return true;
			}
		}
		//If the button was released then reset the timer but do not shoot.
		if (Input.GetButtonUp ("Auto Fire")) {
			autoFireTimer = 0.0f;
		}
		return false;
	}

	///<summary>
	/// Poll the state of the auto fire function
	/// </summary>
	public bool GetAutoFire(){
		if (!disableControls) {
			return autoFireState;
		} else {
			return false;
		}
	}


	/// <summary>
	/// Simple access to wrap around the fire button. 
	/// </summary>
	/// <returns><c>true</c>, if fire button was gotten, <c>false</c> otherwise.</returns>
	public bool GetFireButton(){
		if (!disableControls) {
			return Input.GetButtonDown ("Fire");
		} else {
			return false;
		}

	}

	public bool GetToggleSpeed(){
		if (!disableControls) {
			return Input.GetButtonDown ("Toggle Speed");
		} else {
			return false;
		}
	}


	public bool GetShieldButton(){
		if (!disableShield) {
			bool retVal = Input.GetButton ("Shield");
			return retVal;
		} else {
			return false;
		}
	}

	public void DisableControls(bool i_disable){
		disableControls = i_disable;
	}

	public void DisableShield(bool i_disable){
		disableShield = i_disable;
	}

	public bool GetDisabledControls(){
		return disableControls;
	}

	public void updateMovement(){
		if (!disableControls) {
			//Update position
			float horiz = Input.GetAxis ("Horizontal");
			float vert = Input.GetAxis ("Vertical");
			if (vert < 0.0f) {
				verticalVel = -1;

			} else if (vert > 0.0f) {
				verticalVel = 1;
			} else {
				verticalVel = 0;
			}

			if (horiz < 0.0f) {
				horizontalVel = -1;
			} else if (horiz > 0.0f) {
				horizontalVel = 1;
			} else {
				horizontalVel = 0;
			}
		}
	}

	public int GetHorizontalMovement(){
		if (!disableControls) {
			return horizontalVel;
		} else {
			return 0;
		}
	}

	public int GetVerticalMovement(){
		if (!disableControls) {
			return verticalVel;
		} else {
			return 0;
		}
	}
}
