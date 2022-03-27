using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private float speed;
    void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.up, speed);
    }
}
