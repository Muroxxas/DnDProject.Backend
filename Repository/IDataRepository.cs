using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository
{
    public interface IDataRepository
    {
        Character GetCharacterBy_CharacterID(Guid Character_id);
        void InsertCharacterIntoDb(Character character);

        void SaveChanges();
        void SaveChangesAsync();
    }
}
