using DnDProject.Backend.Contexts;
using DnDProject.Backend.Mapping.Interfaces;
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
        ICharacterMapper _characterMapper;


        public Character GetCharacterBy_CharacterID(Guid Character_id)
        {
            Character foundCharacter = _characterContext.Characters.Find(Character_id);
            return foundCharacter;
        }

        public void InsertCharacterIntoDb(Character character)
        {
            _characterContext.Characters.Add(character);
        }

        public void UpdateCharacter(Character updatedRecord)
        {
            Character foundCharacter = GetCharacterBy_CharacterID(updatedRecord.Character_id);
            _characterMapper.mapUpdatedCharacterOverEntity(updatedRecord, foundCharacter);
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
        public MySqlDataRepository(CharacterContext characterContext, ICharacterMapper characterMapper)
        {
            _characterContext = characterContext;
            _characterMapper = characterMapper;

        }
        public MySqlDataRepository() { }
    }
}
