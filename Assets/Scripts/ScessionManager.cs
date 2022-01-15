using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScessionManager : MonoBehaviour
{
    public static ScessionManager Instance;

    public string playerName = null;
    public string highScorePlayerName = null;
    public int highScore = 0;

    void Start() { }

    void Update() { }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }

    [System.Serializable]
    public class SaveData
    {
        public string highScorePlayerName;
        public string highScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.highScorePlayerName = highScorePlayerName;
        data.highScore = highScore.ToString();

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScore = int.Parse(data.highScore);
        }
    }
}
