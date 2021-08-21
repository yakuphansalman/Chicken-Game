using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private float _randomNumber;

    private void Start()
    {
        float random = Random.Range(0, 2);
        if (random == 0)
        {
            _randomNumber = Random.Range(-1.0f, -0.5f);
        }
        if (random == 1)
        {
            _randomNumber = Random.Range(0.5f, 1.0f);
        }
    }
    private void Update()
    {
        
        transform.Rotate(new Vector3(_randomNumber, _randomNumber, _randomNumber) * _rotationSpeed * Time.deltaTime);
    }
}