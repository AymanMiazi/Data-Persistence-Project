using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string playerName;
    public HighScorePlayerNames highScorePlayerNames;
    public HighScores highScores;
    public Settings settings;
    public int[] values = { 1, 2, 5 };

    [Serializable]
    public class SaveData
    {
        public HighScorePlayerNames names;
        public HighScores scores;
    }
    [Serializable]
    public class Settings
    {
        public int first;
        public int second;
        public int third;
        public int fourth;
        public int fifth;
        public int sixth;
    }
    [Serializable]
    public class SettingsData
    {
        public Settings settings;
    }

    [Serializable]
    public class HighScorePlayerNames
    {
        public string first;
        public string second;
        public string third;
    }
    
    [Serializable]
    public class HighScores
    {
        public int firstScore;
        public int secondScore;
        public int thirdScore;
    }
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        LoadData();
        DontDestroyOnLoad(gameObject);
        LoadSettings();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();

        data.names = highScorePlayerNames;
        data.scores = highScores;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json",json);
    }
    
    public void SaveSettings()
    {
        SettingsData data = new SettingsData();
    
        data.settings = settings;
    
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "settings.json",json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScorePlayerNames = data.names;
            highScores = data.scores;
        }
    }
    
    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "settings.json";
    
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);
            settings = data.settings;
        }
    }
}
