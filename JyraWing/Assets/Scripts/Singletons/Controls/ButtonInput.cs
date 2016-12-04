using UnityEngine;
using System.Collections;

public class ButtonInput {

    private static ButtonInput _ref;

    private KeyCode KeyboardStartKeyCode;
    private KeyCode GamepadStartKeyCode;

    private ButtonInput() {
        KeyboardStartKeyCode = KeyCode.Return;
        switch(AxisInput.Instance().GetControllerType()) {
        case AxisInput.ControllerType.PS4:
            GamepadStartKeyCode = KeyCode.Joystick1Button9;
            break;
        case AxisInput.ControllerType.XBOX:
            GamepadStartKeyCode = KeyCode.Joystick1Button7;
            break;
        case AxisInput.ControllerType.NONE:
            GamepadStartKeyCode = 0;
            break;
        }
    }

    public KeyCode GetKeyboardStartButton() {
        return KeyboardStartKeyCode;
    }

    public KeyCode GetGamepadStartButton() {
        return GamepadStartKeyCode;
    }

    public static ButtonInput Instance() {
        if(_ref == null) {
            _ref = new ButtonInput();
        }
        return _ref;
    }

    //I might think of a better way to do this other than just this than just three functions per button

    //Fire button
    public bool FireButtonDown() {
        if(Input.GetKeyDown(SaveData.Instance.AutoFireButtonKeyCode) ||
            Input.GetKeyDown(SaveData.Instance.AutoFireGamepadButtonKeyCode)) {
            return true;
        }
        return false;
    }

    public bool FireButtonUp() {
        if(Input.GetKeyUp(SaveData.Instance.AutoFireButtonKeyCode) ||
            Input.GetKeyUp(SaveData.Instance.AutoFireGamepadButtonKeyCode)) {
            return true;
        }
        return false;
    }

    public bool FireButton() {
        if(Input.GetKey(SaveData.Instance.AutoFireButtonKeyCode) ||
            Input.GetKey(SaveData.Instance.AutoFireGamepadButtonKeyCode)) {
            return true;
        }
        return false;
    }



    //Shield button
    public bool ShieldButtonDown() {
        if(Input.GetKeyDown(SaveData.Instance.ShieldButtonKeyCode) ||
            Input.GetKeyDown(SaveData.Instance.ShieldGamepadButtonKeyCode)) {
            return true;
        }
        return false;
    }

    public bool ShieldButtonUp() {
        if(Input.GetKeyUp(SaveData.Instance.ShieldButtonKeyCode) ||
            Input.GetKeyUp(SaveData.Instance.ShieldGamepadButtonKeyCode)) {
            return true;
        }
        return false;
    }

    public bool ShieldButton() {
        if(Input.GetKey(SaveData.Instance.ShieldButtonKeyCode) ||
            Input.GetKey(SaveData.Instance.AutoFireGamepadButtonKeyCode)) {
            return true;
        }
        return false;
    }


    //Start button
    public bool StartButtonDown() {
        if(Input.GetKeyDown(KeyboardStartKeyCode) ||
            Input.GetKeyDown(GamepadStartKeyCode)) {
            return true;
        }
        return false;
    }

    public bool StartButtonUp() {
        if(Input.GetKeyUp(KeyboardStartKeyCode) ||
            Input.GetKeyUp(GamepadStartKeyCode)) {
            return true;
        }
        return false;
    }

    public bool StartButton() {
        if(Input.GetKey(KeyboardStartKeyCode) ||
            Input.GetKey(GamepadStartKeyCode)) {
            return true;
        }
        return false;
    }

}
