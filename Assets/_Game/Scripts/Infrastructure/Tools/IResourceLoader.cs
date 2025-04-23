using System.Collections.Generic;

namespace MageDefence
{
    public interface IResourceLoader
    {
        public List<Spell> GetSpells(string key);
    }
}