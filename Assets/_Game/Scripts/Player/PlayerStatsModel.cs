using UniRx;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class PlayerStatsModel
    {
        [Header("In Game Stats")]
        public ReactiveProperty<float> MoveSpeed;
        
        public ReactiveProperty<float> Health;

        public ReactiveProperty<float> Armor;

        public ReactiveProperty<float> RotationSpeed;

        public ReactiveProperty<float> InvulnerabilityTime;

        private readonly PlayerStats _playerStats;

        [Inject]
        public PlayerStatsModel(PlayerStats playerStats)
        {
            _playerStats = playerStats;
            Initialize();
        }
        
        private void Initialize()
        {
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