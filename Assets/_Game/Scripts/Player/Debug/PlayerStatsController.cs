using UniRx;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class PlayerStatsController : MonoBehaviour
    {
        public float moveSpeed;
        public float health;
        public float armor;
        public float rotationSpeed;
        public float invulnerabilityTime;

        private PlayerStatsModel _playerStatsModel;
    
        [Header("Debug")]
    
        [InspectorButton("UpdateStats")]
        public bool updateStatsButton;
    
    

        [Inject]
        public void Construct(PlayerStatsModel playerStatsModel)
        {
            _playerStatsModel = playerStatsModel;
        
            moveSpeed = playerStatsModel.MoveSpeed.Value;
            health = playerStatsModel.Health.Value;
            armor = playerStatsModel.Armor.Value;
            rotationSpeed = playerStatsModel.RotationSpeed.Value;
            invulnerabilityTime = playerStatsModel.InvulnerabilityTime.Value;
        
            _playerStatsModel.MoveSpeed.Subscribe(x => moveSpeed = x).AddTo(this);
            _playerStatsModel.Health.Subscribe(x => health = x).AddTo(this);
            _playerStatsModel.Armor.Subscribe(x => armor = x).AddTo(this);
            _playerStatsModel.RotationSpeed.Subscribe(x => rotationSpeed = x).AddTo(this);
            _playerStatsModel.InvulnerabilityTime.Subscribe(x => invulnerabilityTime = x).AddTo(this);
        }
    
    
        public void UpdateStats()
        {
            if (_playerStatsModel == null)
            {
                return;
            }

            _playerStatsModel.MoveSpeed.Value = moveSpeed;
            _playerStatsModel.Health.Value = health;
            _playerStatsModel.Armor.Value = armor;
            _playerStatsModel.RotationSpeed.Value = rotationSpeed;
            _playerStatsModel.InvulnerabilityTime.Value = invulnerabilityTime;
        }
    }   
}
