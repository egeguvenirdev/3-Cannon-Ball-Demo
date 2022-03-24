using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    //CannonController cannonController;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float blastPower;
    LineRenderer lineRenderer;

    // Number of points on the line
    [SerializeField] private int numPoints = 20;
    [SerializeField] private float height = 1; 

    // distance between those points on the line
    [SerializeField] private float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;
    void Start()
    {
        //cannonController = GetComponent<CannonController>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();

        Vector3 startingPosition = shotPoint.position;
        Vector3 startingVelocity = shotPoint.right * -1 * blastPower;

        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t * height;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 0.1f, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
    }
}
