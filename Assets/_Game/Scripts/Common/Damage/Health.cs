using System;
using UniRx;
using UnityEngine;

namespace MageDefence
{
    public class Health : MonoBehaviour, IDamageable
    {
        [Range(0f, 1f)] public float armor;
        
        private float currentHealth = 100f;
        private float maxHealth = 100f;


        private Subject<IDamageable> _onDeath = new();
        public IObservable<IDamageable> OnDeathObservable => _onDeath;

        public virtual void Initialize(float dataHealth, float dataArmor)
        {
            SetMaxHealth(dataHealth);
            armor = dataArmor;
        }

        public virtual void TakeDamage(float damage)
        {
            var effectiveDamage = DamageUtils.CalculateEffectiveDamage(damage, armor);
            currentHealth -= effectiveDamage;
            Debug.Log($"Took {effectiveDamage} damage. Health remaining: {currentHealth}");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void SetMaxHealth(float health)
        {
            if (health <= 0)
            {
                Debug.Log($"Invalid max health value: {health}.");
            }

            maxHealth = health;
            currentHealth = health;
        }

        private void Die()
        {
            Debug.Log("Died");
            _onDeath.OnNext(this);
            _onDeath.OnCompleted();

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _onDeath.Dispose();
        }
    }
}