using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour {

	private string fireButtonString, autoFireButtonString, changeSpeedButtonString, upButtonString, downButtonString, leftButtonString, rightButtonString, startButtonString;
	private string upDownAxisString, leftRightAxisString;

	public delegate void ButtonEvent(bool down);
	public delegate void AxisEvent (float value);

	public static event ButtonEvent FireButton, AutoFireButton, ChangeSpeedButton, UpButton, DownButton, LeftButton, RightButton, StartButton;
	public static event AxisEvent LeftRightEvent, UpDownEvent;

	private float prevLeftRight, prevUpDown;

	// Use this for initialization
	void Start () {
		prevLeftRight = 0f;
		prevUpDown = 0f;
		initDefaultControls ();
	}

	void Update() {
		ButtonUpdate(fireButtonString, FireButton);
		ButtonUpdate(autoFireButtonString, AutoFireButton);
		ButtonUpdate(changeSpeedButtonString, ChangeSpeedButton);
		ButtonUpdate(upButtonString, UpButton);
		ButtonUpdate(downButtonString, DownButton);
		ButtonUpdate(leftButtonString, LeftButton);
		ButtonUpdate(rightButtonString, RightButton);

		prevUpDown = AxisUpdate(upDownAxisString, UpDownEvent, prevUpDown);
		prevLeftRight = AxisUpdate (leftRightAxisString, LeftRightEvent, prevLeftRight);
	}

	private void initDefaultControls() {
		fireButtonString = "Fire";
		autoFireButtonString = "Auto Fire";
		changeSpeedButtonString = "Toggle Speed";
		upButtonString = "Up";
		downButtonString = "Down";
		leftButtonString = "Left";
		rightButtonString = "Right";
		upDownAxisString = "Vertical";
		leftRightAxisString = "Horizontal";
		startButtonString = "Start";
	}

	private void ButtonUpdate(string butttonString, ButtonEvent buttonEvent) {
		//Up Button Event
		if (buttonEvent != null) {
			if (Input.GetButtonDown (butttonString)) {
				buttonEvent (true);
			}
			if (Input.GetButtonUp (butttonString)) {
				buttonEvent (false);
			}
		}
	}

	private float AxisUpdate(string axisString, AxisEvent axisEvent, float prevValue) {
		if (Input.GetAxisRaw (axisString) != 0 && prevValue == 0) {
			if (axisEvent != null) {
				Debug.Log ("Axis " + Input.GetAxisRaw (axisString));
				axisEvent (Input.GetAxisRaw (axisString));
			}
		} else if(Input.GetAxisRaw (axisString) == 0 && prevValue != 0) {
			if (axisEvent != null) {
				Debug.Log ("Axis " + Input.GetAxisRaw (axisString));
				axisEvent (Input.GetAxisRaw (axisString));
			}
		}
		return Input.GetAxisRaw (axisString);
	}
}
