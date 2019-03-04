using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This script handles Scene changing. This script can be found at most buttons that change Scene.
/// </summary>
public class SceneChanger : MonoBehaviour
{
    public string sceneName;    // Variable of string containing the name of the Scene.

    public void LoadScene()     // Called when player clicks the button for Menu.
    {
        SceneManager.LoadScene(sceneName);  // Load sceneName scene.
    }

    public void RestartScene()  // Called when player clicks the button to replay the current level.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Restart this active Scene.
    }
}
