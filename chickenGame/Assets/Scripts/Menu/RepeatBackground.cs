using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;
    [SerializeField] private float _speed;

    private void Start()
    {
        _startPos = transform.position;
    }
    private void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
        if (transform.position.y > 7.5f)
        {
            transform.position = _startPos;
        }
    }
}
