using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _firstRoad;
    [SerializeField] private GameObject _secondRoad;
    [SerializeField] private GameObject _thirdRoad;

    [SerializeField] private int _levelPhase;

    private const float _roadWidth = 25f;
    private int _score;

    private bool _isGameOver;

    #region Encapsulated Variables
    public GameObject firstRoad => _firstRoad;
    public GameObject secondRoad => _secondRoad;
    public GameObject thirdRoad => _thirdRoad;

    public int levelPhase => _levelPhase;

    public int score => _score;

    public bool isGameOver => _isGameOver;

    #endregion

    #endregion

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.GetComponent<GameObject>();
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        _firstRoad = GameObject.Find("Road1");
        _secondRoad = GameObject.Find("Road2");
        _thirdRoad = GameObject.Find("Road3");
    }
    private void Update()
    {
        CheckLevelPhases();
        PutTheRoads();
        CheckTheGame();
        ManageScore();
    }
    private void CheckLevelPhases()
    {
        float firstRoadDelta = PlayerController.Instance.transform.position.x - _firstRoad.transform.position.x;
        float secondRoadDelta = PlayerController.Instance.transform.position.x - _secondRoad.transform.position.x;
        float thirdRoadDelta = PlayerController.Instance.transform.position.x - _thirdRoad.transform.position.x;

        if (firstRoadDelta <= (_roadWidth / 2) && firstRoadDelta > -(_roadWidth / 2))
        {
            _levelPhase = 0;
        }
        if (secondRoadDelta <= (_roadWidth / 2) && secondRoadDelta > -(_roadWidth / 2))
        {
            _levelPhase = 1;
        }
        if (thirdRoadDelta <= (_roadWidth / 2) && thirdRoadDelta > -(_roadWidth / 2))
        {
            _levelPhase = 2;
        }
    }
    private void PutTheRoads()
    {
        Vector3 offset = new Vector3(_roadWidth, 0, 0);

        if (_levelPhase == 0)
        {
            _secondRoad.transform.position = _firstRoad.transform.position - offset;
            _thirdRoad.transform.position = _firstRoad.transform.position + offset;
        }
        if (_levelPhase == 1)
        {
            _thirdRoad.transform.position = _secondRoad.transform.position - offset;
            _firstRoad.transform.position = _secondRoad.transform.position + offset;
        }
        if (_levelPhase == 2)
        {
            _firstRoad.transform.position = _thirdRoad.transform.position - offset;
            _secondRoad.transform.position = _thirdRoad.transform.position + offset;
        }
    }
    private void CheckTheGame()
    {
        if (_isGameOver)
        {
            Time.timeScale = 0;
        }
        if (!_isGameOver)
        {
            Time.timeScale = 1;
        }
        if (PlayerController.Instance.healthPoint == 0)
        {
            _isGameOver = true;
        }
        if (PlayerController.Instance.healthPoint > 0)
        {
            _isGameOver = false;
        }
    }
    private void ManageScore()
    {
        _score = (int)(Mathf.Abs(PlayerController.Instance.transform.position.x / _roadWidth) * 100);
    }
}
