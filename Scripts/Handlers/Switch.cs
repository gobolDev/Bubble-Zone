using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This script handles Scene changing in PlayMenu Scene.
/// </summary>
public class Switch : MonoBehaviour
{
    public void CampainLoad()   // Called when Campain Button is pressed.
    {
        SceneManager.LoadScene("CampainMap");   // Loads the CampainMap Scene.
    }

    public void BackLoad()      // Called when Back Button is pressed.
    {
        SceneManager.LoadScene("MainMenu");     // Loads the MainMenu Scene.
    }
}
