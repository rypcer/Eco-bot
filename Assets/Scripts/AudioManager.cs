using System;
using UnityEngine;

/// <summary>
/// code by Ajmal
/// </summary>
public class AudioManager : MonoBehaviour
{
    #region DECLARATIONS
    public Sound[] sounds;
    public static AudioManager instance;
  
   
    #endregion

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() // Play background music at runtime
    {
        Play("BGS");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        else
            s.source.Play(); // Plays the Sound
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        else
            s.source.Stop(); // Stops the Sound
    }

   
    
            
    
}
