using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBox : MonoBehaviour
{
    [SerializeField] private float blastRadius;
    [SerializeField] private LayerMask layer;
    [SerializeField] private ParticleSystem blowUp;
    [SerializeField] private AudioClip explosionAudio;
    private AudioSource camSound;

    private void Start()
    {
        camSound = Camera.main.GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            camSound.PlayOneShot(explosionAudio);
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
            Instantiate(blowUp, transform.position, transform.rotation);

            Collider[] collider = Physics.OverlapSphere(transform.position, blastRadius);

            foreach (Collider boxes in collider)
            {
                Rigidbody rb = boxes.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(Random.Range(300, 700), transform.position, blastRadius);
                }

            }
        }
    }
}
