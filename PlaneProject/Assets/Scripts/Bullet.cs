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

    public virtual void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponentInParent<Character>() != null){
            Character character = collision.gameObject.GetComponentInParent<Character>();
            if (character.CompareTag(tagCollision))
            {
                character.UpdateLife(character.life - damage);
            }
        }
        
        //Utils.InstantiateParticle(particle, collision.contacts[0].normal,collision.contacts[0].point,collision.gameObject.transform);
        Utils.InstantiateParticle(particle, transform.position.normalized,
            collision.transform.position,collision.gameObject.transform);
        Destroy(this.gameObject);
    }
}
