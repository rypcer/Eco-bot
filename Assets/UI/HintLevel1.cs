using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintLevel1 : MonoBehaviour
{
    private TextMeshProUGUI hint;
    // Start is called before the first frame update
    void Start()
    {//change text based on the input scheme selected in the options
        hint = gameObject.GetComponent<TextMeshProUGUI>();
        hint.text = "Collect all the plants and return to the starting point.\n\nMove using " +
            ((ControlsSettings.ControlsType)ControlsSettings.controlsSetting).ToString() +
            " or Arrow Keys. (Changeable in Options)";
    }
}
