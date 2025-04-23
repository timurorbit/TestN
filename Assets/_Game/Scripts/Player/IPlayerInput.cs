using System;
using UniRx;
using UnityEngine;

namespace MageDefence
{
    public interface IPlayerInput
    {
        IReadOnlyReactiveProperty<Vector3> MoveDirection { get; }
        IReadOnlyReactiveProperty<bool> SpellInput { get; }
        IObservable<int> SpellChange { get; }
        void HandleInput();
    }
}