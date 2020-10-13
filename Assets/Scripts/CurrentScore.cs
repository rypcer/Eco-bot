using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    private TextMeshProUGUI currentScoreMessage;
    public static CurrentScore instance;
    private void Awake()
    {
        instance = this;
        currentScoreMessage = gameObject.GetComponent<TextMeshProUGUI>();
        currentScoreMessage.text = "Current: 0";
    }
    public void UpdateCurrentScore(int numOfMoves)
    {
        currentScoreMessage.text = "Current: "+ numOfMoves;
    }
}
