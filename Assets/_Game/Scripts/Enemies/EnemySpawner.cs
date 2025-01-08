using System.Collections.Generic;
using MageDefence;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySO> _enemyPool;

    [SerializeField] private Transform[] _spawnPoints;
    private readonly List<GameObject> _activeEnemies = new();

    private EnemyFactory _enemyFactory;
    private EnemySpawnerConfig _spawnerConfig;

    void Start()
    {
        _enemyPool = _spawnerConfig.EnemyPool;
        for (int i = 0; i < _spawnerConfig.MaxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    //todo Pooling
    private void SpawnEnemy()
    {
        if (_activeEnemies.Count >= _spawnerConfig.MaxEnemies)
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

    [Inject]
    public void Construct(EnemySpawnerConfig spawnerConfig, EnemyFactory enemyFactory)
    {
        _spawnerConfig = spawnerConfig;
        _enemyFactory = enemyFactory;
    }

    private void HandleEnemyDeath(Health health)
    {
        _activeEnemies.Remove(health.gameObject);
        SpawnEnemy();
    }
}