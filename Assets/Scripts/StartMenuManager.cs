using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]

public class StartMenuManager : MonoBehaviour
{
    public TMP_InputField nameText;
    public TextMeshProUGUI infoText;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
        if (nameText.text.Length > 0)
        {
            infoText.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
        else
        {
            infoText.gameObject.SetActive(true);
        }
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
