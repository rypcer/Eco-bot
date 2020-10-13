using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuColor : MonoBehaviour
{
    Image image;
    public Color32 color;

    void Awake()
    {
        image = gameObject.GetComponent<Image>();
        //if the special achievement has been completed for all levels,
        //turn the menu's background colour to green.
        for(int i=1; i<=16; i++)
        {
            int bestScore = PlayerPrefs.GetInt("movesLevel" + i, 0);
            if (bestScore == 0 || bestScore > MinimumMoves.maxMovesForAchiement[i - 1])
                return;
        }
            image.color = color;
    }
}
