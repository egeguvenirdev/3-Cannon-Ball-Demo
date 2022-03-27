using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float blastPower;
    private float lifeTime = 5;

    private Collider[] ragDollColliders;
    private Rigidbody[] limbsRigidbodies;
    [SerializeField] private Rigidbody hip;

    private void Start()
    {
        GetRagdollBits();
        OpenRagdoll();

        foreach (Rigidbody childRB in limbsRigidbodies)
        {
            childRB.velocity = PlayerManagement.Instance.shotPoint.transform.right * -1 * blastPower;
        }
        Debug.Log(hip);
    }
    
    private void SetActiveFalse()
    {
        if (lifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
        lifeTime -= Time.deltaTime;
    }

    public void GetRagdollBits()
    {
        ragDollColliders = gameObject.GetComponentsInChildren<Collider>();
        limbsRigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
    }

    public void CloseRagdoll()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }
    }

    public void OpenRagdoll()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }
    }
}
