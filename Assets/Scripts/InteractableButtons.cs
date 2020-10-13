using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InteractableButtons : MonoBehaviour
{
    private Button[] buttons;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    public void OnEnable()
    {
        UpdateInteractableButtons();
    }

    //make buttons clickable or not depending on the highest level cleared
    public void UpdateInteractableButtons()
    {
        foreach (Button btn in buttons)
        {
            TextMeshProUGUI btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
            int levelNum = int.Parse(btnText.text);

            if (levelNum <= GameProgress.instance.lastLevelCleared + 1)
            {
                btn.interactable = true;
                if (levelNum <= GameProgress.instance.lastLevelCleared)
                {
                    btnText.color = new Color(0.5686f, 0.9059f, 0.0902f);
                }
                else
                {
                    btnText.color = new Color(0.8f, 0.8f, 0.8f);
                }
            }
            else
            {
                btn.interactable = false;
                btnText.color = new Color(0.8f, 0.8f, 0.8f);
            }

            //if the special achievement for the level has been completed,
            //turn the button bacjground green
            int bestScore = PlayerPrefs.GetInt("movesLevel" + Convert.ToInt32(btnText.text), 0);
            if (bestScore!=0 && bestScore <= MinimumMoves.maxMovesForAchiement[Convert.ToInt32(btnText.text) - 1])
            {
                var colors = btn.colors;
                colors.normalColor = new Color32(0x16, 0x44, 0x0D, 0xFF);
                colors.highlightedColor = new Color32(0x4E, 0x82, 0x3D, 0xFF);
                colors.selectedColor = new Color32(0x4E, 0x82, 0x3D, 0xFF);
                btn.colors = colors;
            }
            //otherways turn the button gray
            else
            {
                var colors = btn.colors;
                colors.normalColor = new Color32(0x27, 0x27, 0x26, 0xFF);
                colors.highlightedColor = new Color32(0x52, 0x51, 0x51, 0xFF);
                colors.selectedColor = new Color32(0x52, 0x51, 0x51, 0xFF);
                btn.colors = colors;
            }
        }
    }
}
