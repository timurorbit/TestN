using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInput>().FromComponentInHierarchy().AsSingle();
        }
    }
}