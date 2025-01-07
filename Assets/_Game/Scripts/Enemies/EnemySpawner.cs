using System;
using System.Collections;
using System.Collections.Generic;
using MageDefence;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemySO> enemyPool;
    public Transform[] spawnPoints;
    private List<GameObject> activeEnemies = new();

    private EnemyFactory _enemyFactory;
    private EnemySpawnerConfig _spawnerConfig;
    void Start()
    {
        for (int i = 0; i < _spawnerConfig.MaxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void Awake()
    {
        enemyPool = _spawnerConfig.EnemyPool;
    }

    private void SpawnEnemy()
    {
        if (activeEnemies.Count >= _spawnerConfig.MaxEnemies)
        {
            return;
        }

        EnemySO enemyData = enemyPool[Random.Range(0, enemyPool.Count)];
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
