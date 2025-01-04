using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MageDefence
{
    public class SpellLibrary : MonoBehaviour
    {
        //todo change to Addressables and loading spells
        [SerializeField] public List<Spell> spells = new List<Spell>();
        public Spell ActiveSpell { get; private set; }

        private int _activeSpellIndex;

        public void Awake()
        {
            ActiveSpell = spells[_activeSpellIndex];
        }

        public void ChangeSpellByIndexChange(int indexChange)
        {
            _activeSpellIndex = (_activeSpellIndex + indexChange + spells.Count) % spells.Count;
            ActiveSpell = spells[_activeSpellIndex];
        }
    }
}