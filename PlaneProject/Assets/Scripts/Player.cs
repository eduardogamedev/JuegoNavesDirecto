using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character 
{

    [SerializeField]
    private float velocityMovement = 50;
    [SerializeField]
    private float velocityForward = 8;
    [SerializeField]
    private float velocityRotation = 8;
    [SerializeField]
    private float speedDash = 10;
    [SerializeField]
    private Slider lifeBar;
    [SerializeField]
    private CameraFollow cameraFollow;

    private ActionPlayer actionPlayer;

    

    // Start is called before the first frame update
    void Start()
    {
        actionPlayer = GetComponent<ActionPlayer>();
        lifeBar.value = life;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life > 0)
        {
            Movement();
        }
    }

    void Movement()
    {
        float _velocityForward = velocityForward * Time.deltaTime;

        transform.Translate(0, 0, _velocityForward);

        if (!actionPlayer.doDash)
        {
            float verticalRotation = Input.GetAxis("Vertical") * velocityRotation * Time.deltaTime;
            float horizontalRotation = Input.GetAxis("Horizontal") * velocityRotation * Time.deltaTime;
            transform.Rotate(-verticalRotation, horizontalRotation, 0);
            Utils.ResetZ(transform);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        cameraFollow.ShakeCamera();
        UpdateLife(life - 10);
        Vector3 normalContact = collision.contacts[0].normal;
        transform.Rotate(Vector3.up*normalContact.y*180);
    }

    public override void UpdateLife(int newLife)
    {
        base.UpdateLife(newLife);
        lifeBar.value = life;
    }

    public override void Dead()
    {
        base.Dead();
    }
}
