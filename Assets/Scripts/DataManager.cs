using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public Text playerName;
    public string playerNameT;
    public string bestPlayerName;
    public int bestScore;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadDataP();
        }
        else
        {
            Destroy(gameObject);
            return;
        }    
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
        public string bestPlayerName;
    }
    public void SaveDataP(int points) {
        if (points > bestScore)
        {
        SaveData data = new SaveData();     
        
            data.bestScore = points;
            data.bestPlayerName = playerNameT;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/playername.json", json);
        }
    }

    public void LoadDataP()
    {
        string path = Application.persistentDataPath + "/playername.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }

    public void LoadGame()
    {
        if (playerName.text != null)
        {
            playerNameT = playerName.text;
        }
        SceneManager.LoadScene(1);
    }
}
