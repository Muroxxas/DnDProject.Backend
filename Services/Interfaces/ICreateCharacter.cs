using DnDProject.Entities.Character.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Services.Interfaces
{
    public interface ICreateCharacter
    {
        CharacterVM CreateCharacterGET();
        void CreateCharacterPOST(CharacterVM vm);

        CharacterVM CreateCharacterINVALID(CharacterVM vm);

    }
}
