using UnityEngine;
using Zenject;

namespace MageDefence
{
    [CreateAssetMenu(fileName = "PlayerStatsInstaller", menuName = "GameStatsInstaller")]
    public class StatsInstaller : ScriptableObjectInstaller<StatsInstaller>
    {
        [SerializeField]
        private PlayerStats playerConfig;
        [SerializeField]
        private EnemySpawnerConfig enemySpawnerConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerStats>().FromInstance(playerConfig).AsSingle();
            Container.Bind<PlayerStatsModel>().AsSingle();
            Container.Bind<EnemySpawnerConfig>().FromInstance(enemySpawnerConfig).AsSingle();
        }
    }
}