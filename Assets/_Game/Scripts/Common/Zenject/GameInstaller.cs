using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerStatsModel>().AsSingle();

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
            
            Container.Bind<IResourceLoader>()
                .To<ResourceLoaderImplementation>()
                .AsCached();

            Container.Bind<ISpellLibrary>()
                .To<SpellLibraryResources>()
                .AsCached();
        }
    }
}