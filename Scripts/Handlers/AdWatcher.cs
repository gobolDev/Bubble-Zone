using UnityEngine;
/// <summary>
/// Handles the Advertisement system in the game. This script is attahed to AdWatcher Panel.
/// </summary>
public class AdWatcher : MonoBehaviour
{
    public void WatchAnAd()     // Called when user agreed to press a button to watch an Ad.
    {
        DataCtrl.instance._data.Life = DataCtrl.instance._data.Life + 2;    // Add 2 more lifes to player.
        DataCtrl.instance.SaveData();                                       // Saves the given 2 lifes.
        gameObject.SetActive(false);                                        // Hides AdWatcher panel.
    }

    public void CancelButton()  // Called when user disagreed to press a button to watch an Ad.
    {
        gameObject.SetActive(false);    // Hides AdWatcher panel.
    }
}

// Unfinished work! A script is under construction!
