using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StartMenuManager : MonoBehaviour
{
    public static StartMenuManager Instance;
    public string playerName;

    public static List<Score> topScores { get; private set; } = new List<Score>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadTopScores();
    }

    [System.Serializable]
    public class Score
    {
        public string playerName;
        public int points;

        public Score(string playerName, int points)
        {
            this.playerName = playerName;
            this.points = points;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public List<Score> topScores;
    }

    public void SaveScore(int points)
    {
        if (topScores.Count == 0)
        {
            Score newScore = new Score(playerName, points);
            topScores.Add(newScore);
        }
        else
        {
            for (int i = 0; i < topScores.Count; i++)
            {
                if (topScores[i].points < points)
                {
                    Score newScore = new Score(playerName, points);
                    topScores.Insert(i, newScore);
                    if (topScores.Count > 3)
                    {
                        topScores = topScores.GetRange(0, 3);
                    }
                    break;
                }
            }
        }

        SaveData data = new SaveData();
        data.topScores = topScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/brick_savefile.json", json);
    }

    public void LoadTopScores()
    {
        string path = Application.persistentDataPath + "/brick_savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topScores = data.topScores;
        }
    }


}
