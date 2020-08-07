using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int maxLife = 100;
    [HideInInspector]
    public int life;

    // Start is called before the first frame update
    void Awake()
    {
        life = maxLife;
    }

    public virtual void UpdateLife(int newLife)
    {
        life = newLife;
        
    }

    public virtual void Dead()
    {
        UpdateLife(0);
        Destroy(this.gameObject);
    }
}
