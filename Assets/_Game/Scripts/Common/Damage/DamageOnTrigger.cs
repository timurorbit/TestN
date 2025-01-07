using UnityEngine;

namespace MageDefence
{
    [RequireComponent(typeof(Collider))]
    public class DamageOnTrigger : DamagingImpl
    {
        private void OnTriggerEnter(Collider other)
        {
            ApplyDamage(other.gameObject);
        }
    }
}