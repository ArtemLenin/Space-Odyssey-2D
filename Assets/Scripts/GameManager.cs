using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private UnityEvent _playLevelActions;

    // =================== Level ===================
    private string _currentLevelName = "";
    private int _currentLevelIndex;
    private bool _isLevelCompleted = false;
    private bool _isPlayMode = false;

    public static GameManager Instance { get => _instance; private set => _instance = value; }
    public bool IsPlayMode { get => _isPlayMode; private set => _isPlayMode = value; }
    public bool IsLevelCompleted { get => _isLevelCompleted; private set => _isLevelCompleted = value; }
    public string CurrentLevelName { get => _currentLevelName; private set => _currentLevelName = value; }
    private int CurrentLevelIndex { get => _currentLevelIndex; set => _currentLevelIndex = value; }
    public UnityEvent PlayLevelActions { get => _playLevelActions; set => _playLevelActions = value; }

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    private void OnLevelWasLoaded(int level)
    {
        CurrentLevelName = SceneManager.GetSceneAt(level).name;
        IsLevelCompleted = false;
        IsPlayMode = false;
    }

    public void StartPlay()
    {
        IsPlayMode = true;
    }

    public void CheckCompletion()
    {
        LoadNextLevel();
    }

    public void AddStartLevelAction(UnityAction action)
    {
        PlayLevelActions.AddListener(action);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(++CurrentLevelIndex);
    }
}