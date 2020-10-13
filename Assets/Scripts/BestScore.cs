using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class BestScore : MonoBehaviour
{
    static public BestScore instance;
    public int bestScore { get; private set; }
    private TextMeshProUGUI bestScoreMessage;
    private void Awake()
    {
        instance = this;
        bestScore = PlayerPrefs.GetInt("movesLevel" + SceneManager.GetActiveScene().buildIndex, 0);
        bestScoreMessage= gameObject.GetComponent<TextMeshProUGUI>();
        bestScoreMessage.text = "Best: " + (bestScore==0?"-": Convert.ToString(bestScore));
    }

}
