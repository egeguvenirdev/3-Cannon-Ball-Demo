using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float blastPower;
    private bool isactivated;
    private float lifeTime = 5;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isactivated)
        {
            rb.velocity = PlayerManagement.Instance.shotPoint.transform.right * -1 * blastPower;
            isactivated = true;
        }
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }

        lifeTime -= Time.deltaTime;
    }
}
