﻿using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Handles the Audio in the game, this script is in Settings Scene
/// </summary>
public class AudioCtrl : MonoBehaviour
{
    public static AudioCtrl instance;       // For calling public methods in this script


    [Header("In-game Sound & Music")]
    [Tooltip("SoundOn & MusicOn is used to toggle their availability in the Inspector")]
    public bool soundOn, musicOn;           // Checks if the Sound and Music are enabled 
    [Header("Audio Source & Slider")]
    [SerializeField]
    public Slider musicVolumeBar, soundVolumeBar;   // Volume Slider for Music.
    [Header("Music setup")]
    public Button Music_Button;             // Toggles Music ON and OFF 
    public Sprite _musicOff, _musicOn;      // Sprites used to display button Images
    [Header("Sound setup")]
    public Button Sound_Button;             // Toggles Sound ON and OFF
    public Sprite _soundOff, _soundOn;      // Sprites used to display button Images

    void Start()
    {
        if (instance == null)       // If instance is null.
        {
            instance = this;        // Sets the instance to this gameObject, if its null.
        }

        musicVolumeBar.value = SettingsCtrl.instance.data.musicVolume;   // Updates volumeBar on every new Start()
        soundVolumeBar.value = SettingsCtrl.instance.data.soundVolume;   // Updates volumeBar on every new Start()
        MusicButtonCheck();               // Checks Music availability
        SoundButtonCheck();               // Checks Sound availability
    }
    #region Main Settings For Sound and Music
    public void ToggleMusic()   // Called when Music_Button is pressed
    {
        if (SettingsCtrl.instance.data.playMusic)   // Checks playMusic state from GameData script
        {
            musicOn = false;    // Toggles music OFF
            Music_Button.GetComponent<Image>().sprite = _musicOff;  // Displays OFF Image
            SettingsCtrl.instance.data.playMusic = false;               // Changes state from playMusic from GD script
        }
        else
        {
            musicOn = true;     // Toggles music ON
            Music_Button.GetComponent<Image>().sprite = _musicOn;   // Displays ON Image
            SettingsCtrl.instance.data.playMusic = true;                // Changes state from playMusic from GD script
        }
    }

    public void ToggleSound()   // Called when Sound_Button is pressed.
    {
        if (SettingsCtrl.instance.data.playSound)   // Checks playSound state from GameData script
        {
            soundOn = false;    // Toggles sound OFF
            Sound_Button.GetComponent<Image>().sprite = _soundOff;  // Updates Buttons Sprite
            SettingsCtrl.instance.data.playSound = false;               // Changes state from playSound from GD script
        }
        else
        {
            soundOn = true;     // Toggles music ON
            Sound_Button.GetComponent<Image>().sprite = _soundOn;   // Updates Buttons Sprite
            SettingsCtrl.instance.data.playSound = true;                // Changes state from playSound from GD script
        }
    }

    private void MusicButtonCheck()   // Called on Start to Update Music availability
    {
        if (SettingsCtrl.instance.data.playMusic)   // Checks playMusic state from SettingsData script
        {
            musicOn = true;     // Toggles music ON based on playMusic's state 
            Music_Button.GetComponent<Image>().sprite = _musicOn;   // Updates Buttons Sprite
        }
        else
        {
            musicOn = false;    // Toggles music OFF based on playMusic's state
            Music_Button.GetComponent<Image>().sprite = _musicOff;  // Updates Buttons Sprite
        }
    }

    private void SoundButtonCheck()   // Called on Start to Update Sound availability
    {
        if (SettingsCtrl.instance.data.playSound)   // Checks playSound state from SettingsData script
        {
            soundOn = true;     // Toggles sound OFF
            Sound_Button.GetComponent<Image>().sprite = _soundOn;   // Updates Buttons Sprite
        }
        else
        {
            soundOn = false;    // Toggles sound OFF
            Sound_Button.GetComponent<Image>().sprite = _soundOff;  // Updates Buttons Sprite
        }
    }

    public void MusicVolumeBar(float volume)     // Called when Sliders value is being changed by user
    {
        SettingsCtrl.instance.data.musicVolume = volume; // Sets the musicVolume to current volume's value
    }

    public void SoundVolumeBar(float volume)     // Called when Sliders value is being changed by user
    {
        SettingsCtrl.instance.data.soundVolume = volume; // Sets the soundVolume to current volume's value
    }
    #endregion
}