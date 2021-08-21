using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    #region Variables

    private int _highScore;
    private string _highScorer;
    private string _player;

    #region Encapsulated Variables
    public int dm_highScore => _highScore;

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
    private void Start()
    {
        if (GameManager.Instance.score > _highScore)
        {
            _highScore = GameManager.Instance.score;
            _highScorer = _player;
        }
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
    }

    public void SaveData()
    {
        SavingData data = new SavingData();
        data.highScoreData = _highScore;
        data.highScorerData = _highScorer;
        data.playerData = _player;

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
        }
    }
}
