using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    [SerializeField] private float _spawnRate;

    [SerializeField] private Vector3 _offsetZ;
    [SerializeField] private Vector3 _offsetX;

    private Vector3 _firstSpawnPosition;
    private Vector3 _secondSpawnPosition;
    private Vector3 _thirdSpawnPosition;

    private void Start()
    {
        InvokeRepeating("InstantiatePooledObjects", 0.2f, _spawnRate);
    }
    private void Update()
    {
        SetSpawnPosition();
        MakeItDifficult();
    }
    private void SetSpawnPosition()
    {
        _firstSpawnPosition = GameManager.Instance.firstRoad.transform.position + _offsetZ;
        _secondSpawnPosition = GameManager.Instance.secondRoad.transform.position + _offsetZ;
        _thirdSpawnPosition = GameManager.Instance.thirdRoad.transform.position + _offsetZ;
    }
    private void InstantiatePooledObjects()
    {
        int counter = 0;
        _pool.GetPooledObject(counter++ % 4, _firstSpawnPosition);
        _pool.GetPooledObject(counter++ % 4, _firstSpawnPosition + _offsetX);
        _pool.GetPooledObject(counter++ % 4, _firstSpawnPosition - _offsetX);
        _pool.GetPooledObject(counter++ % 4, _secondSpawnPosition);
        _pool.GetPooledObject(counter++ % 4, _secondSpawnPosition + _offsetX);
        _pool.GetPooledObject(counter++ % 4, _secondSpawnPosition - _offsetX);
        _pool.GetPooledObject(counter++ % 4, _thirdSpawnPosition);
        _pool.GetPooledObject(counter++ % 4, _thirdSpawnPosition + _offsetX);
        _pool.GetPooledObject(counter++ % 4, _thirdSpawnPosition - _offsetX);
        
    }
    
    private void MakeItDifficult()
    {
        if (GameManager.Instance.score == 1000)
        {
            _spawnRate = 2;
        }
    }

}
