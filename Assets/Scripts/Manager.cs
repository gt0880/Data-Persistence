using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    private string currentPlayerName; //тут храним имя введенное при входе
    public int recordScore;
    public string recordPlayerName;
    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecordScore();
    }

    public void setName(string name) {
        currentPlayerName = name;
    }

    public string getName()
    {
        return currentPlayerName;
    }

    [System.Serializable]
    class PlayerData
    {
        public string name;
        public int score;
    }

    public void setRecordScore(int score, string name)
    {
        recordScore = score;
        recordPlayerName = name;
    }
    //сохраняем рекорд
    public void SaveRecordScore()
    {
        PlayerData data = new PlayerData();
        data.name = recordPlayerName;
        data.score = recordScore;

        string json = JsonUtility.ToJson(data);

        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecordScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            recordPlayerName = data.name;
            recordScore = data.score;
        }
        else {
            recordPlayerName = null;
            recordScore = 0;
        }
    }
}
