using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// code by Ajmal
/// </summary>
public class ButtonSoundPlayAnim : MonoBehaviour
{
    public void PlaySound(string sound)
    {
        AudioManager.instance.Play(sound);
    }
}
