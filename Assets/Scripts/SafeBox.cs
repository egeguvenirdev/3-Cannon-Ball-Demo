using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : MonoBehaviour
{
    void FixedUpdate()
    {
        if (gameObject.transform.localPosition.y <= -1.5f)
        {
            GameManager.Instance.ReduceBoxCount(1);
            gameObject.SetActive(false);
        }
    }
}
