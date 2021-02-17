using DnDProject.Backend.Mapping.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Character.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DnDProject.Backend.Mapping.Implementations.Generic;
using DnDProject.Entities.Races.DataModels;
using DnDProject.Entities.Races.ViewModels.PartialViewModels.ComponentModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;

namespace DnDProject.Backend.Mapping.Implementations
{
    public static class CharacterMapper
    {
        //Create
        public static Character mapCharacterVMToNewEntity(CharacterVM vm)
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
        public static CharacterVM mapCharacterToCharacterVM(Character m)
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
        public static RaceListModel mapRaceToRaceListModel(Race model)
        {
            ReadModelMapper<Race, RaceListModel> mapper = new ReadModelMapper<Race, RaceListModel>();
            RaceListModel lm = new RaceListModel();
            mapper.mapDataModelToViewModel(model, lm);

            return lm;
        }
        public static IsProficientCM mapIsProficientToIsProficientCM(IsProficient m)
        {
            ReadModelMapper<IsProficient, IsProficientCM> mapper = new ReadModelMapper<IsProficient, IsProficientCM>();
            IsProficientCM cm = new IsProficientCM();
            mapper.mapDataModelToViewModel(m, cm);
            return cm;
        }
        public static NoteCM mapNoteToNoteCM(Note m)
        {
            ReadModelMapper<Note, NoteCM> mapper = new ReadModelMapper<Note, NoteCM>();
            NoteCM cm = new NoteCM();
            mapper.mapDataModelToViewModel(m, cm);
            return cm;
        }

        //Update

        public static void mapNoteCMOverNote(NoteCM updatedRecord, Note entity)
        {
            UpdateModelMapper<NoteCM, Note> mapper = new UpdateModelMapper<NoteCM,Note>();
            mapper.mapUpdatedRecordOverEntity(updatedRecord, entity);
        }

    }
}
