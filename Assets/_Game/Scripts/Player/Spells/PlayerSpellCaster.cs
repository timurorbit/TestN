using System;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class PlayerSpellCaster : MonoBehaviour
    {
        [SerializeField]
        private Transform _spellSpawnOffset;
        private ISpellLibrary _spellLibrary;

        private float _cooldownTimer;

        [Inject]
        public void Construct(ISpellLibrary spellLibrary)
        {
            _spellLibrary = spellLibrary;
        }

        private void Awake()
        {
            if (!_spellSpawnOffset)
            {
                _spellSpawnOffset = transform;
            }
        }

        private void Start()
        {
            _spellLibrary.LoadNewLibrary();
        }

        private void Update()
        {
            UpdateCooldown();
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

        public void ChangeSpell(int indexChange)
        {
            _spellLibrary.ChangeActiveSpellByIndexChange(indexChange);
        }

        private void UpdateCooldown()
        {
            if (_cooldownTimer > 0)
            {
                _cooldownTimer -= Time.deltaTime;
            }
        }

        //todo Pooling

        private void SpawnSpell(Spell spell)
        {
            if (!spell || !spell.projectilePrefab)
            {
                return;
            }

            var spellInstance =
                Instantiate(spell.projectilePrefab, _spellSpawnOffset.position, _spellSpawnOffset.rotation);
            
            if (spellInstance.TryGetComponent<ProjectileMovement>(out var movement))
            {
                movement.Initialize(spell.projectileSpeed);
            }
            
            if (spellInstance.TryGetComponent<DamageOnTrigger>(out var damage))
            {
                damage.Initialize(spell.damage, true);
            }
            
            if (spellInstance.TryGetComponent<SelfDestruct>(out var destruct))
            {
                destruct.Initialize(spell.lifetime);
            }
        }
    }
}