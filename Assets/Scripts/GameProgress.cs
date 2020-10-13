using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    public int lastLevelCleared { get; private set; } //highest level cleared
    public static GameProgress instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance==null)
        {
            lastLevelCleared = PlayerPrefs.GetInt("LastLevelCleared", 0);
        }
        else
        {
            lastLevelCleared = instance.lastLevelCleared;
        }
        instance = this;
    }

    public void UpdateGameProgression(int level)
    {
        if (level > lastLevelCleared)
        {
            lastLevelCleared = level;
            PlayerPrefs.SetInt("LastLevelCleared", level);
        }
    }

    public void ClearAllProgress()
    {
        PlayerPrefs.SetInt("LastLevelCleared", 0);
        lastLevelCleared = 0;
        for (int i=1; i< SceneManager.sceneCountInBuildSettings-1; i++)
        {
            PlayerPrefs.SetInt("movesLevel" + i, 0);
        }
        PlayerPrefs.SetInt("Achievements", 0);
        SceneManager.LoadScene(0);
    }
}
