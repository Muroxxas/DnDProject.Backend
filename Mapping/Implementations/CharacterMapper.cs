using DnDProject.Backend.Mapping.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Character.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DnDProject.Backend.Mapping.Implementations
{
    public class CharacterMapper : ICharacterMapper
    {
        //Create
        public Character mapCharacterVMToNewEntity(CharacterVM vm)
        {
            Character character = new Character();

            //Map all items from the provided VM to a new Character entity. Does NOT map any source fields if the source field is null.
            var CharacterVM_To_New_Character = new MapperConfiguration(
                cfg => cfg.CreateMap<CharacterVM, Character>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
                );
            var mapper = CharacterVM_To_New_Character.CreateMapper();

            mapper.Map<CharacterVM, Character>(vm, character);

            return character;
        }


        //Read
        public CharacterVM mapCharacterToCharacterVM(Character m)
        {
            CharacterVM vm = new CharacterVM();

            var Character_To_CharacterVM = new MapperConfiguration(
                cfg => cfg.CreateMap<Character, CharacterVM>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
                );

            var mapper = Character_To_CharacterVM.CreateMapper();

            mapper.Map<Character, CharacterVM>(m, vm);

            return vm;
        }


        //Update
        public void mapCharacterVMToExistingEntity(CharacterVM vm, Character m)
        {
            //Map all items from CharacterVM to the an existing DB entity for a character's Character. Does NOT map any source fields if the source field is null.
            var CharacterVM_To_Entity = new MapperConfiguration(
                cfg => cfg.CreateMap<CharacterVM, Character>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
            );
            var mapper = CharacterVM_To_Entity.CreateMapper();

            mapper.Map<CharacterVM, Character>(vm, m);

        }
        public void mapUpdatedCharacterOverEntity(Character updatedCharacter, Character record)
        {
            var UpdatedCharacter_Over_Entity = new MapperConfiguration(
                cfg => cfg.CreateMap<Character, Character>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
            );

            var mapper = UpdatedCharacter_Over_Entity.CreateMapper();

            mapper.Map<Character, Character>(updatedCharacter, record);
        }
        public void mapUpdatedProficiencyRecordOverEntity(IsProficient updatedRecord, IsProficient record)
        {
            var UpdatedProficiencyRecord_OverOEntity = new MapperConfiguration(
                cfg => cfg.CreateMap<IsProficient, IsProficient>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
                );

            var mapper = UpdatedProficiencyRecord_OverOEntity.CreateMapper();

            mapper.Map<IsProficient, IsProficient>(updatedRecord, record);
        }

    }
}
