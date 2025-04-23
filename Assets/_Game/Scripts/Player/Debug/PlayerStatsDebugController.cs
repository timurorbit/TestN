using UniRx;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class PlayerStatsDebugController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _health;
        [SerializeField] private float _armor;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _invulnerabilityTime;

        private PlayerStatsModel _playerStatsModel;

        [Header("Debug")] [InspectorButton("UpdateStats")]
        public bool updateStatsButton;


        [Inject]
        public void Construct(PlayerStatsModel playerStatsModel)
        {
            _playerStatsModel = playerStatsModel;
        }

        private void Start()
        {
            if (_playerStatsModel == null)
            {
                Debug.LogError("PlayerStatsModel is null");
                return;
            }

            _moveSpeed = _playerStatsModel.MoveSpeed.Value;
            _health = _playerStatsModel.Health.Value;
            _armor = _playerStatsModel.Armor.Value;
            _rotationSpeed = _playerStatsModel.RotationSpeed.Value;
            _invulnerabilityTime = _playerStatsModel.InvulnerabilityTime.Value;

            _playerStatsModel.MoveSpeed.Subscribe(x => _moveSpeed = x).AddTo(this);
            _playerStatsModel.Health.Subscribe(x => _health = x).AddTo(this);
            _playerStatsModel.Armor.Subscribe(x => _armor = x).AddTo(this);
            _playerStatsModel.RotationSpeed.Subscribe(x => _rotationSpeed = x).AddTo(this);
            _playerStatsModel.InvulnerabilityTime.Subscribe(x => _invulnerabilityTime = x).AddTo(this);
        }


        public void UpdateStats()
        {
            if (_playerStatsModel == null)
            {
                return;
            }

            _playerStatsModel.MoveSpeed.Value = _moveSpeed;
            _playerStatsModel.Health.Value = _health;
            _playerStatsModel.Armor.Value = _armor;
            _playerStatsModel.RotationSpeed.Value = _rotationSpeed;
            _playerStatsModel.InvulnerabilityTime.Value = _invulnerabilityTime;
        }
    }
}