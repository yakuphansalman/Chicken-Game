using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1000)]
public class PlayerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _speed;
    private float _healthPoint;
    private float _horizontalInput;

    [SerializeField] private AudioClip _hurtAudioClip;
    private AudioSource _hurtAudioSource;

    #region Encapsulated Variables
    public float speed => _speed;//ENCAPSULATION
    public float healthPoint => _healthPoint;//ENCAPSULATION
    public float horizontalInput => _horizontalInput;//ENCAPSULATION

    #endregion

    #endregion

    #region Singleton
    private static PlayerController _instance;
    public static PlayerController Instance
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

        _healthPoint = 3;
    }
    private void Start()
    {
        _hurtAudioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        Move();//ABSTRACTION
        CreateBound();//ABSTRACTION
    }
    private void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * _horizontalInput * _speed * Time.deltaTime;
    }
    
    private void CreateBound()
    {
        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle") && transform.position.x != 0)
        {
            _healthPoint--;
            _hurtAudioSource.PlayOneShot(_hurtAudioClip);
            other.gameObject.SetActive(false);
        }
    }

}
