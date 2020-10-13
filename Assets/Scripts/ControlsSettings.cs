using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsSettings : MonoBehaviour
{
    public enum ControlsType
    {
        WASD, WEAF, Keypad
    }
    public static ControlsSettings instance;
    public static int controlsSetting { get; private set; }

    private void Start()
    {
        if (instance == null)
            controlsSetting = PlayerPrefs.GetInt("controlType", 0);
        instance = this;
    }

    public void SetControlSetting(int index)
    {//save the index of the control type chosen
        index = Mathf.Clamp(index, 0, 2);
        controlsSetting = index;
        PlayerPrefs.SetInt("controlType", index);
    }

    //enable input bindings depeneding on control scheme chosen
    public static void MaskInputBindings(ControlsManager.ControlsActions inputAction)
    {
        switch (controlsSetting)
        {
            case 0:
                inputAction.MoveWASD.Enable();
                inputAction.MoveAWEF.Disable();
                inputAction.MoveKeypad.Disable();
                break;
            case 1:
                inputAction.MoveWASD.Disable();
                inputAction.MoveAWEF.Enable();
                inputAction.MoveKeypad.Disable();
                break;
            case 2:
                inputAction.MoveWASD.Disable();
                inputAction.MoveAWEF.Disable();
                inputAction.MoveKeypad.Enable();
                break;
        }
    }
}
