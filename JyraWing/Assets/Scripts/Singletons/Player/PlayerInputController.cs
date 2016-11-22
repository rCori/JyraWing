using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour {

	private string fireButtonString, autoFireButtonString, shieldButtonString, backButtonString, upButtonString, downButtonString, leftButtonString, rightButtonString, startButtonString;
	private string upDownAxisString, leftRightAxisString;

	public delegate void ButtonEvent(bool down);
	public delegate void AxisEvent (float value);

	public static event ButtonEvent AutoFireButton, ShieldButton, UpButton, DownButton, LeftButton, RightButton, StartButton;
	public static event AxisEvent LeftRightEvent, UpDownEvent;

	private float prevLeftRight, prevUpDown;

    private KeyCode AutoFireButtonKeyCode, ShieldButtonKeyCode, StartButtonKeyCode;

	// Use this for initialization
	void Start () {
		prevLeftRight = 0f;
		prevUpDown = 0f;
		initDefaultControls ();

	}

	void Update() {
		//ButtonUpdate(fireButtonString, FireButton);
		//ButtonUpdate(autoFireButtonString, AutoFireButton);
		//ButtonUpdate (shieldButtonString, ShieldButton);
		//ButtonUpdate(backButtonString, BackButton);
		ButtonUpdate(upButtonString, UpButton);
		ButtonUpdate(downButtonString, DownButton);
		ButtonUpdate(leftButtonString, LeftButton);
		ButtonUpdate(rightButtonString, RightButton);
		ButtonUpdate (startButtonString, StartButton);

        KeycodeButtonUpdate(AutoFireButtonKeyCode, AutoFireButton);
        KeycodeButtonUpdate(ShieldButtonKeyCode, ShieldButton);
        KeycodeButtonUpdate(StartButtonKeyCode, StartButton);

		prevUpDown = AxisUpdate(upDownAxisString, UpDownEvent, prevUpDown);
		prevLeftRight = AxisUpdate (leftRightAxisString, LeftRightEvent, prevLeftRight);
	}

	private void initDefaultControls() {
		fireButtonString = "Fire";
		autoFireButtonString = "Auto Fire";
		shieldButtonString = "Shield";
		backButtonString = "Back";
		upButtonString = "Up";
		downButtonString = "Down";
		leftButtonString = "Left";
		rightButtonString = "Right";
		upDownAxisString = "Vertical";
		leftRightAxisString = "Horizontal";
		startButtonString = "Pause";
        AutoFireButtonKeyCode = KeyCode.X;
        ShieldButtonKeyCode = KeyCode.Z;
        StartButtonKeyCode = KeyCode.Return;
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

    private void KeycodeButtonUpdate(KeyCode buttonKeyCode, ButtonEvent buttonEvent) {
        //Up Button Event
		if (buttonEvent != null) {
			if (Input.GetKeyDown (buttonKeyCode)) {
				buttonEvent (true);
			}
			if (Input.GetKeyUp (buttonKeyCode)) {
				buttonEvent (false);
			}
		}
    }

	private float AxisUpdate(string axisString, AxisEvent axisEvent, float prevValue) {
		axisEvent (Input.GetAxisRaw (axisString));
		return Input.GetAxisRaw (axisString);
	}

	public static void RemoveAllEvents() {
		//RemoveButtonEvents (FireButton);
		RemoveButtonEvents (AutoFireButton);
		RemoveButtonEvents (ShieldButton);
		//RemoveButtonEvents (BackButton);
		RemoveButtonEvents (UpButton);
		RemoveButtonEvents (DownButton);
		RemoveButtonEvents (LeftButton);
		RemoveButtonEvents (RightButton);
		RemoveButtonEvents (StartButton);
		RemoveAxisEvents (LeftRightEvent);
		RemoveAxisEvents (UpDownEvent);
	}

	private static void RemoveAxisEvents(AxisEvent axisEvent) {
		axisEvent = null;
	}

	private static void RemoveButtonEvents(ButtonEvent buttonEvent) {
		buttonEvent = null;
	}
}
