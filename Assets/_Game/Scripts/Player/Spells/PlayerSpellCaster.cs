using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    [RequireComponent(typeof(SpellLibrary))]
    public class PlayerSpellCaster : MonoBehaviour
    {
        public Transform spellSpawnOffset;
        private SpellLibrary _spellLibrary;

        private float _cooldownTimer;

        [Inject]
        public void Construct(SpellLibrary spellLibrary)
        {
            _spellLibrary = spellLibrary;
        }
        private void Awake()
        {
            if (spellSpawnOffset == null)
            {
                spellSpawnOffset = transform;
            }
        }

        private void Update()
        {
            UpdateCooldown();
        }

        private void UpdateCooldown()
        {
            if (_cooldownTimer > 0)
            {
                _cooldownTimer -= Time.deltaTime;
            }
        }

        public void CastSpell()
        {
            if (_cooldownTimer > 0 || !_spellLibrary.ActiveSpell)
            {
                return;
            }

            Spell activeSpell = _spellLibrary.ActiveSpell;

            SpawnSpell(activeSpell);
            
            _cooldownTimer = _spellLibrary.ActiveSpell.cooldown;
        }

        private void SpawnSpell(Spell spell)
        {
            if (!spell || !spell.projectilePrefab)
            {
                return;
            } 
            
            var spellInstance = Instantiate(spell.projectilePrefab, spellSpawnOffset.position, spellSpawnOffset.rotation);
            
            ProjectileMovement movement = spellInstance.GetComponent<ProjectileMovement>();
            if (movement)
            {
                movement.Initialize(spell.projectileSpeed);
            }
            
            DamageOnTrigger damage = spellInstance.GetComponent<DamageOnTrigger>();
            if (damage)
            {
                damage.Initialize(spell.damage, true);
            }

            SelfDestruct destruct = spellInstance.GetComponent<SelfDestruct>();
            if (destruct)
            {
                destruct.Initialize(spell.lifetime);
            }
        }

        public void ChangeSpell(int indexChange)
        {
            _spellLibrary.ChangeSpellByIndexChange(indexChange);
        }
    }   
}
