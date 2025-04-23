using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        private bool isInvulnerable;
        private PlayerStatsModel playerStatsModel;

        private readonly Subject<IDamageable> _onDeath = new();
        public IObservable<IDamageable> OnDeathObservable => _onDeath;

        public void TakeDamage(float damage)
        {
            if (isInvulnerable)
            {
                return;
            }

            isInvulnerable = true;
            var effectiveDamage = DamageUtils.CalculateEffectiveDamage(damage, playerStatsModel.Armor.Value);
            playerStatsModel.Health.Value -= effectiveDamage;

            Debug.Log($"Player Took {effectiveDamage} damage. Health remaining: {playerStatsModel.Health.Value}");

            if (playerStatsModel.Health.Value <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(InvulnerabilityReset());
            }
        }

        [Inject]
        public void Construct(PlayerStatsModel playerStats)
        {
            playerStatsModel = playerStats;
        }

        private IEnumerator InvulnerabilityReset()
        {
            yield return new WaitForSeconds(playerStatsModel.InvulnerabilityTime.Value);
            isInvulnerable = false;
        }

        private void Die()
        {
            Debug.Log("Player Died");
            _onDeath.OnNext(this);
            _onDeath.OnCompleted();

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _onDeath.Dispose();
        }
    }
}