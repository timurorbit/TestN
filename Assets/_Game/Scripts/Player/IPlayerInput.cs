using System;
using UniRx;
using UnityEngine;

namespace MageDefence
{
    public interface IPlayerInput
    {
        ReactiveProperty<Vector3> MoveDirection { get; }
        ReactiveProperty<bool> SpellInput { get; }
        IObservable<int> SpellChange { get; }

        void HandleSpellChangeInput();
        void HandleMovementInput();
        void HandleSpellInput();
        
        void HandleInput()
        {
            HandleMovementInput();
            HandleSpellInput();
            HandleSpellChangeInput();
        }
    }
}