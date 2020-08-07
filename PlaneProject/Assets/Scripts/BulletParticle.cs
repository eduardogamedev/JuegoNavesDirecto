using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;
    [SerializeField]
    private GameObject bulletHole;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        Invoke("CleanParticle", particleSystem.duration);
    }

    private void CleanParticle()
    {
        Instantiate(bulletHole, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
