using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainDataManager : MonoBehaviour
{
    public static MainDataManager Instance;

    public static int BestScore;
    public static string PlayerName;
    public static string BestPlayerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class BestScoreData
    {
        public int BestScore;
        public string BestPlayerName;
    }
    public void SaveBestScore(int bestScore, string bestPlayerName)
    {
        BestScoreData bestScoreData = new BestScoreData();
        bestScoreData.BestScore = bestScore;
        bestScoreData.BestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(bestScoreData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScoreData bestScoreData = JsonUtility.FromJson<BestScoreData>(json);

            BestScore = bestScoreData.BestScore;
            BestPlayerName = bestScoreData.BestPlayerName;
        }
    }
}
