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
            _spellLibrary.LoadLibrary();
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

        //todo Pooling
        private void SpawnSpell(Spell spell)
        {
            if (!spell || !spell.projectilePrefab)
            {
                return;
            }

            var spellInstance =
                Instantiate(spell.projectilePrefab, _spellSpawnOffset.position, _spellSpawnOffset.rotation);

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
            _spellLibrary.ChangeActiveSpellByIndexChange(indexChange);
        }
    }
}