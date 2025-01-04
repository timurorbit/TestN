using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour, IDamageable
{
    private float currentHealth = 100f;
    public float maxHealth = 100f;

    [Range(0f, 1f)] public float armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = health;
    }

    public void takeDamage(float damage)
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
        Destroy(gameObject);
    }
}