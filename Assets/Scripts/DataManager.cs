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

    [Serializable]
    public class SaveData
    {
        public HighScorePlayerNames names;
        public HighScores scores;
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
        else
        {
            instance = this;    
        }
        LoadData();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();

        data.names = highScorePlayerNames;
        data.scores = highScores;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json",json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "savefile.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScorePlayerNames = data.names;
            highScores = data.scores;
        }
    }
}
