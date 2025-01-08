using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    private float _speed;
    private Rigidbody _rb;
    
    public void Initialize(float spellSpeed)
    {
        _speed = spellSpeed;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * _speed;
    }

    public void SetDirection(Vector3 dir)
    {
        _rb.velocity = dir * _speed;
    }
}
