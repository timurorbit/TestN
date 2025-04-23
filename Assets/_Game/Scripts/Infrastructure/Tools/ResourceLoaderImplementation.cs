using System.Collections.Generic;
using UnityEngine;

namespace MageDefence
{
    public class ResourceLoaderImplementation : IResourceLoader
    {
        private const string DefaultResourcePath = "ScriptableObjects/Spells/Basic";
        
        // TODO: change to Addressables
        public List<Spell> GetSpells(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = DefaultResourcePath;
            }
            var loadedSpells = Resources.LoadAll<Spell>(key);
            
            
            if (loadedSpells.Length == 0)
            {
                Debug.LogWarning($"No spells found at path: {key}");
            }
            return new List<Spell>(loadedSpells);
        }
    }
}