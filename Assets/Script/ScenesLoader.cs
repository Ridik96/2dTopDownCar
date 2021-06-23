using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ScenesLoader : MonoBehaviour
{
    public Button firstLevelButton;
    public Button secondLevelButton;
    public Button thirdLevelButton;
    public Button exit;
    public string[] sceneName;


    void Start()
    {
        firstLevelButton.onClick.AddListener(delegate { OnloadScenes(sceneName[0]); });
        secondLevelButton.onClick.AddListener(delegate { OnloadScenes(sceneName[1]); });
        thirdLevelButton.onClick.AddListener(delegate { OnloadScenes(sceneName[2]); });
        exit.onClick.AddListener(delegate { OnQuit(); });
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    private void OnloadScenes(string level)
    {
        SceneManager.LoadScene(level);
    }
}