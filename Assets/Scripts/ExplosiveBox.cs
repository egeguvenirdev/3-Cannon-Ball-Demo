using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBox : MonoBehaviour
{
    [SerializeField] private float blastRadius;
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

            var particle = ObjectPooler.Instance.GetPooledObject("BlowupEffect");
            particle.transform.position = gameObject.transform.position;
            particle.transform.rotation = gameObject.transform.rotation;
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();

            Collider[] collider = Physics.OverlapSphere(transform.position, blastRadius);

            foreach (Collider boxes in collider)
            {
                Rigidbody rb = boxes.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(Random.Range(40, 60), transform.position, blastRadius);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
