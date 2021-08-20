using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = PlayerController.Instance.transform.position + _offset;
    }
}
