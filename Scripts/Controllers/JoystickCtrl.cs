﻿using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Handles the User Controls in Game. This script is in OptionsMenu.
/// </summary>
public class JoystickCtrl : MonoBehaviour
{
    public static JoystickCtrl instance;        // Instance for accessing from other scripts.
    public bool joystickActive, buttonActive;   // Manipulate Joystick and Buttons controlls.
    public Button JoystickBTN, ButtonsBTN;      // Joysticks and Buttons button.
    public Sprite isChecked, isUnchecked;       // Sprites for checked and unchecked condition.
    [Header("Panels")]
    public GameObject joyPanel, btnPanel;       // Joystick and Buttons panels.

	void Start ()
    {
        if(instance == null)    // Checks if the instance in null.
        {
            instance = this;    // Creates the instance of this script.
        }
        CheckJoystick();        // Refreshes data from DB.
	}
	
	public void ToggleJoystick()    // Called when Joystick Button is pressed.
    {
        if (buttonActive)
        {
            ButtonsBTN.GetComponent<Image>().sprite = isUnchecked;  // Shwos Unchecked sprite on ButtonsBTN.
            buttonActive = false;                                   // Changes condition to false, to prvent new calls.
            btnPanel.SetActive(false);                              // Hides btnPanel.
            JoystickBTN.GetComponent<Image>().sprite = isChecked;   // Shows Checked sprite on JoystickBTN.
            joystickActive = true;                                  // Changes condition to true, to allow ToggleButtons() manipulation.
            joyPanel.SetActive(true);                               // Shows joyPanel.
            SettingsCtrl.instance.data.isJoystick = true;           // Saves the new value of isJoystick.
        }
    }

    public void ToggleButtons()     // Called when Buttons Button is pressed.
    {
        if (joystickActive)
        {
            JoystickBTN.GetComponent<Image>().sprite = isUnchecked; // Shows Unchecked sprite on JoystickBTN.
            joystickActive = false;                                 // Changes condition to false, to prvent new calls.
            joyPanel.SetActive(false);                              // Hides joyPanel.
            ButtonsBTN.GetComponent<Image>().sprite = isChecked;    // Shows Checked sprite on ButtonsBTN.
            buttonActive = true;                                    // Changes condition to true, to allow ToggleJoystick() manipulation.
            btnPanel.SetActive(true);                               // Shows btnPanel.
            SettingsCtrl.instance.data.isJoystick = false;          // Saves the new value of isJoystick.
        }
    }

    public void CheckJoystick()     // Called on every Start to get the most recent value of isJoystick.
    {
        if (SettingsCtrl.instance.data.isJoystick)
        {
            JoystickBTN.GetComponent<Image>().sprite = isChecked;   // Shows Checked sprite on JoystickBTN.
            joystickActive = true;                                  // Sets the joystickActive to true.
            joyPanel.SetActive(true);                               // Shows the joyPanel.
            ButtonsBTN.GetComponent<Image>().sprite = isUnchecked;  // Shows Unchecked sprite on ButtonsBTN.
            buttonActive = false;                                   // Sets the buttonActive to false.
            btnPanel.SetActive(false);                              // Hides the btnPanel.
        }
        else
        {
            JoystickBTN.GetComponent<Image>().sprite = isUnchecked; // Shows Unchecked sprite on JoystickBTN.
            joystickActive = false;                                 // Sets the joystickActive to false.
            joyPanel.SetActive(false);                              // Hides the joyPanel.
            ButtonsBTN.GetComponent<Image>().sprite = isChecked;    // Shows Checked sprite on ButtonsBTN.
            buttonActive = true;                                    // Sets the buttonActive to true.
            btnPanel.SetActive(true);                               // Shows the btnPanel.
        }
    }
}
