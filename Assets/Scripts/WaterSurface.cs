using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurface : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SafeBox" || collision.gameObject.tag == "ExplosiveBox")
        {
            var particle = ObjectPooler.Instance.GetPooledObject("WaterEffect");
            particle.transform.position = collision.transform.position - new Vector3(0, 2, 0);
            particle.transform.rotation = Quaternion.Euler(-90, 0, 0);
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();

            GameManager.Instance.ReduceBoxCount(1);
            collision.gameObject.SetActive(false);
        }

    }
}
