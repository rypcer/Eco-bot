using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// code by Ajmal
/// </summary>
public class MasterVolume : MonoBehaviour
{
    #region DECLARATIONS
    public GameObject VolumeSlider;
    float volume;
    #endregion

    private void Start()
    {
        volume= PlayerPrefs.GetFloat("AudioVolume", 1.0f);
        LoadVolume();
    }

    public void ChangeVolume(float masterVolume)
    {
        AudioListener.volume = masterVolume;
        PlayerPrefs.SetFloat("AudioVolume", masterVolume);
    }

    public void LoadVolume()
    {
            AudioListener.volume = volume;

            //Update Slider Handle Position
            Slider volumeslider = VolumeSlider.GetComponent<Slider>();
            volumeslider.value = volume;
    }

}
