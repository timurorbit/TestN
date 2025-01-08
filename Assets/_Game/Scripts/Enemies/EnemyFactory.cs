using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class EnemyFactory : PlaceholderFactory<EnemySO, GameObject>
    {
        private readonly DiContainer _container;
    
        private readonly ITargetLocator _targetLocator;

        public EnemyFactory(DiContainer container, [Inject(Id = "PlayerLocator")]ITargetLocator targetLocator) 
        {
            _container = container;
            _targetLocator = targetLocator;
        }
        public override GameObject Create(EnemySO enemySoData)
        {
            GameObject enemyInstance = _container.InstantiatePrefab(enemySoData.prefab);

            var movement = enemyInstance.GetComponent<EnemyMovement>();
            if (movement)
            {
                Transform target = _targetLocator.GetTarget(enemyInstance.transform.position);
                movement.Initialize(enemySoData.speed, target);
            }
            enemyInstance.GetComponent<Health>()?.Initialize(enemySoData.health, enemySoData.armor);
            enemyInstance.GetComponent<DamagingImpl>()?.Initialize(enemySoData.damage, false);

            return enemyInstance;
        }
    } 
}
