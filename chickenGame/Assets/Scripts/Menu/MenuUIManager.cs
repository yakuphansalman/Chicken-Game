using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MenuUIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private InputField _nameEntered;

    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _mainMenu;

    #region Encapsulated Variables

    public string nameEntered => _nameEntered.text;

    #endregion

    #endregion

    #region Singleton
    public static MenuUIManager Instance;
    #endregion

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
    public void GoSettings(bool onSettings)
    {
        if (!onSettings)
        {
            DataManager.Instance.SaveData();
        }
        _mainMenu.gameObject.SetActive(!onSettings);
        _settingsMenu.gameObject.SetActive(onSettings);
    }
    
}
