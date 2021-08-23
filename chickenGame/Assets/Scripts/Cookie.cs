using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : Rotater//INHERITANCE
{
    private float _randomNumber;
    private void Start()
    {
        RandomizeDimensions();//ABSTRACTION
    }
    public override void RotateObject()//POLYMORPHISM
    {
        transform.Rotate(new Vector3(_randomNumber, _randomNumber, _randomNumber) * rotationSpeed * Time.deltaTime);
    }
    private void RandomizeDimensions()
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
}
