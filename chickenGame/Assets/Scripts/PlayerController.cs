using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _speed;
    private float _difficultyMultiplier = 1.1f;
    private float _healthPoint = 3;

    #region Encapsulated Variables
    public float speed => _speed;
    public float healthPoint => _healthPoint;
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
        _healthPoint = 3;
        _instance = this;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontalInput * _speed * Time.deltaTime;
        if (transform.position.x < -100 * _difficultyMultiplier)
        {
            _speed *= _difficultyMultiplier;
            _difficultyMultiplier = speed/2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            _healthPoint--;
            other.gameObject.SetActive(false);
        }
    }

}
