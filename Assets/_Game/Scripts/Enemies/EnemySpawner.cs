using System.Collections;
using System.Collections.Generic;
using MageDefence;
using UniRx;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    public EnemySO[] enemyPool;
    public Transform[] spawnPoints;
    private List<GameObject> activeEnemies = new();

    private EnemyFactory _enemyFactory;
    private EnemySpawnerConfig _spawnerConfig;

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
    
    [Inject]
    public void Construct(EnemySpawnerConfig spawnerConfig, EnemyFactory enemyFactory)
    {
        _spawnerConfig = spawnerConfig;
        _enemyFactory = enemyFactory;
    }

    private void HandleEnemyDeath(Health health)
    {
        activeEnemies.Remove(health.gameObject);
        SpawnEnemy();
    }
}
