using DnDProject.Entities.Character.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface ICreateCharacter
    {
        CharacterVM CreateCharacterGET();

        void CreateCharacterPOST(Guid user_id, CharacterVM vm);

        CharacterVM CreateCharacterINVALID(CharacterVM vm);

    }
}
