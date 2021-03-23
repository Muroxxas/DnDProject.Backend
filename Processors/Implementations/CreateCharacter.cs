using DnDProject.Backend.Mapping.Implementations;
using DnDProject.Backend.Mapping.Implementations.Generic;
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
            Guid character_id = Guid.NewGuid();
            CreateModelMapper<PrimaryTabVM, CharacterDM> characterMapper = new CreateModelMapper<PrimaryTabVM, CharacterDM>();
            CreateModelMapper<CombatCM, CharacterDM> combatMapper = new CreateModelMapper<CombatCM, CharacterDM>();
            CharacterDM character = characterMapper.mapViewModelToDataModel(vm.PrimaryTab);
            if(_commons.raceExists(vm.PrimaryTab.Race) == true)
            {
                character.Race_id = vm.PrimaryTab.Race;
            };
            combatMapper.mapViewModelToDataModel(vm.PrimaryTab.Combat, character);


            character.Character_id = character_id;
            Health health = CharacterMapper.mapCombatCMToNewHealthEntity(vm.PrimaryTab.Combat);
            IsProficient skills = mapIsProficient(vm.PrimaryTab.Skills.isProficient);
            CreateModelMapper<SavesCM, IsProficient> mapSaves = new CreateModelMapper<SavesCM, IsProficient>();
            mapSaves.mapViewModelToDataModel(vm.PrimaryTab.Saves, skills);
            Stats stats = CharacterMapper.mapStatsCMToNewEntity(vm.PrimaryTab.Stats);
            Currency money = CharacterMapper.mapCurrencyCMToNewEntity(vm.InventoryTab.Money);
            
            character.Character_id = character_id;
            character.User_id = user_id;
            health.Character_id = character_id;
            stats.Character_id = character_id;
            skills.Character_id = character_id;
            money.Character_id = character_id;

            _userAccess.AddCharacter(character);
            _userAccess.AddHealthRecord(health);
            _userAccess.AddStatsRecord(stats);
            _userAccess.AddProficiencyRecord(skills);
            _userAccess.AddCurrencyRecord(money);
            LearnSpells(vm.SpellsTab.KnownSpells, character_id);
            SetInventory(vm.InventoryTab.Items, character_id);
            SetNotes(vm.NotesTab.Notes, character_id);
            SetClasses(vm.PrimaryTab.Classes.SelectedClasses, character_id);
            _userAccess.SaveChanges();
        }

        public CharacterVM CreateCharacterINVALID(CharacterVM vm)
        {
           
            //The reference sets won't be subimitted by the user - and even if they were, they may have been tampered with.
            //make sure we reset the reference sets to ensure accurate information is displayed.
            GetSelectableRaces(vm.PrimaryTab);
            GetSelectableClasses(vm.PrimaryTab.Classes.SelectedClasses);
            return vm;
        }



        private void LearnSpells(IEnumerable<KnownSpellRowCM> knownSpells, Guid character_id)
        {
            CreateModelMapper<KnownSpellRowCM, Spell_Character> mapper = new CreateModelMapper<KnownSpellRowCM, Spell_Character>();
            List<Guid> alreadyLearned = new List<Guid>();
            foreach(KnownSpellRowCM cm in knownSpells)
            {
                if (_commons.spellExists(cm.Spell_id) && alreadyLearned.Contains(cm.Spell_id) == false)
                {
                    Spell_Character record = mapper.mapViewModelToDataModel(cm);
                    record.Character_id = character_id;
                    _userAccess.CharacterLearnsSpell(record);
                    alreadyLearned.Add(cm.Spell_id);
                }
                else
                {
                    continue;
                }

            }
        }
        private void SetInventory(IEnumerable<HeldItemRowCM> heldItems, Guid Character_id)
        {
            CreateModelMapper<HeldItemRowCM, Character_Item> mapper = new CreateModelMapper<HeldItemRowCM, Character_Item>();
            List<Guid> obtainedItems = new List<Guid>();
            foreach(HeldItemRowCM heldItem in heldItems)
            {
                Guid item_id = heldItem.Item_id;
                if(_commons.itemExists(item_id) && obtainedItems.Contains(item_id) == false)
                {
                    Character_Item record = mapper.mapViewModelToDataModel(heldItem);
                    record.Character_id = Character_id;
                    _userAccess.CharacterObtainsItem(record);
                    obtainedItems.Add(item_id);
                }
                else
                {
                    continue;
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

        private void SetClasses(IEnumerable<ClassRowCM> selectedClasses, Guid Character_id)
        {

            CreateModelMapper<ClassRowCM, Character_Class_Subclass> mapper = new CreateModelMapper<ClassRowCM, Character_Class_Subclass>();
            List<Guid> alreadyLearnedClasses = new List<Guid>();
            foreach(ClassRowCM cm in selectedClasses)
            {
                //Check if the classes the player selected exist, if the selected sublcass exists, if the player hasn't already selected this class,
                //and if the selected subclass belongs to the selected class.
                if (_commons.playableClassExists(cm.SelectedClass_id) && _commons.subclassExists(cm.SelectedSubclass_id) 
                    && _commons.subclassIsOfClass(cm.SelectedSubclass_id, cm.SelectedClass_id) 
                    && alreadyLearnedClasses.Contains(cm.SelectedClass_id) == false)
                {
                    Character_Class_Subclass record = mapper.mapViewModelToDataModel(cm);
                    record.Character_id = Character_id;
                    alreadyLearnedClasses.Add(record.Class_id);
                    _userAccess.CharacterLearnsClass(record);

                }
                else
                {
                    continue;
                }
            }
        }

        private IsProficient mapIsProficient(IsProficientCM cm)
        {
            
            CreateModelMapper<IsProficientCM, IsProficient> skillMapper = new CreateModelMapper<IsProficientCM, IsProficient>();

            return skillMapper.mapViewModelToDataModel(cm);
            

        }
        private void GetBlankPrimaryTab(CharacterVM vm)
        {
            PrimaryTabVM primaryTab = new PrimaryTabVM();
            GetSelectableRaces(primaryTab);

            ClassRowCM[] selectedClasses = new ClassRowCM[1];
            selectedClasses[0] = new ClassRowCM
            {
                Index = 1
            };

            GetSelectableClasses(selectedClasses);
            primaryTab.Classes = new ClassesCM
            {
                SelectedClasses = selectedClasses
            };
            primaryTab.Stats = new StatsCM
            {
                Bonus = new StatBonusCM()
            };
            primaryTab.Saves = new SavesCM();
            primaryTab.Combat = new CombatCM();
            primaryTab.Skills = new ProficiencyCM
            {
                isProficient = new IsProficientCM(),
                TotalBonus = new SkillBonusCM()
            };

            vm.PrimaryTab = primaryTab;
        }
        private void GetBlankNotesTab(CharacterVM vm)
        {

            NoteCM[] noteCollection = new NoteCM[1];
            NoteCM blankNote = new NoteCM();
            noteCollection[0] = blankNote;

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

        private void GetSelectableRaces(PrimaryTabVM primaryTab)
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
            primaryTab.Races = races;
        }
        private void GetSelectableClasses(ClassRowCM[] classRowCMs)
        {
            //Pull class data from DB, map it to a set of Class list models.
            List<PlayableClass> PCs = _userAccess.GetAllPlayableClasses().ToList();
            ReadModelMapper<PlayableClass, ClassesListModel> mapper = new ReadModelMapper<PlayableClass, ClassesListModel>();
            List<ClassesListModel> playableList = new List<ClassesListModel>();
            foreach(PlayableClass pc in PCs)
            {
                ClassesListModel lm = mapper.mapDataModelToViewModel(pc);
                playableList.Add(lm);
            }

            //add copies of that set of list models to each CM.
            foreach (ClassRowCM rowCM in classRowCMs)
            {
                rowCM.playableClasses = playableList.ToArray();

                if(rowCM.SelectedClass_id != null)
                {
                    //get that CM's subclasses, turn it into a set of Subclasses List Models, and set.
                    List<Subclass> foundSubclasses = _userAccess.GetAllSubclassesForClass(rowCM.SelectedClass_id).ToList();
                    ReadModelMapper<Subclass, SubclassesListModel> subclassMapper = new ReadModelMapper<Subclass, SubclassesListModel>();
                    List<SubclassesListModel> subclasses = new List<SubclassesListModel>();
                    foreach (Subclass sc in foundSubclasses)
                    {
                        SubclassesListModel lm = subclassMapper.mapDataModelToViewModel(sc);
                        subclasses.Add(lm);
                    }
                    rowCM.subclasses = subclasses.ToArray();
                }

            }
        }


        public CreateCharacter(IBaseUserAccess userAccess, ICharacterCommonFunctions commons)
        {
            _userAccess = userAccess;
            _commons = commons;

        }
    }
}
