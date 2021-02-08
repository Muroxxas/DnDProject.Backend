using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Interfaces
{
    public interface IBaseUserAccess
    {
        void AddCharacter(Character newCharacter);
        Character GetCharacter(Guid Character_id);
        void DeleteCharacter(Guid Character_id);

        void AddProficiencyRecord(IsProficient proficiencies);
        IsProficient GetProficiencyRecord(Guid Character_id);


        void AddHealthRecord(Health health);
        Health GetHealthRecord(Guid Character_id);


        void AddStatsRecord(Stats stats);
        Stats GetStatsRecord(Guid CHaracter_id);

        void AddCurrencyRecord(Currency currency);
        Currency GetCurrencyRecord(Guid Character_id);

        void AddNote(Note note);
        Note GetNote(Guid Note_id);
        IEnumerable<Note> GetNotesOwnedBy(Guid Character_id);
        void DeleteNote(Guid Note_id);

        Spell GetSpell(Guid Spell_id);
        Material GetSpellMaterials(Guid SPell_id);
        IEnumerable<Spell> GetSpellsKnownBy(Guid Character_id);
        IEnumerable<Spell> GetSpellsCastableBy(Guid Class_id);
        IEnumerable<Spell> GetSpellsOfSchool(Guid School_id);

        void CharacterLearnsSpell(Guid Character_id, Guid Spell_id);
        void CharacterForgetsSpell(Guid Character_id, Guid Spell_id);

        void SaveChanges();
        void SaveChangesAsync();


    }
}
