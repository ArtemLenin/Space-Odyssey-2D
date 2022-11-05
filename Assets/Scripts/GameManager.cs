using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private UnityEvent _playLevelActions = new UnityEvent();

    // =================== Level ===================
    private bool _isLevelCompleted = false;
    private bool _isPlayMode = false;
    private float _playTime = 0.0f;

    // ================== Level 2 ===================
    [Header("Level 2")]
    [SerializeField] private int _lvl2Duration = 60;
    [SerializeField] private float _minX = -13.7f;
    [SerializeField] private float _maxX = 13.7f;
    [SerializeField] private float _posY = -7f;

    public static GameManager Instance { get => _instance; private set => _instance = value; }
    public bool IsPlayMode { get => _isPlayMode; private set => _isPlayMode = value; }
    public bool IsLevelCompleted { get => _isLevelCompleted; private set => _isLevelCompleted = value; }

    public UnityEvent PlayLevelActions { get => _playLevelActions; private set => _playLevelActions = value; }
    public float PlayTime { get => _playTime; set => _playTime = value; }
    public float MinX { get => _minX; private set => _minX = value; }
    public float MaxX { get => _maxX; private set => _maxX = value; }
    public float PosY { get => _posY; private set => _posY = value; }
    private int Lvl2Duration { get => _lvl2Duration; }

    private void Awake()
    {
        if (!Instance) Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {

    }

    private void Update()
    {
        if (IsPlayMode)
        {
            PlayTime += Time.deltaTime;
            if (PlayTime >= Lvl2Duration && SceneLoader.Instance.CurrentLevelName == "Lvl 2")
            {
                SceneLoader.Instance.LoadNextLevel();
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            StartPlay();
        }
    }

    public void StartPlay()
    {
        IsPlayMode = true;
        PlayLevelActions.Invoke();
    }

    public void CheckCompletion()
    {
        SceneLoader.Instance.LoadNextLevel();
    }

    public void AddStartLevelAction(UnityAction action)
    {
        PlayLevelActions.AddListener(action);
    }

    public void ResetValues()
    {
        IsLevelCompleted = false;
        IsPlayMode = false;

        PlayLevelActions.RemoveAllListeners();

        PlayTime = 0;
    }
}