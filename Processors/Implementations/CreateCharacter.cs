using DnDProject.Backend.Mapping.Implementations;
using DnDProject.Backend.Mapping.Interfaces;
using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Character.ViewModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Class.DataModels;
using DnDProject.Entities.Items.DataModels;
using DnDProject.Entities.Races.DataModels;
using DnDProject.Entities.Races.ViewModels.PartialViewModels.ComponentModels;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations
{
    public class CreateCharacter : ICreateCharacter
    {
        IBaseUserAccess _userAccess;
        ICharacterCommonFunctions _commons;

        public CharacterVM CreateCharacterGET()
        {
            CharacterVM vm = new CharacterVM();
            GetBlankPrimaryTab(vm);
            GetBlankNotesTab(vm);
            GetBlankInventoryTab(vm);
            GetBlankSpellsTab(vm);
            return vm;
        }
        public void CreateCharacterPOST(Guid user_id, CharacterVM vm)
        {
            throw new NotImplementedException();
            //Still need to add mapping for Spell Slots
            Guid character_id = Guid.NewGuid();
            CharacterDM character = CharacterMapper.mapCharacterVMToNewEntity(vm);
            Health health = CharacterMapper.mapCombatCMToNewHealthEntity(vm.PrimaryTab.Combat);
            Stats stats = CharacterMapper.mapStatsCMToNewEntity(vm.PrimaryTab.Stats);
            Currency money = CharacterMapper.mapCurrencyCMToNewEntity(vm.InventoryTab.Money);

            character.Character_id = character_id;
            character.User_id = user_id;
            health.Character_id = character_id;
            stats.Character_id = character_id;
            money.Character_id = character_id;

            _userAccess.AddCharacter(character);
            _userAccess.AddHealthRecord(health);
            _userAccess.AddStatsRecord(stats);
            _userAccess.AddCurrencyRecord(money);
            LearnSpells(vm, character_id);
            SetInventory(vm, character_id);
            SetNotes(vm.NotesTab.Notes, character_id);

            _userAccess.SaveChanges();
        }

        public CharacterVM CreateCharacterINVALID(CharacterVM vm)
        {
           
            //The reference sets won't be subimitted by the user - and even if they were, they may have been tampered with.
            //make sure we reset the reference sets to ensure accurate information is displayed.
            SetListOfRaces(vm.PrimaryTab);
            SetListOfPlayableCLasses(vm.PrimaryTab);
            return vm;
        }



        private void LearnSpells(CharacterVM vm, Guid character_id)
        {
            throw new NotImplementedException();
        }
        private void SetInventory(CharacterVM vm, Guid Character_id)
        {
            List<Guid> obtainedItems = new List<Guid>();
            foreach(HeldItemRowCM heldItem in vm.InventoryTab.Items)
            {
                Guid item_id = heldItem.Item_id;
                if(_commons.itemExists(item_id) && obtainedItems.Contains(item_id) == false)
                {
                    _userAccess.CharacterObtainsItem(Character_id, item_id);
                    obtainedItems.Add(item_id);
                }
            }
        }
        private void SetNotes(IEnumerable<NoteCM> notes, Guid Character_id)
        {
            foreach(NoteCM note in notes)
            {
                Note noteRecord = CharacterMapper.mapNoteCMToNewEntity(note);
                noteRecord.Character_id = Character_id;
                noteRecord.Note_id = Guid.NewGuid();
                _userAccess.AddNote(noteRecord);
            }
        }

        private void GetBlankPrimaryTab(CharacterVM vm)
        {
            PrimaryTabVM primaryTab = new PrimaryTabVM();
            SetListOfRaces(primaryTab);
            SetListOfPlayableCLasses(primaryTab);
            primaryTab.Stats = new StatsCM();
            throw new NotImplementedException();
            primaryTab.Combat = new CombatCM();

            vm.PrimaryTab = primaryTab;
        }
        private void GetBlankNotesTab(CharacterVM vm)
        {
            NoteCM[] noteCollection = new NoteCM[0];
            NoteTabVM noteTab = new NoteTabVM();
            noteTab.Notes = noteCollection;

            vm.NotesTab = noteTab;
            
        }
        private void GetBlankInventoryTab(CharacterVM vm)
        {
            MoneyCM money = new MoneyCM();
            HeldItemRowCM[] heldItems = new HeldItemRowCM[0];

            InventoryTabVM inventoryTab = new InventoryTabVM();
            inventoryTab.Items = heldItems;
            inventoryTab.Money = money;
            vm.InventoryTab = inventoryTab;
        }
        private void GetBlankSpellsTab(CharacterVM vm)
        {
            SpellsTabVM spellsTab = new SpellsTabVM();
            KnownSpellRowCM[] KnownSpells = new KnownSpellRowCM[0];
            spellsTab.KnownSpells = KnownSpells;

            vm.SpellsTab = spellsTab;
        }

        private void SetListOfRaces(PrimaryTabVM primaryTab)
        {
            List<RaceListModel> races = new List<RaceListModel>();

            //Get foundRaces from userAccess
            List<Race> foundRaces = _userAccess.GetAllRaces().ToList();

            //foreach race in foundRaces,
            foreach(Race race in foundRaces)
            {
                RaceListModel lm = CharacterMapper.mapRaceToRaceListModel(race);
                races.Add(lm);

            }
                //Map that race to a new raceListModel
                //add that model to races.

            primaryTab.Races = races;
        }
        private void SetListOfPlayableCLasses(PrimaryTabVM primaryTab) 
        {
            throw new NotImplementedException();             
        }

        public CreateCharacter(IBaseUserAccess userAccess, ICharacterCommonFunctions commons)
        {
            _userAccess = userAccess;
            _commons = commons;

        }
    }
}
