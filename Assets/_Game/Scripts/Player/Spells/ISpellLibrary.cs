using System.Collections.Generic;

namespace MageDefence
{
    public interface ISpellLibrary
    {
        public List<Spell> Spells {get;}
        public Spell ActiveSpell { get;}

        public void LoadLibrary(string specifier = "");

        public void ChangeActiveSpellByIndexChange(int indexChange);

    }
}