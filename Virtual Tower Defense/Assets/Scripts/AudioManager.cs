using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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

    void Start()
    {
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Play("MenuSong");
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Play("PlaySong");
        }
        
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Error: Sound '" + name + "' was not found.");
            return;
        }
        s.source.Play();
    }

    public void Stop()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }

}
