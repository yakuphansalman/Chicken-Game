using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Slider _audioSlider;

    private AudioSource _menuAudioSource;
    [SerializeField] AudioClip _clickAudio;

    #region Encapsulated Variables

    public AudioSource menuAudio => _menuAudioSource;//ENCAPSULATION

    public Slider audioSlider => _audioSlider;//ENCAPSULATION

    #endregion

    #endregion

    #region Singleton

    private static MenuGameManager _instance;
    public static MenuGameManager Instance
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
        _menuAudioSource = GetComponent<AudioSource>();
        _audioSlider.value = DataManager.Instance.dm_musicVolume;
    }
    private void Update()
    {
        _menuAudioSource.volume = DataManager.Instance.dm_musicVolume;
    }
    public void Click()
    {
        _menuAudioSource.PlayOneShot(_clickAudio);
    }
}
