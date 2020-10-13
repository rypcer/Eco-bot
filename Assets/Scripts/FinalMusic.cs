using UnityEngine;

/// <summary>
/// code by Ajmal
/// </summary>
public class FinalMusic : MonoBehaviour
{
    int musicOnInt;
    void Start()
    {
        musicOnInt = PlayerPrefs.GetInt("MusicMute");
        AudioManager.instance.Stop("BGM");
        AudioManager.instance.Play("Final");
    }

    private void OnDisable()
    {
        AudioManager.instance.Stop("Final");
        if(musicOnInt == 1)
            AudioManager.instance.Play("BGM");
    }
}
