using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Class.DataModels;
using DnDProject.Entities.Items.DataModels;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations
{
    public class ThingExists : IThingExists
    {
        private IBaseUserAccess _userAccess;

        public bool characterExists(Guid Character_id)
        {
            CharacterDM foundCharacter = _userAccess.GetCharacter(Character_id);
            if(foundCharacter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool spellExists(Guid Spell_id)
        {
            Spell foundSpell = _userAccess.GetSpell(Spell_id);
            if (foundSpell != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool playableClassExists(Guid class_id)
        {
            PlayableClass foundClass = _userAccess.GetPlayableClass(class_id);
            if (foundClass != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool subclassExists(Guid subclass_id)
        {
            Subclass foundSubclass = _userAccess.GetSubclass(subclass_id);
            if (foundSubclass != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool itemExists(Guid item_id)
        {
            Item foundItem = _userAccess.GetItem(item_id);

            if (foundItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ThingExists(IBaseUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
    }
}
