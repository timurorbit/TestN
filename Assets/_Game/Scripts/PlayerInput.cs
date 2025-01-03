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


        private void Update()
        {
            HandleMovementInput();
            HandleSpellInput();
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
