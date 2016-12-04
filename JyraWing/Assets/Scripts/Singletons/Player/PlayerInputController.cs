using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour {

	//private string fireButtonString, autoFireButtonString, shieldButtonString, backButtonString, startButtonString;
	private string upDownAxisString, leftRightAxisString;

	public delegate void ButtonEvent(bool down);
	public delegate void AxisEvent (float value);

    public static event ButtonEvent AutoFireButton, ShieldButton, StartButton;
	public static event AxisEvent LeftRightEvent, UpDownEvent;

	private float prevLeftRight, prevUpDown;

    public static KeyCode AutoFireButtonKeyCode, ShieldButtonKeyCode, StartButtonKeyCode;
    public static KeyCode AutoFireGamepadKeyCode, ShieldButtonGamepadKeyCode, StartButtonGamepadKeyCode;

	// Use this for initialization
	void Start () {
		prevLeftRight = 0f;
		prevUpDown = 0f;
		initDefaultControls ();

	}

	void Update() {
        //ButtonUpdate(autoFireButtonString, AutoFireButton);
        //ButtonUpdate (shieldButtonString, ShieldButton);
        //ButtonUpdate (startButtonString, StartButton);

        KeycodeButtonUpdate(AutoFireButtonKeyCode, AutoFireButton);
        KeycodeButtonUpdate(ShieldButtonKeyCode, ShieldButton);
        KeycodeButtonUpdate(StartButtonKeyCode, StartButton);

        KeycodeButtonUpdate(AutoFireGamepadKeyCode, AutoFireButton);
        KeycodeButtonUpdate(ShieldButtonGamepadKeyCode, ShieldButton);
        KeycodeButtonUpdate(StartButtonGamepadKeyCode, StartButton);

		prevUpDown = AxisUpdate(upDownAxisString, UpDownEvent, prevUpDown);
		prevLeftRight = AxisUpdate (leftRightAxisString, LeftRightEvent, prevLeftRight);
	}

	private void initDefaultControls() {
        
		upDownAxisString = "Vertical";
		leftRightAxisString = "Horizontal";
        

        AutoFireButtonKeyCode = SaveData.Instance.AutoFireButtonKeyCode;
        ShieldButtonKeyCode = SaveData.Instance.ShieldButtonKeyCode;
        StartButtonKeyCode = ButtonInput.Instance().GetKeyboardStartButton();

        AutoFireGamepadKeyCode = SaveData.Instance.AutoFireGamepadButtonKeyCode;
        ShieldButtonGamepadKeyCode = SaveData.Instance.ShieldGamepadButtonKeyCode;
        StartButtonGamepadKeyCode = ButtonInput.Instance().GetGamepadStartButton();

        Debug.Log("StartButtonKeyCode: " + StartButtonKeyCode);
        Debug.Log("StartButtonGamepadKeyCode: " + StartButtonGamepadKeyCode);
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
        switch (axisString){
        case "Horizontal":
            float horizontalAxis = AxisInput.Instance().GetHorizontal();
            axisEvent(horizontalAxis);
            return horizontalAxis;
        case "Vertical":
            float verticalAxis = AxisInput.Instance().GetVertical();
            axisEvent(verticalAxis);
            return verticalAxis;
        default:
            return 0f;
        }
	}

	public static void RemoveAllEvents() {
		RemoveButtonEvents (AutoFireButton);
		RemoveButtonEvents (ShieldButton);
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
