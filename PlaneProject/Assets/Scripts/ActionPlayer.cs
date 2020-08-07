using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPlayer : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField]
    private Collider[] colliders;
    [Header("Shoot")]
    [SerializeField]
    private Transform[] posGuns;
    [SerializeField]
    private GameObject bulletPlane;
    [SerializeField]
    private float shootTime=1;
    [SerializeField]
    private float forceBullet = 250f;
    [SerializeField]
    private AudioSource audioSourceShoot;
    [Header("Zoom")]
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Camera zoomCamera;
    [SerializeField]
    private Image imgPointer;

    [HideInInspector]
    public bool doDash = false;

    private Animator animator;
    private Rigidbody rb;
    private bool shooting = false;
    private string currentDash = "";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Actions();
    }

    void Actions()
    {
        if (Input.GetButtonDown("DashLateralLeft"))
        {
            currentDash = "dashLeft";
            StartDash();
        }
        if (Input.GetButtonDown("DashLateralRight"))
        {
            currentDash = "dashRight";
            StartDash();
        }
        if (Input.GetButton("Fire") && !shooting)
        {
            shooting = true;
            if (!audioSourceShoot.isPlaying)
            {
                audioSourceShoot.Play();
            }
            StartCoroutine(Shoot());
        }
        if (Input.GetButton("Zoom"))
        {
            mainCamera.enabled = false;
            zoomCamera.enabled = true;
            imgPointer.enabled = true;
        }
        if (Input.GetButtonUp("Zoom"))
        {
            mainCamera.enabled = true;
            zoomCamera.enabled = false;
            imgPointer.enabled = false;
        }
    }


    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootTime);
        foreach (Transform trGun in posGuns)
        {
            Utils.InstantiateBullet(bulletPlane, trGun, forceBullet, 15, transform.forward);
            trGun.gameObject.SetActive(true);
        }
        shooting = false;
    }

    private void StartDash()
    {
        doDash = true;
        rb.detectCollisions = false;
        animator.SetBool(currentDash, true);
    }

    private void EndDash()
    {
        doDash = false;
        rb.detectCollisions = true;
        animator.SetBool(currentDash, false);
    }
}
