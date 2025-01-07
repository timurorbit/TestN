using UnityEngine;
using UnityEngine.AI;

namespace MageDefence
{
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
        }

        private void Start()
        {
            InvokeRepeating(nameof(UpdateTarget), 0, targetUpdateFrequency);
        }
    
        public void Initialize(float enemyDataSpeed, Transform targetPosition)
        {
            moveSpeed = enemyDataSpeed;
            agent.speed = moveSpeed;
            target = targetPosition;
        }

        private void UpdateTarget()
        {
            if (target)
            {
                agent.SetDestination(target.position);
            }
        }
    }  
}
