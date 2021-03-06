﻿using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface ISpellsRepository : IRepository<Spell>
    {
        //Retrieve the spells that can be cast by a specific character.
        IEnumerable<Spell> GetSpellsKnownBy(Guid Character_id);

        IEnumerable<Spell> GetSpellsOfSchool(Guid School_id);

        //Retrieve the spells that can be cast by a specific class. 
        IEnumerable<Spell> GetSpellsCastableBy(Guid Class_id);
        IEnumerable<Guid> GetIdsOfClassesThatCanCastSpell(Guid Spell_id);
        Spell_Character GetKnownSpellRecord(Guid Character_id, Guid Spell_id);
        IEnumerable<Spell_Character> GetKnownSpellRecordsForCharacter(Guid Character_id);

        School GetSchool(Guid School_id);

        void CharacterLearnsSpell(Guid Character_id, Guid Spell_id);

        void CharacterLearnsSpell(Spell_Character record);

        void CharacterForgetsSpell(Guid Character_id, Guid Spell_id);

        void AddSpellMaterials(Material material);

        Material GetSpellMaterials(Guid Spell_id);

        void DeleteSpellMaterials(Material material);

        void DeleteSpellMaterialsById(Guid Spell_id);

    }
}
