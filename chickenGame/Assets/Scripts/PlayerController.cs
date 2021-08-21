using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _speed;
    private float _difficultyMultiplier = 1.1f;
    private float _healthPoint = 3;
    private float _horizontalInput;

    #region Encapsulated Variables
    public float speed => _speed;
    public float healthPoint => _healthPoint;
    public float horizontalInput => _horizontalInput;

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
        MakeItDifficult();
        CreateBound();
    }
    private void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * _horizontalInput * _speed * Time.deltaTime;
    }
    private void MakeItDifficult()
    {
        if (transform.position.x < -100 * _difficultyMultiplier)
        {
            _speed *= _difficultyMultiplier;
            _difficultyMultiplier = speed / 2;
        }
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
        if (other.gameObject.CompareTag("Vehicle"))
        {
            _healthPoint--;
            other.gameObject.SetActive(false);
        }
    }

}
