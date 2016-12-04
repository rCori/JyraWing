using UnityEngine;
using System.Collections;

public class AxisInput {

    private static AxisInput _ref;

    public enum ControllerType {
        PS4,
        XBOX,
        NONE
    }

    public static AxisInput Instance() {
        if(_ref == null) {
            _ref = new AxisInput();
        }
        return _ref;
    }

    private ControllerType controllerType;

    private AxisInput() {
        if(Input.GetJoystickNames().Length == 0) {
            controllerType = ControllerType.NONE;
        } else {
            string joystickName = Input.GetJoystickNames()[0];
            if(joystickName.Length == 19) {
                Debug.Log("Controller set to PS4");
                controllerType = ControllerType.PS4;
            } else {
                Debug.Log("Controller set to XBOX");
                controllerType = ControllerType.XBOX;
            }
        }
    }

    public ControllerType GetControllerType() {
        return controllerType;
    }

    public float GetHorizontal() {
        //If the keyboard input is 0
        float keyboardHorizontal = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        if (keyboardHorizontal == 0 && controllerType != ControllerType.NONE) {
            if(controllerType == ControllerType.PS4) {
                float ps4Dpad = Mathf.Round (Input.GetAxisRaw("PS4HorizontalDpad"));
                return ps4Dpad;
            } else if (controllerType == ControllerType.XBOX) {
                float xboxDpad = Mathf.Round(Input.GetAxisRaw("XboxHorizontalDpad"));
                return xboxDpad;
            }
        }
        return keyboardHorizontal;
        
    }

    public float GetVertical() {
        //If the keyboard input is 0
        float keyboardVertical = Mathf.Round(Input.GetAxisRaw("Vertical"));
        if (keyboardVertical == 0 && controllerType != ControllerType.NONE) {
            if(controllerType == ControllerType.PS4) {
                float ps4Dpad = Mathf.Round(Input.GetAxisRaw("PS4VerticalDpad"));
                return ps4Dpad;
            } else if (controllerType == ControllerType.XBOX) {
                float xboxDpad = Mathf.Round(Input.GetAxisRaw("XboxVerticalDpad"));
                return xboxDpad;
            }
        }
        return keyboardVertical;
    }

    private float GetAbsoluteAxis(float axisVal) {
        if(axisVal < 0) {
            return -1;
        } else if(axisVal > 0) {
            return 1;
        } else {
            return 0;
        }
    }
}
