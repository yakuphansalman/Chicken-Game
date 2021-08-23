using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    public float rotationSpeed => _rotationSpeed;//ENCAPSULATION

    private void Update()
    {
        RotateObject();
    }
    public virtual void RotateObject()
    {
        if (PlayerController.Instance.transform.position.x < 0)
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime * PlayerController.Instance.horizontalInput);
        }
        
    }
    
}
