using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace MageDefence
{
    public class SpellLibraryResources : ISpellLibrary
    {
        public List<Spell> Spells {get; protected set; } = new();
        public Spell ActiveSpell { get; private set; }

        private const string DefaultResourcePath = "ScriptableObjects/Spells/Basic";

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
        
        public void LoadLibrary(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = DefaultResourcePath;
            }
            Spells.Clear();
            var loadedSpells = Resources.LoadAll<Spell>(path);
            
            
            if (loadedSpells.Length == 0)
            {
                Debug.LogWarning($"No spells found at path: {path}");
                return;
            }
            
            Spells.AddRange(loadedSpells);
            ActiveSpell = Spells[ActiveSpellIndex];
        }
    }
}