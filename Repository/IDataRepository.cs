﻿using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository
{
    public interface IDataRepository
    {
        void AddCharacter(Character character);
        Character GetCharacter(Guid Character_id);

        void UpdateCharacter(Character updatedRecord);
        void DeleteCharacter(Guid Character_id);


        
        void AddProficiencyRecord(IsProficient proficiencies);
        IsProficient GetProficiencyRecord(Guid Character_id);
        void UpdateProficiencyRecord(IsProficient proficiencies);
        void SaveChanges();
        void SaveChangesAsync();
    }
}
