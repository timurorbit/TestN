using UnityEngine;

namespace MageDefence
{
    public abstract class DamagerImplementation : MonoBehaviour, IDamager
    {
        [SerializeField] protected float damage = 10;
        private bool _destroyOnHit;
        
        public void Initialize(float damage, bool destroyOnHit)
        {
            this.damage = damage;
            _destroyOnHit = destroyOnHit;
        }

        public void ApplyDamage(IDamageable target)
        {
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (_destroyOnHit)
            {
                Destroy(gameObject);
            }
        } 
    }
}