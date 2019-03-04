using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Handles Gameplay of current level. This script is found to be in each level.
/// </summary>
public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;

    public GameData data;                   // To work with GameData in Inspector
    [Header("ResumeAnim")]
    public GameObject resumeReady;
    public Text Score_Input;
    public Text Life_Input;
    public Button pause_Button;
    [Header("Panels")]
    public GameObject panel_GameOver;
    public GameObject panel_LevelComplete, panel_Pause, panel_Joystick, panel_Buttons;

    void Awake()
    {
        if (instance == null)   // Checks if there is Instance of this script
        {
            instance = this;    // Creates Instance of this script
        }
    }

    void Start()
    {
        DataCtrl.instance.RefreshData();
        data = DataCtrl.instance._data;
        RefreshUI();

        StartCoroutine(PauseDelay());
        HandleFirstBoot();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemies").Length == 0)   // Checks if there are Enemies in the Scene. If non, show Level Complete Panel.
        {
            Invoke("LevelCompleted", 2f);   // Invokes "LevelComplete" method after 2 second delay.
        }
    }

    public void RefreshUI() // Refreshes UI values. Called on the Start(). 
    {
        data.Score = 0;                             // Sets the Score to 0.
        Score_Input.text = data.Score.ToString();   // Displays the Score Text based on Score value in GameData.
        Life_Input.text = data.Life.ToString();     // Displays the Life Text based on Life value in GameData.
    }

    /// <summary>
    /// Saves the Stars of a specific level. Called from LevelCompleteCtrl.
    /// </summary>
    public void SetStarsAwarded(int levelNumber, int numOfStars)    // Takes 2 paramethers when called.
    {
        data.levelData[levelNumber].starsAwarded = numOfStars;  // Sets the number of Stars of a specific level to LevelData.

        Debug.Log("Number of Stars Awarded: " + data.levelData[levelNumber].starsAwarded);  // Prints the stars awarded in console.
    }

    /// <summary>
    /// Saves the Score achieved of a specific level. Called from LevelCompleteCtrl.
    /// </summary>
    public void SetScoreMade(int levelNumber, int levelScore)   // Takes 2 paramethers when called.
    {
        data.levelData[levelNumber].levelScore = levelScore;    // Sets the level Score of a current level to LevelData.

        Debug.Log("Score achieved: " + data.levelData[levelNumber].levelScore); // Print the Score achieved in current level.
    }

    /// <summary>
    /// Unlocks a specific level. Called from LevelCompleteCtrl.
    /// </summary>
    public void UnlockLevel(int levelNumber)    // Takes 1 paramether when called.
    {
        data.levelData[levelNumber].isUnlocked = true;  // Sets the level unlocked status of a specific level.
    }

    /// <summary>
    /// Takes the Score value from GameData. Called from LevelCompleteCtrl.
    /// </summary>
    public int GetScore()   // Returns Int. 
    {
        return data.Score;  // Returns the Score value from GameData.
    }

    void OnEnable()     // Called when Script becomes active.
    {
        RefreshUI();    // Called to Refresh UI.
    }

    void OnDisable()    // Called when Script deactivates.
    {
        DataCtrl.instance.SaveData(data);   // Saves the current Data to a GameData.
    }

    /// <summary>
    /// Updates Score. Called from Weapon Colliders[ PolyCollider, PolyColliderTwo, PolyColliderBullets].
    /// </summary>
    public void UpdateScore(int value)  // Takes 1 paramether when called.
    {
        //Debug.Log(value);                         // Prints the value recieved to Console.
        data.Score += value;                        // Add's a value to current Score.
        Score_Input.text = data.Score.ToString();   // Displays the new Score.
    }

    /// <summary>
    /// Updates Life. Called from Weapon Colliders.
    /// </summary>
    public void UpdateLife(int value)   // Takes 1 paramether when called.
    {
        for (int i = 0; i < value; i++) // If local >i< set to 0 is greater then value, then add +1.
        {
            data.Life -= value;                         // Use +1 to reduce a life | Use -1 to increase a life value in GameData.
            Life_Input.text = data.Life.ToString();     // Shows the Life Text according to Life value from GameData.

            data.Score = 0;                             // When player is hit by bubble, Score is set to 0.
            Score_Input.text = data.Score.ToString();   // Displays new value of Score, 0.
        }

        if (data.Life <= 0) // If Life value is less or equal to 0.
        {
            GameOver();             // Calls the GameOver method.
            Time.timeScale = 0f;    // Freezes game.
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Reloads active scene.
        }
    }

    public void GameOver()  // Called when player has no more lifes.
    {
        panel_GameOver.SetActive(true);     // Activates the GameOver Panel.
        panel_Joystick.SetActive(false);    // Hides the Joystick Panel.
        panel_Buttons.SetActive(false);     // Hides the Buttons Panel.
    }

    public void CampainMap()    // Called from GameOver Panel. Loads CampainMap Scene.
    {
        SceneManager.LoadScene("CampainMap");   // Loads writen Scene.
        Time.timeScale = 1;                     // Sets the timeScale to 1.
    }

    public void RestartLevel()  // Called from GameOver Panel. Restarts level with a delay. 
    {
        Time.timeScale = 1f;
        data.Score = 0;
        data.Life = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HandleFirstBoot()   // Called on Start, if game is first time played.
    {
        if (data.IsFirstBoot)
        {
            data.Score = 0;             // Sets Score to 0.
            data.Life = 10;             // Sets Life to 10.
            data.IsFirstBoot = false;   // Sets IsFirstBoot to false.
        }
    }

    void LevelCompleted()   // Called when all Enemies are Destroyed.
    {
        panel_LevelComplete.SetActive(true);    // Shows Level Complete Panel.
        panel_Joystick.SetActive(false);        // Hides Joystick Panel.
        panel_Buttons.SetActive(false);         // Hides Buttons Panel.
    }

    public void ShowPausePanel()    // Called when game is Paused.
    {
        panel_Pause.SetActive(true);        // Shows Pause Panel.
        panel_Joystick.SetActive(false);    // Hides Joystick Panel.
        panel_Buttons.SetActive(false);     // Hides Buttons Panel.
        Time.timeScale = 0;                 // Sets timeScale to 0.
    }

    #region Game Resumed Code
    public void HidePausePanel()    // Called when game is Resumed.
    {
        panel_Pause.SetActive(false);               // Hides Pause Panel.
        if (SettingsCtrl.instance.data.isJoystick)  // Checks isJoystick condition.
        {
            panel_Joystick.SetActive(true); // Shows Joystick controls.
        }
        else
        {
            panel_Buttons.SetActive(true);  // Shows Buttons controls.
        }
        StartCoroutine(PauseDelay());   // Starts Pause Animation.
    }

    IEnumerator PauseDelay() // Hides the Pause Panel and after 2.5 seconds it Resumes game.
    {
        Time.timeScale = 0;
        pause_Button.interactable = false;              // Disables Button before Anim started.
        resumeReady.SetActive(true);                    // Sets the Ready gameObject to true. Enables it!
        yield return new WaitForSecondsRealtime(2.5f);  // Waits 2.5 seconds.
        resumeReady.SetActive(false);                   // Sets the Ready gameObject to false. Disables it!
        Time.timeScale = 1;                             // Sets timeScale to 1.
        pause_Button.interactable = true;               // Enables Button when Anim finishes.
    }
    #endregion
}
