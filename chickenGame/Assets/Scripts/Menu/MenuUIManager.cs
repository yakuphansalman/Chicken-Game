using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

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
    
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        DataManager.Instance.SaveData();
        EditorApplication.ExitPlaymode();
    }
}
