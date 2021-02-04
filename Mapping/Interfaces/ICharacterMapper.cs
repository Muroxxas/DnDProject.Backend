using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Character.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Mapping.Interfaces
{
    public interface ICharacterMapper
    {

        //Create
        Character mapCharacterVMToNewEntity(CharacterVM vm);


        //Read
        CharacterVM mapCharacterToCharacterVM(Character m);

        //Update
        void mapCharacterVMToExistingEntity(CharacterVM vm, Character m);
        void mapUpdatedCharacterOverEntity(Character updatedCharacter, Character record);
        void mapUpdatedProficiencyRecordOverEntity(IsProficient updatedRecord, IsProficient record);
        void mapUpdatedHealthRecordOverEntity(Health updatedRecord, Health record);

    }
}
