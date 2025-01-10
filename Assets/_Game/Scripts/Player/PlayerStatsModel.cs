using UniRx;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class PlayerStatsModel
    {
        [Header("In Game Stats")]
        public readonly ReactiveProperty<float> MoveSpeed;
        
        public readonly ReactiveProperty<float> Health;

        public readonly ReactiveProperty<float> Armor;

        public readonly ReactiveProperty<float> RotationSpeed;

        public readonly ReactiveProperty<float> InvulnerabilityTime;

        private readonly PlayerStats _playerStats;

        [Inject]
        public PlayerStatsModel([Inject(Optional = true)]PlayerStats playerStats)
        {
            _playerStats = playerStats;
            if (!_playerStats)
            {
                Debug.LogWarning("PlayerStats not set, using default player stats");
            }
            MoveSpeed = new ReactiveProperty<float>();
            Health = new ReactiveProperty<float>();
            Armor = new ReactiveProperty<float>();
            RotationSpeed = new ReactiveProperty<float>();
            InvulnerabilityTime = new ReactiveProperty<float>();
            ResetToBase();
        }

        public void ResetToBase()
        {
            if (!_playerStats)
            {
                ResetToDefaults();
                return;
            }
            
            MoveSpeed.Value = _playerStats.moveSpeed;
            Health.Value = _playerStats.health;
            Armor.Value = _playerStats.armor;
            RotationSpeed.Value = _playerStats.rotationSpeed;
            InvulnerabilityTime.Value = _playerStats.invulnerabilityTime;
        }

        private void ResetToDefaults()
        {
            MoveSpeed.Value = 800f;
            Health.Value = 100f;
            Armor.Value = 0f;
            RotationSpeed.Value = 15f;
            InvulnerabilityTime.Value = 1f;
        }
    }
}