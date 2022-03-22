using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    private Vector3 rotateVector = new Vector3(0.0f, 1.0f, 0.0f);
    [SerializeField] private float speed;
    void FixedUpdate()
    {
        gameObject.transform.Rotate(rotateVector, speed);
    }
}
