using System;
/// <summary>
/// Holds Settings Data, this is called from SettingsCtrl.
/// </summary>
[Serializable]
public class SettingsData
{
    public float musicVolume;   // Saves volume for the Music.
    public float soundVolume;   // Saves volume for the Sound.
    public bool playMusic;      // Saves Music activity in game.
    public bool playSound;      // Saves Sound activity in game.
    public bool isJoystick;     // Saves the active controller. True - Joystick | False - Buttons.
}
