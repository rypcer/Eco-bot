using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AchievementText : MonoBehaviour
{
    private TextMeshProUGUI achievementMessage;

    // Start is called before the first frame update
    void Start()
    {
        achievementMessage = gameObject.GetComponent<TextMeshProUGUI>();
        achievementMessage.text = "Special achievemet: complete the level in " +
            MinimumMoves.maxMovesForAchiement[SceneManager.GetActiveScene().buildIndex-1]+
            " or less moves.";
        if(BestScore.instance.bestScore!=0 && BestScore.instance.bestScore <= MinimumMoves.maxMovesForAchiement[SceneManager.GetActiveScene().buildIndex-1])
        {//if the achievement was completed, turn the text green and strikethrough
            achievementMessage.color = new Color32(0xA4, 0xED, 0x1C, 0xFF);
            achievementMessage.fontStyle = FontStyles.Strikethrough;
        }
    }
}
