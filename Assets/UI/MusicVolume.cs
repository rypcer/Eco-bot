using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// code by Ajmal
/// </summary>
public class MusicVolume : MonoBehaviour
{
    static bool musicOn;
    //public ToggleGroup MusicButtons;
    public Toggle ToggleOnButton;
    public Toggle ToggleOffButton;
    void Start()
    {
        int musicOnInt = PlayerPrefs.GetInt("MusicMute", 1);
        musicOn= (musicOnInt==1);
        if (musicOn)
        {
            ToggleOnButton.isOn = true;
            ToggleOffButton.isOn = false;
            MusicON();
        }
        else
        {
            ToggleOnButton.isOn = false;
            ToggleOffButton.isOn = true;
            MusicOFF();
        }
    }



    public void ToggleMusic(bool MusicToggle) {
        PlayerPrefs.SetInt("MusicMute", MusicToggle?1:0);
        if (MusicToggle)
            MusicON();
        else
            MusicOFF();
    }


    // Just to call BGM Music
    private void MusicON() {
        AudioManager.instance.Play("BGM");
    }
    private void MusicOFF()
    {
        AudioManager.instance.Stop("BGM");
    }

}
