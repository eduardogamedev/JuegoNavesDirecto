using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private string tagCollision;

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagCollision) && collision.gameObject.GetComponent<Character>() != null)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            character.UpdateLife(character.life - damage);
        }
        Utils.InstantiateParticle(particle, collision.contacts[0].normal,collision.contacts[0].point,collision.gameObject.transform);
        Destroy(this.gameObject);
    }
}
