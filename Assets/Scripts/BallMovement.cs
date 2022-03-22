using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 movementVector;
    [SerializeField] private float speed;
    private void Start()
    {
        movementVector = new Vector3(0, 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
