using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        DriveAway();
    }
    private void DriveAway()
    {
        transform.position += Vector3.back * _speed * Time.deltaTime;
    }
}
