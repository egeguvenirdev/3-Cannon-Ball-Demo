using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private GameObject cannonMoveablePart;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject cannonBall;

    private Vector3 mousePrevPosition = Vector3.zero;
    private Vector3 mouseDeltaPos = Vector3.zero;

    [SerializeField] private float sensivitiy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(cannonBall, shotPoint.position, cannonMoveablePart.transform.rotation * Quaternion.Euler(0, 0, 0));
        }

        //cannon's aim (rotating)
        if (Input.GetMouseButton(0))
        {
            mouseDeltaPos = Input.mousePosition - mousePrevPosition;

            //Y axis
            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
            {
                cannonMoveablePart.transform.Rotate(transform.up, +Vector3.Dot(mouseDeltaPos, Camera.main.transform.right) * sensivitiy, Space.World);
            }
            else
            {
                cannonMoveablePart.transform.Rotate(transform.up, -Vector3.Dot(mouseDeltaPos, Camera.main.transform.right) * sensivitiy, Space.World);
            }

            //Y axis
            cannonMoveablePart.transform.Rotate(Camera.main.transform.right, -Vector3.Dot(mouseDeltaPos, Camera.main.transform.up) * sensivitiy, Space.World);
        }
        mousePrevPosition = Input.mousePosition;
    }
}
