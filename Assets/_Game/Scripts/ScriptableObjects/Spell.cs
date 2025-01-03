using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MageDefence
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Spell")]
    public class Spell : ScriptableObject
    {
        public string spellName;
        public float damage;
        public float cooldown;
        public GameObject projectilePrefab;
        public float projectileSpeed;
        public float lifetime = 10f;
    
        [TextArea]
        public string description;
    }   
}
