using UnityEngine;
/// <summary>
/// Handles the Sound availability, this script is child of DataCtrl.
/// </summary>
public class SoundCtrl : MonoBehaviour
{
    public static SoundCtrl instance;     // For calling public methods in this script
    [Header("Audio Source")]
    public AudioSource soundSource;     // Audio Source for Music FX

    public SoundData soundFX;             // For accessing AudioFX script

    void Start()
    {
        if (instance == null)       // If instance is null.
        {
            instance = this;        // Sets the instance to this gameObject, if its null.
        }
    }

    public void Update()
    {
        SoundCheck();
        soundSource.volume = SettingsCtrl.instance.data.soundVolume;    // Updates volumeBar on every new Update()
    }

    private void SoundCheck()   // Called on Start to Update Music availability
    {
        if (SettingsCtrl.instance.data.playSound)   // Checks playMusic state from GameData script
        {
            soundSource.enabled = true;         // Enables sound effects.
        }
        else
        {
            soundSource.enabled = false;        // Disables sound effects.
        }
    }
    #region Various Game Sound Effects
    public void BubbleDestroyed()    // Called when Bubble is destroyed
    {
        if (SettingsCtrl.instance.data.playSound)    // Plays sound if its enabled
        {
            soundSource.PlayOneShot(soundFX.bubblepop);     // Played from Audio Source attached to Camera 
        }
    }

    public void WeaponSound()    // Called when Bubble is destroyed
    {
        if (SettingsCtrl.instance.data.playSound)    // Plays sound if its enabled
        {
            soundSource.PlayOneShot(soundFX.bulletFired);     // Played from Audio Source attached to Camera 
        }
    }

    #endregion
}
