using DnDProject.Backend.Contexts;
using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class MySqlDataRepository : IDataRepository
    {
        CharacterContext _characterContext;


        public Character GetCharacterBy_CharacterID(Guid Character_id)
        {
            Character foundCharacter = _characterContext.Characters.Find(Character_id);
            return foundCharacter;
        }

        public void InsertCharacterIntoDb(Character character)
        {
            _characterContext.Characters.Add(character);
        }

        public void SaveChanges()
        {
            _characterContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _characterContext.SaveChangesAsync();
        }
        public MySqlDataRepository(CharacterContext characterContext)
        {
            _characterContext = characterContext;
        }

        public MySqlDataRepository() { }
    }
}
