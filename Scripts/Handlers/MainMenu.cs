using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Handles functionality for most of UI elements in MainMenu scene, this script is attached to UI.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public string facebookURL;  // contains URL to GOBOL facebook page. 

    private void Start()
    {
        Time.timeScale = 1f;    // Sets the game timeScale to 1 on Start. 
    }

    public void StartButton (string sceneName)  // Called when Play Button was pressed, requires 1 parameter.
    {
        SceneManager.LoadScene(sceneName);  // Loads the given scene from Paramether string sceneName.
    }

    public void SettingsButton(string sceneName)    // Called when Settings Button was pressed,  requires 1 parameter.
    {
        SceneManager.LoadScene(sceneName);  // Loads the given scene from Paramether string sceneName.
    }

    public void ExitButton ()   // Called when Quit Button was pressed.
    {
        Application.Quit(); // Quits the application.
	}

    public void FacebookLike()  // Called when Facebook Button was pressed.
    {
        Application.OpenURL(facebookURL);   // Open the provided URL. 
    }
}
