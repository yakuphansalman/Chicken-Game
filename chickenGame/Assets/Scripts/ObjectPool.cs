using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public Queue<GameObject> poolQueue;
        public int poolSize;
        public GameObject prefab;
    }

    [SerializeField] private Pool[] pools = null;
    private void Awake()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].poolQueue = new Queue<GameObject>();
            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject go = Instantiate(pools[j].prefab);
                go.gameObject.SetActive(false);
                pools[j].poolQueue.Enqueue(go);
            }
        }
    }
    public GameObject GetPooledObject(int objectType,Vector3 objectPosition)
    {
        GameObject obj = pools[objectType].poolQueue.Dequeue();
        obj.transform.position = objectPosition;
        obj.SetActive(true);
        pools[objectType].poolQueue.Enqueue(obj);
        return obj;
    }
}
