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
        public PlayerStatsModel(PlayerStats playerStats)
        {
            _playerStats = playerStats;
            MoveSpeed = new ReactiveProperty<float>(_playerStats.moveSpeed);
            Health = new ReactiveProperty<float>(_playerStats.health);
            Armor = new ReactiveProperty<float>(_playerStats.armor);
            RotationSpeed = new ReactiveProperty<float>(_playerStats.rotationSpeed);
            InvulnerabilityTime = new ReactiveProperty<float>(_playerStats.invulnerabilityTime);
        }

        public void ResetToBase()
        {
            MoveSpeed.Value = _playerStats.moveSpeed;
            Health.Value = _playerStats.health;
            Armor.Value = _playerStats.armor;
            RotationSpeed.Value = _playerStats.rotationSpeed;
            InvulnerabilityTime.Value = _playerStats.invulnerabilityTime;
        }
    }
}