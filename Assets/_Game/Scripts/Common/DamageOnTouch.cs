using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class DamageOnTouch : MonoBehaviour
{
    public float damage;
    public bool destroyOnHit;

    public void Initialize(float damage, bool destroyOnHit)
    {
        this.damage = damage;
        this.destroyOnHit = destroyOnHit;
    }
    private  void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        
        if (damageable != null)
        {
            damageable.takeDamage(damage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}
