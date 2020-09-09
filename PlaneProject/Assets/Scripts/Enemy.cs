using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Transform trShoot;
    [SerializeField]
    private float timeToAttackMin = 1f;
    [SerializeField]
    private float timeToAttackMax = 15f;
    [SerializeField]
    private float forceBullet = 250f;
    [SerializeField]
    private GameObject bulletTank;
    [SerializeField]
    private AudioSource audioSourceShoot;
    [SerializeField]
    private ParticleSystem particleSystemTank;
    [SerializeField]
    private GameObject spark;

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public bool shoot = false;
    private float timeToAttack = 0;

    public IEnumerator ShootNumerator()
    {
        yield return new WaitForSeconds(timeToAttack);
        Utils.InstantiateBullet(bulletTank, trShoot, forceBullet, 15, trShoot.forward);
        audioSourceShoot.Play();
        particleSystemTank.Play();
        spark.SetActive(true);
        shoot = false;
    }

    public void Shoot()
    {
        if (!shoot)
        {
            shoot = true;
            timeToAttack = Random.Range(timeToAttackMin, timeToAttackMax);
            StartCoroutine(ShootNumerator());
        }
    }
}
