using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string Username;
    public int BestScore;
    public string BestScoreName;

    private void Awake()
    {        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScoreData();
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestScoreName;
    }

    public void SaveScoreData()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.BestScoreName = BestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestScoreName = data.BestScoreName;
        }
    }
}
