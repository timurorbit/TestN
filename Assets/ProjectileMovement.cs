using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;
    
    public void Initialize(float spellSpeed)
    {
        speed = spellSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * speed;
    }

    public void SetDirection(Vector3 dir)
    {
        _rb.velocity = dir * speed;
    }
}
