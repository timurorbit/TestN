using UnityEngine;

namespace MageDefence
{
    [RequireComponent(typeof(Collider))]
    public class DamageOnCollision : DamagerImplementation
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                ApplyDamage(damageable);
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                ApplyDamage(damageable);
            }
        }
    }
}