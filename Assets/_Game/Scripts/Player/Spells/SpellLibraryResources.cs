using System.Collections.Generic;
using UnityEngine;

namespace MageDefence
{
    public class SpellLibraryResources : ISpellLibrary
    {
        public List<Spell> Spells {get; protected set; } = new();
        public Spell ActiveSpell { get; private set; }

        private int ActiveSpellIndex;

        public void ChangeActiveSpellByIndexChange(int indexChange)
        {
            if (Spells.Count == 0)
            {
                return;
            }
            ActiveSpellIndex = (ActiveSpellIndex + indexChange + Spells.Count) % Spells.Count;
            ActiveSpell = Spells[ActiveSpellIndex];
        }
        
        public void LoadLibrary(string path = "ScriptableObjects/Spells/Basic")
        {
           Spells.Clear();
           Spell[] loadedSpells = Resources.LoadAll<Spell>(path);
           Spells.AddRange(loadedSpells);
           if (Spells.Count > 0)
           {
               ActiveSpellIndex = 0;
               ActiveSpell = Spells[ActiveSpellIndex];
           }
        }
    }
}