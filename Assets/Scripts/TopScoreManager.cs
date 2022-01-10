using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TopScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI top1ScoreText;
    [SerializeField] TextMeshProUGUI top2ScoreText;
    [SerializeField] TextMeshProUGUI top3ScoreText;
    // Start is called before the first frame update
    void Awake()
    {
        if (StartMenuManager.topScores.Count > 0)
        {
            top1ScoreText.text = $"{StartMenuManager.topScores[0].playerName} - {StartMenuManager.topScores[0].points}";
            top2ScoreText.text = $"{StartMenuManager.topScores[1].playerName} - {StartMenuManager.topScores[1].points}";
            top3ScoreText.text = $"{StartMenuManager.topScores[2].playerName} - {StartMenuManager.topScores[2].points}";
        }

    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
