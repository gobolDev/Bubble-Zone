using UnityEngine;
/// <summary>
/// Handles ON and OFF states in Settings Scene.
/// </summary>
public class Toggler : MonoBehaviour
{
    public void ToggleMusic()   // Called when Music Button is pressed.
    {
        AudioCtrl.instance.ToggleMusic();   // Calls ToggleMusic in AudioCtrl.
    }

    public void ToggleSound()   // Called when Sound Button is pressed.
    {
        AudioCtrl.instance.ToggleSound();   // Calls ToggleSound in AudioCtrl.
    }

    public void ToggleJoystick()    // Called when Joystick Button is pressed.
    {
        JoystickCtrl.instance.ToggleJoystick(); // Calls ToggleJoystick in JoystickCtrl.
    }

    public void ToggleButtons()     // Called when Buttons Button is pressed.
    {
        JoystickCtrl.instance.ToggleButtons();  // Calls ToggleButtons in JoystickCtrl.
    }
}
