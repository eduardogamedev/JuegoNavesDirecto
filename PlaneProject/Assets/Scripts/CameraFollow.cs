using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform targetLookAt;
    public Transform targetFreeCamera;
    public Vector3 offset;
    public CameraShake cameraShake;
    public float velocityFollow = 2;
    public bool lookAt = true;
    public float speedLookAt = 2;
    public float speedRotation = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float verticalRotation = Input.GetAxis("Mouse Y");
        float horizontalRotation = Input.GetAxis("Mouse X");

        if(verticalRotation != 0 || horizontalRotation != 0)
        {
            transform.RotateAround(targetFreeCamera.position, Vector3.right, horizontalRotation * speedRotation);
            transform.RotateAround(targetFreeCamera.position, Vector3.up, verticalRotation * speedRotation);

            if (lookAt)
            {
                var rotation = Quaternion.LookRotation(targetFreeCamera.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speedLookAt);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, velocityFollow * Time.deltaTime);
            if (lookAt)
            {
                transform.rotation = Quaternion.LookRotation(targetLookAt.transform.forward, transform.up);
                Utils.ResetZ(transform);
            }
            
        }
        
    }

    public void ShakeCamera()
    {
        if (!cameraShake.enabled)
        {

            cameraShake.enabled = true;
        }
        cameraShake.shakeDuration = 1;
    }
}
