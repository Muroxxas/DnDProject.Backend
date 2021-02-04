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

        void SaveChanges();
        void SaveChangesAsync();


    }
}
