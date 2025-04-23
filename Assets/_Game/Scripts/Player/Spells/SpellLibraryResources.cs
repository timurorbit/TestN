using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MageDefence
{
    public class SpellLibraryResources : ISpellLibrary
    {
        public List<Spell> Spells {get; } = new();
        public Spell ActiveSpell { get; private set; }

        private IResourceLoader _resourceLoader;

        private int ActiveSpellIndex;

        public SpellLibraryResources(IResourceLoader resourceLoader)
        {
            this._resourceLoader = resourceLoader;
        }
        
        [Inject]
        public void Construct(IResourceLoader iResourceLoader)
        {
            this._resourceLoader = iResourceLoader;
        }

        public void ChangeActiveSpellByIndexChange(int indexChange)
        {
            if (Spells.Count == 0)
            {
                return;
            }
            ActiveSpellIndex = (ActiveSpellIndex + indexChange + Spells.Count) % Spells.Count;
            ActiveSpell = Spells[ActiveSpellIndex];
        }
        
        public void LoadNewLibrary(string path)
        {
            if (_resourceLoader == null)
            {
                Debug.LogError("resourceLoader is null");
                return;
            }
            
            Spells.Clear();
            Spells.AddRange(_resourceLoader.GetSpells(path));
            ActiveSpell = Spells[0];
        }
    }
}