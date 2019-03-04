using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/// <summary>
/// Handles Saves/Loads of SettingsData. This is moving script.
/// </summary>
public class SettingsCtrl : MonoBehaviour
{
    public static SettingsCtrl instance = null;
    public SettingsData data;                   // For accessing the game data.

    string dataFilePath;                        // Path were data file will be stored.
    BinaryFormatter binaryFormatter;            // Helps save/load data in binary files.

    private void Awake()
    {
        if (instance == null)       // Checks if there is instance of this class.
        {
            instance = this;        // If not, set this class to be an instance.
        }

        binaryFormatter = new BinaryFormatter();                        // Construct of BinaryFormatter used for serializing the data to the stream.
        dataFilePath = Application.persistentDataPath + "/volume.te";   // File path.
    }

    public void SaveData()
    {
        FileStream fileStream = new FileStream(dataFilePath, FileMode.Create);  // Creating the file containing the data.
        binaryFormatter.Serialize(fileStream, data);                            // Serilize that data.
        fileStream.Close();                                                     // Close the FileStream.
    }

    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fileStream = new FileStream(dataFilePath, FileMode.Open);    // Opening the file containing the data.
            data = (SettingsData)binaryFormatter.Deserialize(fileStream);           // Deserialize that data.
            fileStream.Close();                                                     // Close the FileStream.
        }
    }

    public void OnEnable()  // Called when this Script has become active.
    {
        LoadData();     // Load's the Data from DB.
    }

    public void OnDisable() // Called just before this Script becomes deactivated.
    {
        SaveData();     // Save's the Data from DB.
    }
}

