using UnityEngine;

/// <summary>
/// code by Ajmal
/// </summary>
public class AdditionalSounds : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("Thunder");
        AudioManager.instance.Play("Rain");
    }

    private void OnDisable()
    {
        AudioManager.instance.Stop("Thunder");
        AudioManager.instance.Stop("Rain");
    }
}
