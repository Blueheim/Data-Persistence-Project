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
    public static StartMenuManager Instance;
    [SerializeField] TMP_InputField nameText;
    [SerializeField] TextMeshProUGUI infoText;
    //public string playerName { get; private set; }
    public static string playerName { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        if (nameText.text.Length > 0)
        {
            playerName = nameText.text;
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
