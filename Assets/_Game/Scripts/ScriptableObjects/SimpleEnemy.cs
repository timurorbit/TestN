using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/EnemyBase")]
public class SimpleEnemy : ScriptableObject
{
    public string enemyName;
    public GameObject prefab;
    public float health;
    public float damage;
    [Range(1f, 25f)] public float speed;
    [Range(0f, 1f)] public float armor;
    
    [TextArea]
    public string description;

    private void OnValidate()
    {
        health = Mathf.Clamp(health, 1f, 5000f);
        damage = Mathf.Clamp(damage, 1f, 1000f);
        speed = Mathf.Clamp(speed, 1f, 25f);
    }
}