using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Locks/Unlocks a Level button and shows number of stars for an unlocked button.
/// </summary>
public class BtnCtrl : MonoBehaviour
{
    [Tooltip("Level Number is add by level name!")]
    public int levelNumber;         // The Level to check.
    Button currentButton;           // The button to which this script is attached to.
    Image currentImage;             // The Image of this button.
    Text currentText;               // The Text of this button.
    Transform star1, star2, star3;  // The 3 stars which are shown with this button.

    [Tooltip("Panel for AdWatcher")]
    public GameObject adWatcher;       // Handles AD panel.
    public Sprite lockedButton;        // Sprite shown when button is locked.
    public Sprite unlockedButton;      // Sprite shown when button is unlocked.
    public bool unlocked;

    void Start ()
    {
        levelNumber = int.Parse(transform.gameObject.name); // Buttons are named according to numbers which represent level numbers.

        currentButton = transform.gameObject.GetComponent<Button>();
        currentImage = currentButton.GetComponent<Image>();         // - Reference to current Button, Buttons Image and Text.
        currentText = currentButton.gameObject.transform.GetChild(0).GetComponent<Text>();

        star1 = currentButton.gameObject.transform.GetChild(1);
        star2 = currentButton.gameObject.transform.GetChild(2);     // - References to the Stars(Images) attached to this button.
        star3 = currentButton.gameObject.transform.GetChild(3);

        ButtonStatus();     // Calls a method that checks status of attached button.
    }
    /// <summary>
    /// Locks or Unlocks the certan button. Also shows the stars awarded
    /// </summary>
	void ButtonStatus ()    
    {
        unlocked = DataCtrl.instance.IsUnlocked(levelNumber);       // Variable with assigned value from DB. - isUnlocked.
        int starsAwarded = DataCtrl.instance.GetStars(levelNumber); // Local variable with assigned value from DB. - GetStars.

        if (unlocked)
        {
            currentButton.interactable = true;
            // Shows appropriate number of stars.
            if(starsAwarded == 3)
            {
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
                star3.gameObject.SetActive(true);
            }
            if (starsAwarded == 2)
            {
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
                star3.gameObject.SetActive(false);
            }
            if (starsAwarded == 1)
            {
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
            }
            if (starsAwarded == 0)
            {
                star1.gameObject.SetActive(false);
                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
            }
        }
        else
        {
            currentImage.overrideSprite = lockedButton; // Shows the Locked Button image.
            currentText.text = "";                      // Show blank Text on the Button.
            star1.gameObject.SetActive(false);
            star2.gameObject.SetActive(false);          // - Hide all 3 stars.
            star3.gameObject.SetActive(false);
        }
	}

    public int GetLife()    // Called before level is loaded.
    {
        return DataCtrl.instance._data.Life;    // Returns value in Life variable.
    }

    public void LoadScene(string sceneName)
    {
        int currentLife = GetLife();       // Takes the current Life value from DB. 
        if (unlocked && currentLife > 0)   // Condition for next level to be loaded.
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            adWatcher.SetActive(true);      // Shows adWatcher panel.
        }
    }
}
