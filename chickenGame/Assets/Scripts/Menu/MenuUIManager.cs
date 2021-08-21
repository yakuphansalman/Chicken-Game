using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private InputField _nameEntered;

    public string nameEntered => _nameEntered.text;

    public static MenuUIManager Instance;

    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        _nameEntered.text = DataManager.Instance.dm_player;
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
