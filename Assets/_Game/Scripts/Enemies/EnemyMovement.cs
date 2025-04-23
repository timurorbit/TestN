using UnityEngine;
using UnityEngine.AI;

namespace MageDefence
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent _agent;
        private Transform _target;
        private const float _targetUpdateFrequency = 0.5f;
        private float _moveSpeed = 5f;

        private void Start()
        {
            InvokeRepeating(nameof(UpdateTarget), 0, _targetUpdateFrequency);
        }
    
        //todo readonly fields and coonstructor
        public void Initialize(float enemyDataSpeed, Transform targetPosition)
        {
            _moveSpeed = enemyDataSpeed;
            _agent.speed = _moveSpeed;
            _target = targetPosition;
        }

        private void UpdateTarget()
        {
            if (_target)
            {
                _agent.SetDestination(_target.position);
            }
        }
    }  
}
