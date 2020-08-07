using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    [SerializeField]
    private Transform sphericalPart;
    [SerializeField]
    private Transform canionPart;
    [SerializeField]
    private float speedRotation = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(trShoot.position, player.transform.position, Color.red);
        if (life > 0)
        {
            Vector3 playerPostion = player.transform.position;
            Utils.SlowLookAt(speedRotation, sphericalPart, playerPostion, Utils.Axys.y);
            Utils.SlowLookAt(speedRotation, canionPart, playerPostion, Utils.Axys.x);

            Vector3 eulerCanionAngles = canionPart.localEulerAngles;
            eulerCanionAngles.x = 0.0f;
            eulerCanionAngles.z = -90.0f;
            canionPart.localEulerAngles = eulerCanionAngles;
            Shoot();
        }
        else
        {
            Dead();
        }
    }
}
