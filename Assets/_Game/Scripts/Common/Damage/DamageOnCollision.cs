using UnityEngine;

namespace MageDefence
{
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