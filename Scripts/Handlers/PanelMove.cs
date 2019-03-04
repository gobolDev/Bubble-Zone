using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This script handles Stage movement. This script is in CampainMap Scene.
/// </summary>
public class PanelMove : MonoBehaviour
{
    public GameObject _panel01;     // Stage 1 Panel.
    public GameObject PointA;       // Position of active Panel.
    public GameObject _panel02;     // Stage 2 Panel.
    public GameObject PointB;       // Position of hiden Panel.
    
    private void Start()
    {
        _panel01.GetComponent<GameObject>();    // Gets the Stage 1.
        PointA.GetComponent<GameObject>();      // Gets the gameObject of active position. 
        _panel02.GetComponent<GameObject>();    // Gets the Stage 2.
        PointB.GetComponent<GameObject>();      // Gets the gameObject of hiden position.
    }

    public void ButtonRight()   // Called when Button for Right is pressed.
    {
        _panel02.transform.position = PointA.transform.position;    // Sets the position of Stage 2 equal to PointA.
        _panel01.SetActive(false);                                  // Hides the Stage 1 panel.
    }

    public void ButtonLeft()    // Called when Button for Left is pressed.
    {
        _panel02.transform.position = PointB.transform.position;    // Sets the position of Stage 2 equal to PointB.
        _panel01.SetActive(true);                                   // Shows the Stage 1 panel.
    }

    public void ButtonBack()    // Called when Back Button is pressed. 
    {
        SceneManager.LoadScene("PlayMenu"); // Loads PlayMenu Scene.
    }
}
