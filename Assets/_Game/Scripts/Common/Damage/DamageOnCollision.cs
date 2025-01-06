using UnityEngine;

namespace MageDefence
{
    [RequireComponent(typeof(Collider))]
    public class DamageOnCollision : DamagingImpl
    {
        private void OnCollisionEnter(Collision other)
        {
            ApplyDamage(other.gameObject);
        }

        private void OnCollisionStay(Collision other)
        {
            ApplyDamage(other.gameObject);
        }
    }
}