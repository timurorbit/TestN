using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour, IDamageable
{
    protected float currentHealth = 100f;
    public float maxHealth = 100f;

    [Range(0f, 1f)] public float armor;

    private Subject<Health> _onDeath = new();
    public IObservable<Health> OnDeathObservable => _onDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    
    public void Initialize(float enemyDataHealth, float enemyDataArmor)
    {
        SetMaxHealth(enemyDataHealth);
        armor = enemyDataArmor;
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

    public virtual void takeDamage(float damage)
    {
        var effectiveDamage = damage * (1 - armor);
        currentHealth -= effectiveDamage;
        currentHealth = Mathf.Max(currentHealth, 0f);
        Debug.Log($"Took {effectiveDamage} damage. Health remaining: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Died");
        _onDeath.OnNext(this);
        _onDeath.OnCompleted();
        
        Destroy(gameObject);
    }
}