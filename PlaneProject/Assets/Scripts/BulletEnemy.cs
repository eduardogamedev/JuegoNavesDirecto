using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Camera.main != null)
        {
            Camera.main.GetComponent<CameraFollow>().ShakeCamera();
        }
        base.OnCollisionEnter(collision);
    }
}
