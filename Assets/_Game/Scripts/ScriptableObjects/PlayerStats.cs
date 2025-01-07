using System;
using UniRx;
using UnityEngine;

namespace MageDefence
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        
        [Header("Stats")]
        public float moveSpeed = 5f;
        public float health = 100f;
        [Range(0f, 1f)]
        public float armor = 0f;
        public float rotationSpeed = 25f;
        public float invulnerabilityTime = 0f;

        //todo validate
        private void OnValidate()
        {
            
        }
    }
}