using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Main Data Controller, used for saving and loading GameData & LevelData, this is a moving script.
/// </summary>
public class DataCtrl : MonoBehaviour
{
    public static DataCtrl instance = null;
    public GameData _data;
    public bool DevMode;
    string dataFilePath;
    BinaryFormatter binaryFor;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        binaryFor = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.gob";

        Debug.Log(dataFilePath);
    }

    public void RefreshData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream _fileStream = new FileStream(dataFilePath, FileMode.Open);
            _data = (GameData)binaryFor.Deserialize(_fileStream);
            _fileStream.Close();

            Debug.Log("Game Data Refreshed");
        }
    }

    public void SaveData()
    {
        FileStream _fileStream = new FileStream(dataFilePath, FileMode.Create);
        binaryFor.Serialize(_fileStream, _data);
        _fileStream.Close();
        Debug.Log("Game Data Saved!");
    }

    public void SaveData(GameData _data)
    {
        FileStream _fileStream = new FileStream(dataFilePath, FileMode.Create);
        binaryFor.Serialize(_fileStream, _data);
        _fileStream.Close();
        Debug.Log("GameData - Data Saved!");
    }

    public bool IsUnlocked(int levelNumber) // Gets the Availability information of the current level
    {
        return _data.levelData[levelNumber].isUnlocked;
    }

    public int GetStars(int levelNumber)    // Gets the Stars information if the current level
    {
        return _data.levelData[levelNumber].starsAwarded;
    }

    private void OnEnable()
    {
        CheckDB();
    }

    private void CheckDB()
    {
        if (!File.Exists(dataFilePath))
        {
            #if UNITY_ANDROID
            CopyDB();
            #endif
        }
        else
        {
            if(SystemInfo.deviceType == DeviceType.Desktop)
            {
                string destFile = Path.Combine(Application.streamingAssetsPath, "game.gob");
                File.Delete(destFile);
                File.Copy(dataFilePath, destFile);
            }

            if (DevMode)
            {
                if (SystemInfo.deviceType == DeviceType.Handheld)
                {
                    File.Delete(dataFilePath);
                    CopyDB();
                }
            }
            RefreshData();
            Debug.Log("Game Data Loaded.");
        }
    }

    void CopyDB()
    {
        string scrFile = Path.Combine(Application.streamingAssetsPath, "game.gob");

        WWW downloader = new WWW(scrFile);

        while (!downloader.isDone)
        {
            //
        }
        // Save to Application.persistenDataPath 
        File.WriteAllBytes(dataFilePath, downloader.bytes);
        RefreshData();
    }
}
