using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageOnTouch : MonoBehaviour
{
    public float damage;

    public void Initialize(float spellDamage)
    {
        damage = spellDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        // todo apply Damage
    }
}
