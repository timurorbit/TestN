using UnityEngine;

namespace MageDefence
{
    public abstract class DamagingImpl : MonoBehaviour, IDamaging
    {
        [SerializeField] protected float damage = 10;
        public bool destroyOnHit;
        
        public void Initialize(float damage, bool destroyOnHit)
        {
            this.damage = damage;
            this.destroyOnHit = destroyOnHit;
        }

        public void ApplyDamage(GameObject target)
        {
            var damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.takeDamage(damage);
                if (destroyOnHit)
                {
                    Destroy(gameObject);
                }
            }
        } 
    }
}