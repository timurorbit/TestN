using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifetime = 5f;

    public void Initialize(float spellLifetime)
    {
        lifetime = spellLifetime;
        Destroy(gameObject, lifetime);
    }
}
