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
    public class EFRepository : IDataRepository
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

        public void AddCurrencyRecord(Currency currency)
        {
            _characterContext.CurrencyRecords.Add(currency);
        }
        public Currency GetCurrencyRecord(Guid Character_id)
        {
            return _characterContext.CurrencyRecords.Find(Character_id);
        }
        public void UpdateCurrencyRecord(Currency updatedRecord)
        {
            Currency entity = _characterContext.CurrencyRecords.Find(updatedRecord.Character_id);
            _characterMapper.mapUpdatedCurrencyRecordOverEntity(updatedRecord, entity);
        }


        public void AddNote(Note note)
        {
            _characterContext.Notes.Add(note);
        }

        public Note GetNote(Guid Note_id)
        {
           return _characterContext.Notes.Find(Note_id);
        }

        public List<Note> GetNotesOwnedBy(Guid Character_id)
        {
            List<Note> notes = (from note in _characterContext.Notes
                               where note.Character_id == Character_id
                               select note).ToList();

            return notes;
        }

        public void UpdateNote(Note updatedRecord)
        {
            Note entity = _characterContext.Notes.Find(updatedRecord.Note_id);
            _characterMapper.mapUpdatedNoteOverEntity(updatedRecord, entity);
        }

        public void DeleteNote(Guid Note_id)
        {
            Note entity = _characterContext.Notes.Find(Note_id);
            _characterContext.Notes.Remove(entity);
        }

        public void SaveChanges()
        {
            _characterContext.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _characterContext.SaveChangesAsync();
        }


        public EFRepository(CharacterContext characterContext)
        {
            _characterContext = characterContext;
        }
        public EFRepository(CharacterContext characterContext, ICharacterMapper characterMapper)
        {
            _characterContext = characterContext;
            _characterMapper = characterMapper;

        }
        public EFRepository() { }
    }
}
