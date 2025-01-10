using System;
using System.Collections.Generic;
using MageDefence;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySO> _enemyPool;

    [SerializeField] private Transform[] _spawnPoints;
    private readonly List<GameObject> _activeEnemies = new();
    [FormerlySerializedAs("maxEnemies")] [SerializeField]
    private int _maxEnemies;

    private EnemyFactory _enemyFactory;
    private EnemySpawnerConfig _spawnerConfig;
    
    [Inject]
    public void Construct([Inject(Optional = true)]EnemySpawnerConfig spawnerConfig, EnemyFactory enemyFactory)
    {
        _spawnerConfig = spawnerConfig;
        _enemyFactory = enemyFactory;
    }

    private void Awake()
    {
        if (!_spawnerConfig)
        {
            Debug.LogWarning("SpawnerConfig is missing in the scene");
        }
    }

    void Start()
    {
        if (_spawnerConfig)
        {
            _enemyPool = _spawnerConfig.EnemyPool;
            _maxEnemies = _spawnerConfig.MaxEnemies;
        }
        for (int i = 0; i < _maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    //todo Pooling
    private void SpawnEnemy()
    {
        if (_activeEnemies.Count >= _maxEnemies)
        {
            return;
        }

        EnemySO enemyData = _enemyPool[Random.Range(0, _enemyPool.Count)];
        GameObject enemy = _enemyFactory.Create(enemyData);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

        _activeEnemies.Add(enemy);

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
        _activeEnemies.Remove(health.gameObject);
        SpawnEnemy();
    }
}