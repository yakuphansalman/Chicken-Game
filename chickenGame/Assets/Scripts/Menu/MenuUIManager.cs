using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
