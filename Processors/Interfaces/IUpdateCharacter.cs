using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface IUpdateCharacter
    {
        void ExistingCharacterLearnsSpell(Guid user_id, Guid character_id, Guid spell_id);
    }
}
