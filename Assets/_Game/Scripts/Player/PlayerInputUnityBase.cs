using System;
using UniRx;
using UnityEngine;

namespace MageDefence
{
    public abstract class PlayerInputUnityBase : IPlayerInput
    {
        public IReadOnlyReactiveProperty<Vector3> MoveDirection => _moveDirection;
        public IReadOnlyReactiveProperty<bool> SpellInput => _spellInput;
        public IObservable<int> SpellChange => _spellChange;

        protected readonly ReactiveProperty<Vector3> _moveDirection = new(Vector3.zero);
        protected readonly ReactiveProperty<bool> _spellInput = new(false);
        protected readonly Subject<int> _spellChange = new();

        public abstract void HandleInput();

        
        protected void HandleSpellChangeInput()
        {
            if (Input.GetButtonDown("Previous"))
            {
                _spellChange.OnNext(-1);
            }

            if (Input.GetButtonDown("Next"))
            {
                _spellChange.OnNext(1);
            }
        }

        protected void HandleMovementInput()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            _moveDirection.Value = input.normalized;
        }

        protected void HandleSpellInput()
        {
            _spellInput.Value = Input.GetButton("Fire1");
        }
    }
}