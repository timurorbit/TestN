using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

            Container.BindFactory<EnemySO, GameObject, EnemyFactory>()
                .To<GameObject>()
                .FromFactory<EnemyFactory>();

            Container.Bind<ITargetLocator>()
                .WithId("PlayerLocator")
                .To<TargetLocatorClosest>()
                .AsCached();
            
            Container.Bind<ITargetLocator>()
                .WithId("EnemyLocator")
                .To<TargetLocatorClosest>()
                .AsCached();
            
            Container.Bind<IPlayerInput>()
                .To<PlayerInput>()
                .AsSingle();
            
            //todo change Bindings
            Container.Bind<SpellLibrary>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerSpellCaster>().FromComponentInHierarchy().AsSingle();
        }
    }
}