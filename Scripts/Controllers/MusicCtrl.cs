﻿using UnityEngine;
/// <summary>
/// Handles the Music availability, this script is child of DataCtrl.
/// </summary>
public class MusicCtrl : MonoBehaviour
{
    public static MusicCtrl instance;   // For calling public methods in this script
    [Header("Audio Source")]
    public AudioSource musicSource;     // Audio Source for Music FX

    void Start()
    {
        if (instance == null)       // If instance is null.
        {
            instance = this;        // Sets the instance to this gameObject, if its null.
        }
    }

    public void Update()
    {
        MusicCheck();
        musicSource.volume = SettingsCtrl.instance.data.musicVolume;    // Updates volumeBar on every new Update()
    }

    private void MusicCheck()   // Called on Start to Update Music availability
    {
        if (SettingsCtrl.instance.data.playMusic)   // Checks playMusic state from GameData script
        {
            if (musicSource.isPlaying)          // Checks if the song is playing
            {
                musicSource.mute = false;       // Unmutes song if it is already rollin.
            }
            else
            {
                musicSource.Play();             // Plays the song, if its first load. 
            }
        }
        else
        {
            if (musicSource.isPlaying)          // Checks if the song is playing
            {
                musicSource.mute = true;        // Plays the song, if it was muted. 
            }
        }
    }
}
