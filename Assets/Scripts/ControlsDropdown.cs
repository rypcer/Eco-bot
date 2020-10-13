using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlsDropdown : MonoBehaviour
{
    TMP_Dropdown dropdown;
    private void Start()
    {
        dropdown = gameObject.GetComponent<TMP_Dropdown>();
        dropdown.value = ControlsSettings.controlsSetting;
    }
}
