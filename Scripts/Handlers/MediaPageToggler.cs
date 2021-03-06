﻿using UnityEngine;
using DG.Tweening;
/// <summary>
/// Handles functionality of Facebook and Play Store buttons. This script is attached to "FOLLOW US" Button.
/// </summary>
public class MediaPageToggler : MonoBehaviour
{
    public RectTransform btnFB, btnPS;          // Transforms of Facebook and Play Store button.
    private int moveFB = -270, movePS = -400;   // The desired button position.
    private int defPosY = -110;                 // Default Y positions of FB & PS button.
    private float speed = 0.5f;                 // Speed of which the buttons are being moved.
    private bool expanded;                      // Checks the state, Hides on each scene enter.

	void Start ()
    {
        expanded = false;   // Set to false on beginning.
    }
	
	public void Toggle ()   // Called when Follow8_Button was pressed.
    {
        if (!expanded)  // If expanded is NOT true when, this, button "Follow Us" was pressed.
        {
            btnFB.DOAnchorPosY(moveFB, speed, false);   // Moves FB button to desired position on Y axis, within given time.
            btnPS.DOAnchorPosY(movePS, speed, false);   // Moves PS button to desired position on Y axis, within given time.
            expanded = true;    // Sets expanded to true, disables FB & PS button to expand on next call.
        }
        else
        {
            btnFB.DOAnchorPosY(defPosY, speed, false);  // Moves FB button to default position on Y axis, within given time.
            btnPS.DOAnchorPosY(defPosY, speed, false);  // Moves PS button to default position on Y axis, within given time.
            expanded = false;   // Sets expanded to false, enables FB & PS button to expand on next call.
        }
	}
}
