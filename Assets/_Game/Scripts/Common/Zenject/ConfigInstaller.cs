using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace MageDefence
{
    [CreateAssetMenu(fileName = "PlayerStatsInstaller", menuName = "GameStatsInstaller")]
    public class StatsInstaller : ScriptableObjectInstaller<StatsInstaller>
    {
        public PlayerStats playerConfig;
        public EnemySpawnerConfig enemySpawnerConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerStats>().FromInstance(playerConfig).AsSingle();
            Container.Bind<PlayerStatsModel>().AsSingle();
            Container.Bind<EnemySpawnerConfig>().FromInstance(enemySpawnerConfig).AsSingle();
        }
    }
}