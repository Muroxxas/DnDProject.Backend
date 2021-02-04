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



        public void AddCharacter(Character character)
        {
            _characterContext.Characters.Add(character);
        }
        public Character GetCharacter(Guid Character_id)
        {
            Character foundCharacter = _characterContext.Characters.Find(Character_id);
            return foundCharacter;
        }

        public void UpdateCharacter(Character updatedRecord)
        {
            Character foundCharacter = GetCharacter(updatedRecord.Character_id);
            _characterMapper.mapUpdatedCharacterOverEntity(updatedRecord, foundCharacter);
        }
        public void DeleteCharacter(Guid Character_id)
        {
            Character foundCharacter = GetCharacter(Character_id);
            _characterContext.Characters.Remove(foundCharacter);
        }
        public void AddProficiencyRecord(IsProficient proficiencies)
        {
            _characterContext.Proficiencies.Add(proficiencies);
        }
        public IsProficient GetProficiencyRecord(Guid Character_id)
        {
            IsProficient foundRecord = _characterContext.Proficiencies.Find(Character_id);
            return foundRecord;
        }
        public void UpdateProficiencyRecord(IsProficient proficiencies)
        {
            IsProficient foundRecord = GetProficiencyRecord(proficiencies.Character_id);
            _characterMapper.mapUpdatedProficiencyRecordOverEntity(proficiencies, foundRecord);
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
