using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour {

	float autoFireTimer;
	const float AUTOFIRETIMELIMIT = 1/3f;
	bool autoFireState;

	bool disableControls;
	bool disableShield;

	int horizontalVel;
	int verticalVel;

	private string fireButtonString, autoFireButtonString, changeSpeedButtonString, upButtonString, downButtonString, leftButtonString, rightButtonString, startButtonString;
	private string upDownAxisString, leftRightAxisString;

	public delegate void ButtonEvent(bool down);
	public delegate void AxisEvent (float value);

	public static event ButtonEvent FireButton, AutoFireButton, ChangeSpeedButton, UpButton, DownButton, LeftButton, RightButton, StartButton;
	public static event AxisEvent LeftRightEvent, UpDownEvent;

	// Use this for initialization
	void Start () {
		autoFireTimer = 0.0f;
		autoFireState = false;
		disableControls = false;
		horizontalVel = 0;
		verticalVel = 0;
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

		AxisUpdate(upDownAxisString, UpDownEvent);
		AxisUpdate (leftRightAxisString, LeftRightEvent);
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

	private void AxisUpdate(string axisString, AxisEvent axisEvent) {
		if (Input.GetAxisRaw (axisString) != 0) {
			if (axisEvent != null) {
				axisEvent (Input.GetAxisRaw (axisString));
			}
		}
	}
}
