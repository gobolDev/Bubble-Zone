﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// Handles the Level Complete AI, this is attached at Panel_LevelComplete.
/// </summary>
public class LevelCompleteCtrl : MonoBehaviour
{
    [Header("Required Components")]
    public Button _nextLvl;                 // Button for next level.
    public Sprite _goldenStar;              // Sprite of Star.
    public Image _star1, _star2, _star3;    // ImgSprite of first, second and thired star.
    public Text _score;                     // Text that is being displayed at the end of the level
    [Header("Level Information")]
    public int levelNumber;         // Current level.
    [Tooltip("Displays the Score made through the Level, default value is 0.")]
    public int Score;               // Score result.
    [Header("Information Required for next Level")]
    public int ScoreForThreeStars;  // Score required for 3 stars.
    public int ScoreForTwoStars;    // Score required for 2 stars.
    public int ScoreForOneStar;     // Score required for 1 star.
    public int ScoreForNextLevel;   // Score required for next score.
    [Header("Time Delays")]
    public float AnimStartDelay;    // Time delay before first star is spawned.
    public float AnimDelay;         // Time delay between current and next star spawned < 0.7f >

    bool showTwoStarts, showThreeStars; // This checks how much stars to show.

	void Start ()
    {
        Score = GameCtrl.instance.GetScore();   // Collects the available score result.
        _score.text = Score.ToString();         // Displays Score to screen.

        if(Score >= ScoreForThreeStars)                                 // If Score is >= Score for 3
        {
            showThreeStars = true;                                  // Sets this bool to true
            GameCtrl.instance.SetStarsAwarded(levelNumber, 3);      // Saves in GameCtrl number of stars
            Invoke("ShowGoldenStars", AnimStartDelay);              // Invokes new method with some delay
        }
        if(Score >= ScoreForTwoStars && Score < ScoreForThreeStars)     // If Score is >= Score for 2 < 3
        {
            showTwoStarts = true;                                   // Sets this bool to true
            GameCtrl.instance.SetStarsAwarded(levelNumber, 2);      // Saves in GameCtrl number of stars
            Invoke("ShowGoldenStars", AnimStartDelay);              // Invokes new method with some delay
        }
        if(Score >= ScoreForOneStar && Score < ScoreForTwoStars)        // If Score is >= Score for 1 < 2
        {
            GameCtrl.instance.SetStarsAwarded(levelNumber, 1);      // Saves in GameCtrl number of stars
            Invoke("ShowGoldenStars", AnimStartDelay);              // Invokes new method with some delay
        }
        if(Score >= ScoreForNextLevel && Score < ScoreForOneStar)
        {
            Invoke("CheckLevelStatus", 2);
        }
	}

    void ShowGoldenStars()      // Called when Score reached required score for Star Ranking. 
    {
        StartCoroutine("HandlesFirstStarAnim", _star1); // Calls Coroutine when score for 1 Star is reached. 
    }

    IEnumerator HandlesFirstStarAnim(Image starImg) // Handles 1st. Star with DoAnim.
    {
        DoAnim(starImg);    // The magic displayed when assigning 1st. Star.

        yield return new WaitForSeconds(AnimDelay); // Time Delay before the next code execution.

        //poziva se ako igrac ima rezultat za vise zvezda
        if(showTwoStarts || showThreeStars) // Checks the conditions of 2nd. Or 3ed. Star.
        {
            StartCoroutine("HandlesSecondStarAnim", _star2); // Calls Coroutine if the condition from above is met.
        }
        else
        {
            Invoke("CheckLevelStatus", 1.2f);   // Calls Method if the condition from above is not met.
        }
    }

    IEnumerator HandlesSecondStarAnim(Image starImg) // Handles 2nd. Star with DoAnim.
    {
        DoAnim(starImg);    // The magic displayed when assigning 2nd. Star.

        yield return new WaitForSeconds(AnimDelay); // Time Delay before the next code execution.

        showTwoStarts = false;                      // Sets bool for 2nd. Star to false.

        if (showThreeStars)     // Checks the conditions of 3ed. Star.
        {
            StartCoroutine("HandlesThirdStarAnim", _star3); // Calls Coroutine if the condition from above is met.
        }
        else
        {
            Invoke("CheckLevelStatus", 1.2f);               // Calls Method if the condition from above is not met.
        }
    }

    IEnumerator HandlesThirdStarAnim(Image starImg) // Handles 3ed. star with DoAnim.
    {
        DoAnim(starImg);                                // The magic displayed when assigning 3ed. Star.

        yield return new WaitForSeconds(AnimDelay);     // Time Delay before the next code execution.

        showThreeStars = false;                         // Sets bool for 3nd. Star to false.
        Invoke("CheckLevelStatus", 1.2f);               // Calls Method if the condition from above is not met.
    }

    void DoAnim(Image starImg)  // The Magic of DG.Tweening; Library
    {
        starImg.rectTransform.sizeDelta = new Vector2(350f, 350f);  // Changes the Image size.
        starImg.sprite = _goldenStar;                               // Displayes the awardedStar.
        RectTransform temp = starImg.rectTransform;                 // Creates temp. value for holding size value.
        temp.DOSizeDelta(new Vector2(200f, 200f), 0.7f, false);     // Returns the size values to original size. !-[DoTween]-!

        // Add code here if there is any SoundFX to play when stars are awarded!
    }

    void CheckLevelStatus()     // Called after Star Ranking is finished, checks availability of next Level.
    {
        // -------------------------- Unlocks a next Level if a certan score is achieved ----------------

        if (Score >= ScoreForNextLevel) // Checks availability of next Level.
        {
            _nextLvl.interactable = true;   // If condition is met, Button becomes interactable.
            Debug.Log("Next level is Unlocked!");
            // Add code here if there is any SoundFX to play when Button turns Interactable!

            GameCtrl.instance.UnlockLevel(levelNumber + 1);     // Calls a method that unlocks next Level.
            GameCtrl.instance.SetScoreMade(levelNumber, Score); // Saves a level score.
            DataCtrl.instance.SaveData(GameCtrl.instance.data); // This should save data when is Interactable.
        }
        else
        {
            _nextLvl.interactable = false;  // If condition is not met, Button stays locked.
            Debug.Log("Next level is NOT Unlocked!");
        }
        //-------------------------------------------------------------------------------------------------
    }
}
