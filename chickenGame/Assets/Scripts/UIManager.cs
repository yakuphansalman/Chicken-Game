using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _cookieButton;
    [SerializeField] private TextMeshProUGUI _scoreText;
 
    private GameObject _cookie;
    private GameObject[] _cookies;
    [SerializeField] GameObject _gameOverTitle;

    [SerializeField] private ObjectPool pool;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            InstantiateCookies(_cookie, Vector3.left * i * 15);
        }
        _cookies = GameObject.FindGameObjectsWithTag("Cookie");
    }

    private void Update()
    {
        for (int i = 2; i > -1; i--)
        {
            if (PlayerController.Instance.healthPoint == i)
            {
                _cookies[i].SetActive(false);
            }
        }
        if (GameManager.Instance.isGameOver)
        {
            _gameOverTitle.SetActive(true);
        }
        _scoreText.text = "Your score is " + GameManager.Instance.score;
    }

    private void InstantiateCookies(GameObject cookie , Vector3 offset)
    {
        cookie = pool.GetPooledObject(4, _cookieButton.transform.position + offset);
        cookie.transform.parent = _cookieButton.transform;
        cookie.transform.eulerAngles = new Vector3(270, 0, 0);
        cookie.transform.localScale = new Vector3(150, 150, 150);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }
}
