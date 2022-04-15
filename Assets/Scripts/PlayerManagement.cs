using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoSingleton<PlayerManagement>
{
    [SerializeField] private GameObject cannonMoveY;
    [SerializeField] private GameObject cannonMoveX;
    [SerializeField] public Transform shotPoint;

    private Vector3 mousePrevPosition = Vector3.zero;
    private Vector3 mouseDeltaPos = Vector3.zero;

    [SerializeField] private float sensivitiy;
    [SerializeField] private int maxShotCount;

    [SerializeField] private AudioSource camSound;
    [SerializeField] private AudioClip explosionAudio;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.Instance.isPaused)
        {
            UIManager.Instance.ShotCountText(maxShotCount);

            //shooting doll
            if (Input.GetMouseButtonUp(0) && maxShotCount > 0)
            {
                maxShotCount --;
                UIManager.Instance.ShotCountText(maxShotCount);

                var ball = ObjectPooler.Instance.GetPooledObject("Ball");
                ball.transform.position = shotPoint.transform.position;
                ball.transform.rotation = Quaternion.Euler(0, 0, 0);
                ball.SetActive(true);

                camSound.PlayOneShot(explosionAudio);
            }

            //if 
            if(maxShotCount <= 0 && GameManager.Instance.progress < 100)
            {
                Invoke("CallRestartUI", 5f);
            }

            //cannon's aim (rotating)
            if (Input.GetMouseButton(0))
            {
                mouseDeltaPos = Input.mousePosition - mousePrevPosition;

                //Y axis
                if (Vector3.Dot(transform.up, Vector3.up) >= 0)
                {
                    cannonMoveY.transform.Rotate(transform.forward, +Vector3.Dot(mouseDeltaPos, Camera.main.transform.right) * sensivitiy, Space.World);
                }
                else
                {
                    cannonMoveY.transform.Rotate(transform.forward * -1, -Vector3.Dot(mouseDeltaPos, Camera.main.transform.right) * sensivitiy, Space.World);
                }

                //Y axis
                cannonMoveX.transform.Rotate(Camera.main.transform.up, -Vector3.Dot(mouseDeltaPos, Camera.main.transform.up) * sensivitiy, Space.Self);
            }
            mousePrevPosition = Input.mousePosition;
        }
    }
}
