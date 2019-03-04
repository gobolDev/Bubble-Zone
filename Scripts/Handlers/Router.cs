using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This script handles Pause/Resume system. This script is found in level Scenes,
/// </summary>
public class Router : MonoBehaviour
{
    private string sceneName;   // Var. of string containing the name of Scene.

    public void ShowPausePanel()    // Called when Pause Button is pressed.
    {
        GameCtrl.instance.ShowPausePanel(); // Pause the game.
    }

    public void HidePausePanel()    // Called when Resume Button is pressed.
    {
        GameCtrl.instance.HidePausePanel(); // Resume the game.
    }

    public void LoadScene(string sceneName) // Called when Menu Button is pressed.
    {
        SceneManager.LoadScene(sceneName);  // Load sceneName scene.
    }
}
