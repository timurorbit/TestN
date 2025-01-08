using UnityEngine;

namespace MageDefence
{
    public abstract class DamagingImpl : MonoBehaviour, IDamaging
    {
        [SerializeField] protected float damage = 10;
        private bool _destroyOnHit;
        
        public void Initialize(float damage, bool destroyOnHit)
        {
            this.damage = damage;
            _destroyOnHit = destroyOnHit;
        }

        public void ApplyDamage(GameObject target)
        {
            var damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            if (_destroyOnHit)
            {
                Destroy(gameObject);
            }
        } 
    }
}