using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private float _spawnRate;
    [SerializeField] private Vector3 _offset;

    private Vector3 _firstSpawnPosition;
    private Vector3 _secondSpawnPosition;
    private Vector3 _thirdSpawnPosition;

    private void Update()
    {
        int counter = 0;
        SetSpawnPosition();
        if (GameManager.Instance.isLevelChanged)
        {
            _pool.GetPooledObject(counter++ % 4, _firstSpawnPosition);
            _pool.GetPooledObject(counter++ % 4, _secondSpawnPosition);
            _pool.GetPooledObject(counter++ % 4, _thirdSpawnPosition);
        }
    }
    private void SetSpawnPosition()
    {
        _firstSpawnPosition = GameManager.Instance.firstRoad.transform.position + _offset;
        _secondSpawnPosition = GameManager.Instance.secondRoad.transform.position + _offset;
        _thirdSpawnPosition = GameManager.Instance.thirdRoad.transform.position + _offset;
    }
    
}
