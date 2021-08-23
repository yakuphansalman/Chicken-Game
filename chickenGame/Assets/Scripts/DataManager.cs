using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    #region Variables

    private int _highScore;

    [Range(0,100)]private float _musicVolume;

    private string _highScorer;
    private string _player;

    private Scene _scene;

    #region Encapsulated Variables
    public int dm_highScore => _highScore;

    public float dm_musicVolume => _musicVolume;

    public string dm_highScorer => _highScorer;
    public string dm_player => _player;
    #endregion

    #endregion
    #region Singleton
    public static DataManager Instance;
    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    private void Update()
    {
        _scene = SceneManager.GetActiveScene();

        if (_scene == SceneManager.GetSceneByName("MenuScene"))
        {
            _musicVolume = MenuGameManager.Instance.audioSlider.value;
            Time.timeScale = 1;
        }

        if (_scene == SceneManager.GetSceneByName("SampleScene"))
        {
            if (GameManager.Instance.score > _highScore)
            {
                _highScore = GameManager.Instance.score;
                _highScorer = _player;
                SaveData();
            }
            
        }
        _player = MenuUIManager.Instance.nameEntered;
    }

    public void SetPlayerName()
    {
        _player = MenuUIManager.Instance.nameEntered;
    }
    [System.Serializable]
    class SavingData
    {
        public string highScorerData;
        public string playerData;

        public int highScoreData;

        public float musicVolumeData;
    }

    public void SaveData()
    {
        SavingData data = new SavingData();
        data.highScoreData = _highScore;
        data.highScorerData = _highScorer;
        data.playerData = _player;
        data.musicVolumeData = _musicVolume;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavingData data = JsonUtility.FromJson<SavingData>(json);

            _highScore = data.highScoreData;
            _highScorer = data.highScorerData;
            _player = data.playerData;
            _musicVolume = data.musicVolumeData;
        }
    }
}
