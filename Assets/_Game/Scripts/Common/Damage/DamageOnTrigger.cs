using UnityEngine;

namespace MageDefence
{
    [RequireComponent(typeof(Collider))]
    public class DamageOnTrigger : DamagerImplementation
    {
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.TryGetComponent<IDamageable>(out var damageable);
            ApplyDamage(damageable);
        }
    }
}