using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _cookieButton;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private Text _player;

    private GameObject _cookie;
    private GameObject[] _cookies;
    [SerializeField] GameObject _gameOverTitle;

    [SerializeField] private ObjectPool pool;

    #endregion
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            InstantiateCookies(_cookie, Vector3.left * i * 15);//ABSTRACTION
        }

        _cookies = GameObject.FindGameObjectsWithTag("Cookie");

        _player.text = DataManager.Instance.dm_player;//Show name of the player
    }

    private void Update()
    {
        HideCookies();//ABSTRACTION
        CheckTheGame();//ABSTRACTION
        ManageText();//ABSTRACTION
    }

    private void InstantiateCookies(GameObject cookie, Vector3 offset)
    {
        cookie = pool.GetPooledObject(4, _cookieButton.transform.position + offset);
        cookie.transform.parent = _cookieButton.transform;
        cookie.transform.eulerAngles = new Vector3(270, 0, 0);
        cookie.transform.localScale = new Vector3(150, 150, 150);
    }

    private void HideCookies()
    {
        for (int i = 2; i > -1; i--)
        {
            if (PlayerController.Instance.healthPoint == i)
            {
                _cookies[i].SetActive(false);
            }
        }
    }
    private void CheckTheGame()
    {
        if (GameManager.Instance.isGameOver)
        {
            _gameOverTitle.SetActive(true);
            _player.gameObject.SetActive(false);
        }
    }
    private void ManageText()
    {
        _scoreText.text = "Your score is " + GameManager.Instance.score;

        if (DataManager.Instance.dm_player == DataManager.Instance.dm_highScorer)
        {
            _highScoreText.text = "You are the high scorer your score is " + DataManager.Instance.dm_highScore;
            _player.text = DataManager.Instance.dm_player + " the high scorer";
        }
        else
        {
            _highScoreText.text = "High score is " + DataManager.Instance.dm_highScore + " high scorer is " + DataManager.Instance.dm_highScorer;
        }
    }
    public void LoadScene(int scene)
    {
        if (scene == 0)
        {
            DataManager.Instance.LoadData();
        }
        SceneManager.LoadScene(scene);
    }
}
