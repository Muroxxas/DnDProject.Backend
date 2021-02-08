using DnDProject.Backend.Repository;
using DnDProject.Backend.Unit_Of_Work.Implementations;
using DnDProject.Backend.Unit_Of_Work.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Implementations
{
    public class BaseUserAccess : IBaseUserAccess
    {
        private IUnitOfWork _worker { get; set; }

        public void AddCharacter(Character character)
        {
            _worker.Characters.Add(character);
        }
        public Character GetCharacter(Guid Character_id)
        {

            return _worker.Characters.Get(Character_id);
        }

        public void DeleteCharacter(Guid Character_id)
        {
            Character foundCharacter = _worker.Characters.Get(Character_id);
            _worker.Characters.Remove(foundCharacter);
        }


        public void AddProficiencyRecord(IsProficient proficiencies)
        {
            _worker.ProficiencyRecords.Add(proficiencies);
        }
        public IsProficient GetProficiencyRecord(Guid Character_id)
        {
            return _worker.ProficiencyRecords.Get(Character_id);
        }


        public void AddHealthRecord(Health health)
        {
            _worker.HealthRecords.Add(health);
        }
        public Health GetHealthRecord(Guid Character_id)
        {
            return _worker.HealthRecords.Get(Character_id);
        }


        public void AddStatsRecord(Stats stats)
        {
           _worker.Stats.Add(stats);
        }
        public Stats GetStatsRecord(Guid Character_id)
        {
            return _worker.Stats.Get(Character_id);
        }


        public void AddCurrencyRecord(Currency currency)
        {
            _worker.CurrencyRecords.Add(currency);
        }
        public Currency GetCurrencyRecord(Guid Character_id)
        {
            return _worker.CurrencyRecords.Get(Character_id);
        }



        public void AddNote(Note note)
        {
            _worker.Notes.Add(note);
        }
        public Note GetNote(Guid Note_id)
        {
            return _worker.Notes.Get(Note_id);
        }
        public IEnumerable<Note> GetNotesOwnedBy(Guid Character_id)
        {
            return _worker.Notes.GetNotesOwnedBy(Character_id);
        }


        public void DeleteNote(Guid Note_id)
        {
            Note foundNote = _worker.Notes.Get(Note_id);
            _worker.Notes.Remove(foundNote);
        }
        public void SaveChanges()
        {
            _worker.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _worker.SaveChangesAsync();
        }

        public Spell GetSpell(Guid Spell_id)
        {
            return _worker.Spells.Get(Spell_id);
        }
        public Material GetSpellMaterials(Guid Spell_id)
        {
            return _worker.Spells.GetSpellMaterials(Spell_id);
        }

        public IEnumerable<Spell> GetSpellsKnownBy(Guid Character_id)
        {
            return _worker.Spells.GetSpellsKnownBy(Character_id);
        }
        public IEnumerable<Spell> GetSpellsCastableBy(Guid Class_id)
        {
            return _worker.Spells.GetSpellsCastableBy(Class_id);
        }
        public IEnumerable<Spell> GetSpellsOfSchool(Guid School_id)
        {
            return _worker.Spells.GetSpellsOfSchool(School_id);
        }


        public void CharacterLearnsSpell(Guid Character_id, Guid Spell_id)
        {

            _worker.Spells.CharacterLearnsSpell(Character_id, Spell_id);
        }

        public void CharacterForgetsSpell(Guid Character_id, Guid Spell_id)
        {
            _worker.Spells.CharacterForgetsSpell(Character_id, Spell_id);
        }

        public BaseUserAccess(IUnitOfWork worker)
        {
            _worker = worker;
        }

    }
}
