using System.Collections.Generic;
using UnityEngine;

namespace MageDefence
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Enemies/EnemySpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [SerializeField] private List<EnemySO> enemyPool;
        [SerializeField, Min(1)] private int maxEnemies = 10;

        public List<EnemySO> EnemyPool => enemyPool;

        public int MaxEnemies
        {
            get => maxEnemies;
            set => maxEnemies = Mathf.Max(1, value);
        }

        private void OnValidate()
        {
            if (enemyPool == null)
            {
                enemyPool = new List<EnemySO>();
            }
            
            maxEnemies = Mathf.Max(1, maxEnemies);
            enemyPool.RemoveAll(enemy => !enemy);
        }
    }
}