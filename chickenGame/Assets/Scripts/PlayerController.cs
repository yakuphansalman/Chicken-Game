using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _speed;

    #region Encapsulated Variables
    public float speed => _speed;
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
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontalInput * _speed * Time.deltaTime;
    }

}
