using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// code by Ajmal
/// </summary>
public class ButtonSoundPlay : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public string AudioOnPress;
    public string AudioOnHover = "ButtonHover2";
    public bool DisableAudioHover = false;
    public bool ButtonPress2 = false;

    void Start() {

        if (ButtonPress2)
        {
            AudioOnPress = "LevelSelect";
        }
        else {
            AudioOnPress = "ButtonPress2";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!DisableAudioHover)
            AudioManager.instance.Play(AudioOnHover);
    }

   
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.instance.Play(AudioOnPress);
    }

    public void PlaySound(string soundname)
    {
        AudioManager.instance.Play(soundname);
    }

}