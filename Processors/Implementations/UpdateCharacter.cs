using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations
{
    public class UpdateCharacter : IUpdateCharacter
    {
        IBaseUserAccess _userAccess;

        public void ExistingCharacterLearnsSpell(Guid user_id, Guid Character_id, Guid Spell_id)
        {

            throw new NotImplementedException();
        }

        private bool CharacterOwnedByUser(CharacterDM character, Guid user_id)
        {
            if (character != null) {             
                if (character.User_id == user_id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool CharacterAlreadyKnowsSpell(Guid Character_id, Guid spell_id)
        {
            Spell_Character foundRecord = _userAccess.GetKnownSpellRecord(Character_id, spell_id);
            if (foundRecord != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UpdateCharacter(IBaseUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
    }
}
