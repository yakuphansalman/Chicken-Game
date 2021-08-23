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
    private int _score;

    private const float _roadWidth = 25f;

    private bool _isGameOver;

    [SerializeField] private ParticleSystem _dustParticle;

    private AudioSource _gameAudio;
    [SerializeField] AudioClip _clickAudio;

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
        _gameAudio = GetComponent<AudioSource>();

        ManageMusic();
    }
    private void Update()
    {
        CheckLevelPhases();
        PutTheRoads();
        CheckTheGame();
        ManageScore();
        ManageParticleEffects();
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
            PlayerController.Instance.gameObject.SetActive(false);
            DataManager.Instance.SaveData();
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
    private void ManageParticleEffects()
    {
        GameObject[] grasses = GameObject.FindGameObjectsWithTag("Grass");
        float grassWidth = 5f;

        foreach (var grass in grasses)
        {
            if (Mathf.Abs(PlayerController.Instance.transform.position.x - grass.transform.position.x) < grassWidth / 2 && PlayerController.Instance.horizontalInput != 0)
            {
                _dustParticle.Play();
            }
            else if (Mathf.Abs(PlayerController.Instance.transform.position.x - grass.transform.position.x) <= (grassWidth / 2) + 0.2f && Mathf.Abs(PlayerController.Instance.transform.position.x - grass.transform.position.x) > grassWidth / 2)
            {
                _dustParticle.Pause();
            }
        }
    }
    private void ManageMusic()
    {
        _gameAudio.volume = DataManager.Instance.dm_musicVolume;
    }
    public void Click()
    {
        _gameAudio.PlayOneShot(_clickAudio);
    }
}
