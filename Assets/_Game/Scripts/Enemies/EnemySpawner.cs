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

    [FormerlySerializedAs("maxEnemies")] [SerializeField]
    private int _maxEnemies;


    private readonly List<GameObject> _activeEnemies = new();
    private EnemySpawnerConfig _spawnerConfig;
    private ITargetLocator _targetLocator;
    
    [Inject]
    public void Construct(EnemySpawnerConfig spawnerConfig, [Inject(Id = "PlayerLocator")]ITargetLocator targetLocator)
    {
        _spawnerConfig = spawnerConfig;
        _targetLocator = targetLocator;
    }

    private void Awake()
    {
        if (!_spawnerConfig)
        {
            Debug.LogWarning("SpawnerConfig is missing in the scene");
        }
    }

    private void Start()
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

        var enemyData = _enemyPool[Random.Range(0, _enemyPool.Count)];
        var enemy = CreateEnemyFromData(enemyData);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        _activeEnemies.Add(enemy);
    }

    private GameObject CreateEnemyFromData(EnemySO enemyData)
    {
        var enemyInstance = Instantiate(enemyData.prefab);
        
        if (enemyInstance.TryGetComponent<EnemyMovement>(out var movement))
        {
            var target = _targetLocator.GetTarget(enemyInstance.transform.position);
            movement.Initialize(enemyData.speed, target);
        }

        if (enemyInstance.TryGetComponent<Health>(out var health))
        {
            health.Initialize(enemyData.health, enemyData.armor);
            health.OnDeathObservable
                .Take(1)
                .Subscribe(_ => HandleEnemyDeath(health))
                .AddTo(this);
        }

        if (enemyInstance.TryGetComponent<DamagerImplementation>(out var damager))
        {
          damager.Initialize(enemyData.damage, false);  
        }
        return enemyInstance;
    }

    private void HandleEnemyDeath(Health health)
    {
        _activeEnemies.Remove(health.gameObject);
        SpawnEnemy();
    }
}