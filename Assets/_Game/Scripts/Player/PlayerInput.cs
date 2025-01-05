using System;
using UniRx;
using UnityEngine;

namespace MageDefence
{
    public class PlayerInput : IPlayerInput
    {
        public ReactiveProperty<Vector3> MoveDirection { get; } = new(Vector3.zero);
        
        public ReactiveProperty<bool> SpellInput { get; } = new(false);

        private readonly Subject<int> _spellChange = new();
        public IObservable<int> SpellChange => _spellChange;

        public void HandleSpellChangeInput()
        {
            //todo change input
            if (Input.GetKeyDown(KeyCode.Q))
            {
               _spellChange.OnNext(-1); 
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _spellChange.OnNext(1);
            }
        }

        public void HandleMovementInput()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
            MoveDirection.Value = input.normalized;
        }

        public void HandleSpellInput()
        {
            SpellInput.Value = Input.GetButton("Fire1");
        }
    }  
}
