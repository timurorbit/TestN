using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBaseMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    public float targetUpdateFrequency = 0.5f;
    public float moveSpeed = 5f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0, targetUpdateFrequency);
    }

    void UpdateTarget()
    {
        if (target)
        {
            agent.SetDestination(target.position);
        }
    }
    
}
