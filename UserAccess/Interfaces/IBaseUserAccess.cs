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
        void AddCharacter(Character newCharacter);
        Character GetCharacter(Guid Character_id);
        void UpdateCharacter(Character updatedCharacter);
        void DeleteCharacter(Guid Character_id);

        void AddProficiencyRecord(IsProficient proficiencies);
        IsProficient GetProficiencyRecord(Guid Character_id);
        void UpdateProficiencyRecord(IsProficient updatedRecord);

        void AddHealthRecord(Health health);
        Health GetHealthRecord(Guid Character_id);
        void UpdateHealthRecord(Health updatedRecord);

        void AddStatsRecord(Stats stats);
        Stats GetStatsRecord(Guid CHaracter_id);
        void UpdateStatsRecord(Stats updatedRecord);

        void AddCurrencyRecord(Currency currency);
        Currency GetCurrencyRecord(Guid Character_id);
        void UpdateCurrencyRecord(Currency updatedRecord);

        void AddNote(Note note);
        Note GetNote(Guid Note_id);
        IEnumerable<Note> GetNotesOwnedBy(Guid Character_id);
        void UpdateNote(Note note);
        void DeleteNote(Guid Note_id);

        void SaveChanges();
        void SaveChangesAsync();


    }
}
