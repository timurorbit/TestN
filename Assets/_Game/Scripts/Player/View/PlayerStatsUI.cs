using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moveSpeedText;
        [SerializeField]
        private TMP_Text healthText;
        [SerializeField]
        private TMP_Text armorText;
        [SerializeField]
        private TMP_Text rotationSpeedText;
        [SerializeField]
        private TMP_Text invulnerabilityTimeText;

        private PlayerStatsModel _playerStatsModel;

        //todo fix boxing
        [Inject]
        public void Construct(PlayerStatsModel playerStatsModel)
        {
            _playerStatsModel = playerStatsModel;
            
            _playerStatsModel.MoveSpeed
                .Subscribe(value => moveSpeedText.text = $"Move Speed: {value:F1}")
                .AddTo(this);

            _playerStatsModel.Health
                .Subscribe(value => healthText.text = $"Health: {value:F1}")
                .AddTo(this);

            _playerStatsModel.Armor
                .Subscribe(value => armorText.text = $"Armor: {value:F1}")
                .AddTo(this);

            _playerStatsModel.RotationSpeed
                .Subscribe(value => rotationSpeedText.text = $"Rotation Speed: {value:F1}")
                .AddTo(this);

            _playerStatsModel.InvulnerabilityTime
                .Subscribe(value => invulnerabilityTimeText.text = $"Invulnerability: {value:F1}s")
                .AddTo(this);
        }
    }
}