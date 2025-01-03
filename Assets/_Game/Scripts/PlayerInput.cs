using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace MageDefence
{
    public class PlayerInput : MonoBehaviour
    {
        public ReactiveProperty<Vector3> MoveDirection { get; private set; } = new(Vector3.zero);
        
        public ReactiveProperty<Boolean> SpellInput { get; private set; } = new(false);

        private readonly Subject<int> _spellChange = new Subject<int>();
        public IObservable<int> SpellChange => _spellChange;


        private void Update()
        {
            HandleMovementInput();
            HandleSpellInput();
            HandleSpellChangeInput();
        }

        private void HandleSpellChangeInput()
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

        private void HandleMovementInput()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
            MoveDirection.Value = input.normalized;
        }

        private void HandleSpellInput()
        {
            SpellInput.Value = Input.GetButton("Fire1");
        }
    }  
}
