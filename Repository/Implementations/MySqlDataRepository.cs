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
            Character entity = GetCharacter(updatedRecord.Character_id);
            _characterMapper.mapUpdatedCharacterOverEntity(updatedRecord, entity);
        }
        public void DeleteCharacter(Guid Character_id)
        {
            Character entity = GetCharacter(Character_id);
            _characterContext.Characters.Remove(entity);
        }
        public void AddProficiencyRecord(IsProficient proficiencies)
        {
            _characterContext.Proficiencies.Add(proficiencies);
        }
        public IsProficient GetProficiencyRecord(Guid Character_id)
        {
            IsProficient entity = _characterContext.Proficiencies.Find(Character_id);
            return entity;
        }
        public void UpdateProficiencyRecord(IsProficient updatedRecord)
        {
            IsProficient entity = GetProficiencyRecord(updatedRecord.Character_id);
            _characterMapper.mapUpdatedProficiencyRecordOverEntity(updatedRecord, entity);
        }
        public void AddHealthRecord(Health health)
        {
            _characterContext.HealthRecords.Add(health);
        }
        public Health GetHealthRecord(Guid Character_id)
        {
            return _characterContext.HealthRecords.Find(Character_id);
        }
        public void UpdateHealthRecord(Health updatedRecord)
        {
            Health entity = _characterContext.HealthRecords.Find(updatedRecord.Character_id);
            _characterMapper.mapUpdatedHealthRecordOverEntity(updatedRecord, entity);
        }


        public void AddStatsRecord(Stats stats)
        {
            _characterContext.StatsRecords.Add(stats);
        }

        public Stats GetStatsRecord(Guid Character_id)
        {
            return _characterContext.StatsRecords.Find(Character_id);
        }

        public void UpdateStatsRecord(Stats updatedRecord)
        {
            Stats entity = _characterContext.StatsRecords.Find(updatedRecord.Character_id);
            _characterMapper.mapUpdatedStatsRecordOverEntity(updatedRecord, entity);
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
