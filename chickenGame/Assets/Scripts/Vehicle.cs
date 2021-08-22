using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private float _speedDynamic;
    [SerializeField] private float _speed;

    private void Start()
    {
        _speedDynamic = _speed;
    }
    private void FixedUpdate()
    {
        DriveAway();
        SpeedThemUp();
    }
    private void DriveAway()
    {
        transform.position += Vector3.back * _speedDynamic * Time.deltaTime;
    }
    private void SpeedThemUp()
    {
        for (int i = 1; i < 20; i++)
        {
            if (GameManager.Instance.score == 100 * i)
            {
                _speedDynamic = _speed * (1+ (i*0.1f));
            }
        }
    }
}
