using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class StartMenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TextMeshProUGUI infoText;

    public void StartGame()
    {
        if (nameInputField.text.Length > 0)
        {
            StartMenuManager.Instance.playerName = nameInputField.text;
            infoText.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
        else
        {
            infoText.gameObject.SetActive(true);
        }
    }

    public void ShowTopScores()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
