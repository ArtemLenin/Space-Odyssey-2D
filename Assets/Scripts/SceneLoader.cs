using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _instance;
    private string _currentLevelName = "";
    private int _currentLevelIndex;

    public string CurrentLevelName { get => _currentLevelName; private set => _currentLevelName = value; }
    private int CurrentLevelIndex { get => _currentLevelIndex; set => _currentLevelIndex = value; }

    public static SceneLoader Instance { get => _instance; private set => _instance = value; }

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(++CurrentLevelIndex);
    }

    private void OnLevelWasLoaded(int level)
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(level);
        CurrentLevelName = scene.name;
        CurrentLevelIndex = scene.buildIndex;

        GameManager.Instance.ResetValues();
    }
}