using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Interfaces
{
    public interface IBaseUserAccess
    {
        Character GetCharacter(Guid Character_id);

        void AddCharacter(Character newCharacter);

    }
}
