using System.Collections.Generic;

namespace MageDefence
{
    public interface ISpellLibrary
    {
        public List<Spell> Spells {get;}
        public Spell ActiveSpell { get;}

        //TODO change from string to Enum SpellType
        public void LoadNewLibrary(string specifier = "");

        public void ChangeActiveSpellByIndexChange(int indexChange);

    }
}