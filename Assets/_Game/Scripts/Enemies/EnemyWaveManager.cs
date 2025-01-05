using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class EnemyWaveManager : MonoBehaviour
{
    public EnemySO[] enemyPool;
    public Transform[] spawnPoints;
    private List<GameObject> activeEnemies = new();

    [Inject] private EnemyFactory _enemyFactory;

    public int maxEnemies = 10;
    void Start()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (activeEnemies.Count >= maxEnemies)
        {
            return;
        }

        EnemySO enemyData = enemyPool[Random.Range(0, enemyPool.Length)];
        GameObject enemy = _enemyFactory.Create(enemyData);
        enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        
        activeEnemies.Add(enemy);

        var health = enemy.GetComponent<Health>();
        if (health)
        {
            health.OnDeathObservable
                .Take(1)
                .Subscribe(_ => HandleEnemyDeath(health))
                .AddTo(this);
        }
    }

    private void HandleEnemyDeath(Health health)
    {
        activeEnemies.Remove(health.gameObject);
        SpawnEnemy();
    }
}
