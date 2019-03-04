using UnityEngine;
/// <summary>
/// This script is used ONLY for saving data during EARLY TESTING! It will be removed in future.
/// </summary>
public class BtnSaveController : MonoBehaviour
{
    public void SaveData()  // Called when Button "Save" is pressed.
    {
        DataCtrl.instance.SaveData();   // Saved the current data information to DB!
    }
}
