using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //todo change Bindings
            Container.Bind<SpellLibrary>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerSpellCaster>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerInput>().FromComponentInHierarchy().AsSingle();
        }
    }
}