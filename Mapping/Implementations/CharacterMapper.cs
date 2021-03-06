﻿using DnDProject.Backend.Mapping.Interfaces;
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
using DnDProject.Backend.Mapping.Interfaces.Generic;
using DnDProject.Entities.Items.DataModels;
using DnDProject.Entities.Spells.DataModels;

namespace DnDProject.Backend.Mapping.Implementations
{
    public static class CharacterMapper
    {
        //Create
        public static CharacterDM mapCharacterVMToNewEntity(CharacterVM vm)
        {

            ICreateModelMapper<CharacterVM, CharacterDM> mapper = new CreateModelMapper<CharacterVM, CharacterDM>();
            return mapper.mapViewModelToDataModel(vm);
        }
        public static Health mapCombatCMToNewHealthEntity(CombatCM cm)
        {
            ICreateModelMapper<CombatCM, Health> mapper = new CreateModelMapper<CombatCM, Health>();
            return mapper.mapViewModelToDataModel(cm);
        }
        public static Stats mapStatsCMToNewEntity(StatsCM cm)
        {
            ICreateModelMapper<StatsCM, Stats> mapper = new CreateModelMapper<StatsCM, Stats>();
            return mapper.mapViewModelToDataModel(cm);
        }
            
        public static Currency mapCurrencyCMToNewEntity(MoneyCM cm)
        {
            ICreateModelMapper<MoneyCM, Currency> mapper = new CreateModelMapper<MoneyCM, Currency>();
            return mapper.mapViewModelToDataModel(cm);
        }
        public static Note mapNoteCMToNewEntity(NoteCM cm)
        {
            ICreateModelMapper<NoteCM, Note> mapper = new CreateModelMapper<NoteCM, Note>();
            return mapper.mapViewModelToDataModel(cm);
        }


        //Read
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
        public static HeldItemRowCM mapItemToHeldItemRowCM(Item m)
        {
            ReadModelMapper<Item, HeldItemRowCM> mapper = new ReadModelMapper<Item, HeldItemRowCM>();
            HeldItemRowCM cm = new HeldItemRowCM();
            mapper.mapDataModelToViewModel(m, cm);
            return cm;
        }
        public static void mapItemToHeldItemRowCM(Item m, HeldItemRowCM cm)
        {
            ReadModelMapper<Item, HeldItemRowCM> mapper = new ReadModelMapper<Item, HeldItemRowCM>();

            mapper.mapDataModelToViewModel(m, cm);

        }
        public static HeldItemRowCM mapHeldItemRecordToHeldItemRowCM(Character_Item m)
        {
            ReadModelMapper<Character_Item, HeldItemRowCM> mapper = new ReadModelMapper<Character_Item, HeldItemRowCM>();
            HeldItemRowCM cm= new HeldItemRowCM();
            mapper.mapDataModelToViewModel(m, cm);
            return cm;
        }
        public static void mapHeldItemRecordToHeldItemRowCM(Character_Item m, HeldItemRowCM cm)
        {
            ReadModelMapper<Character_Item, HeldItemRowCM> mapper = new ReadModelMapper<Character_Item, HeldItemRowCM>();

            mapper.mapDataModelToViewModel(m, cm);

        }
        public static ItemDetailsCM mapItemToItemDetailsCM(Item m)
        {
            ReadModelMapper<Item, ItemDetailsCM> mapper = new ReadModelMapper<Item, ItemDetailsCM>();
            ItemDetailsCM cm = new ItemDetailsCM();
            mapper.mapDataModelToViewModel(m, cm);
            return cm;
        }

        public static void mapItemToItemDetailsCM(Item m, ItemDetailsCM cm)
        {
            ReadModelMapper<Item, ItemDetailsCM> mapper = new ReadModelMapper<Item, ItemDetailsCM>();
            mapper.mapDataModelToViewModel(m, cm);
        }

        public static KnownSpellRowCM mapSpellToKnownSpellRowCM(Spell m)
        {
            ReadModelMapper<Spell, KnownSpellRowCM> mapper = new ReadModelMapper<Spell, KnownSpellRowCM>();
            KnownSpellRowCM cm = new KnownSpellRowCM();
            mapper.mapDataModelToViewModel(m, cm);
            return cm;
        }
        public static void mapSpellToKnownSpellRowCM(Spell m, KnownSpellRowCM cm)
        {
            ReadModelMapper<Spell, KnownSpellRowCM> mapper = new ReadModelMapper<Spell, KnownSpellRowCM>();
            mapper.mapDataModelToViewModel(m, cm);
        }

        public static SpellDetailsCM mapSpellToSpellDetailsCM(Spell m)
        {
            ReadModelMapper<Spell, SpellDetailsCM> mapper = new ReadModelMapper<Spell, SpellDetailsCM>();
            SpellDetailsCM cm = new SpellDetailsCM();
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
