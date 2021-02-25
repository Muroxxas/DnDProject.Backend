using DnDProject.Backend.Repository;
using DnDProject.Backend.Unit_Of_Work.Implementations;
using DnDProject.Backend.Unit_Of_Work.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Class.DataModels;
using DnDProject.Entities.Items.DataModels;
using DnDProject.Entities.Races.DataModels;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Implementations
{
    public class BaseUserAccess : IBaseUserAccess
    {
        private IUnitOfWork _worker { get; set; }

        public void AddCharacter(CharacterDM character)
        {
            _worker.Characters.Add(character);
        }
        public CharacterDM GetCharacter(Guid Character_id)
        {

            return _worker.Characters.Get(Character_id);
        }

        public void DeleteCharacter(Guid Character_id)
        {
            CharacterDM foundCharacter = _worker.Characters.Get(Character_id);
            _worker.Characters.Remove(foundCharacter);
        }


        public void AddProficiencyRecord(IsProficient proficiencies)
        {
            _worker.ProficiencyRecords.Add(proficiencies);
        }
        public IsProficient GetProficiencyRecord(Guid Character_id)
        {
            return _worker.ProficiencyRecords.Get(Character_id);
        }


        public void AddHealthRecord(Health health)
        {
            _worker.HealthRecords.Add(health);
        }
        public Health GetHealthRecord(Guid Character_id)
        {
            return _worker.HealthRecords.Get(Character_id);
        }


        public void AddStatsRecord(Stats stats)
        {
           _worker.Stats.Add(stats);
        }
        public Stats GetStatsRecord(Guid Character_id)
        {
            return _worker.Stats.Get(Character_id);
        }


        public void AddCurrencyRecord(Currency currency)
        {
            _worker.CurrencyRecords.Add(currency);
        }
        public Currency GetCurrencyRecord(Guid Character_id)
        {
            return _worker.CurrencyRecords.Get(Character_id);
        }



        public void AddNote(Note note)
        {
            _worker.Notes.Add(note);
        }
        public Note GetNote(Guid Note_id)
        {
            return _worker.Notes.Get(Note_id);
        }
        public IEnumerable<Note> GetNotesOwnedBy(Guid Character_id)
        {
            return _worker.Notes.GetNotesOwnedBy(Character_id);
        }


        public void DeleteNote(Guid Note_id)
        {
            Note foundNote = _worker.Notes.Get(Note_id);
            _worker.Notes.Remove(foundNote);
        }
        public void SaveChanges()
        {
            _worker.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _worker.SaveChangesAsync();
        }

        public Spell GetSpell(Guid Spell_id)
        {
            return _worker.Spells.Get(Spell_id);
        }
        public Material GetSpellMaterials(Guid Spell_id)
        {
            return _worker.Spells.GetSpellMaterials(Spell_id);
        }
        public School GetSchool(Guid School_id)
        {
            return _worker.Spells.GetSchool(School_id);
        }
        public Spell_Character GetKnownSpellRecord(Guid Character_id, Guid Spell_id)
        {
            return _worker.Spells.GetKnownSpellRecord(Character_id, Spell_id);
        }
        public IEnumerable<Spell_Character> GetKnownSpellRecordsForCharacter(Guid Character_id)
        {
            return _worker.Spells.GetKnownSpellRecordsForCharacter(Character_id);
        }
        public IEnumerable<Spell> GetSpellsKnownBy(Guid Character_id)
        {
            return _worker.Spells.GetSpellsKnownBy(Character_id);
        }
        public IEnumerable<Spell> GetSpellsCastableBy(Guid Class_id)
        {
            return _worker.Spells.GetSpellsCastableBy(Class_id);
        }
        public IEnumerable<Spell> GetSpellsOfSchool(Guid School_id)
        {
            return _worker.Spells.GetSpellsOfSchool(School_id);
        }
        public IEnumerable<Guid> GetIdsOfClassesThatCanCastSpell(Guid Spell_id)
        {
            return _worker.Spells.GetIdsOfClassesThatCanCastSpell(Spell_id);
        }


        public void CharacterLearnsSpell(Guid Character_id, Guid Spell_id)
        {

            _worker.Spells.CharacterLearnsSpell(Character_id, Spell_id);
        }

        public void CharacterForgetsSpell(Guid Character_id, Guid Spell_id)
        {
            _worker.Spells.CharacterForgetsSpell(Character_id, Spell_id);
        }

        public void CharacterObtainsItem(Guid Character_id, Guid Item_id)
        {
            _worker.Items.CharacterObtainsItem(Character_id, Item_id);
        }

        public void CharacterLosesItem(Guid Character_id, Guid Item_id)
        {
            _worker.Items.CharacterLosesItem(Character_id, Item_id);
        }

        public Item GetItem(Guid Item_id)
        {
            return _worker.Items.Get(Item_id);
        }
        public Character_Item GetHeldItemRecord(Guid Character_id, Guid Item_id)
        {
            return _worker.Items.GetHeldItemRecord(Character_id, Item_id);
        }
        public IEnumerable<Character_Item> GetHeldItemRecordsForCharacter(Guid Character_id)
        {
            return _worker.Items.GetHeldItemRecordsForCharacter(Character_id);
        }
        public IEnumerable<Item> GetItemsHeldBy(Guid Character_id)
        {
            return _worker.Items.GetItemsHeldBy(Character_id);
        }
        public IEnumerable<Tag> GetAllTags()
        {
            return _worker.Items.GetAllTags();
        }
        public IEnumerable<Tag> GetTagsForItem(Guid Item_id)
        {
            return _worker.Items.GetTagsForItem(Item_id);
        }

        public PlayableClass GetPlayableClass(Guid Class_id)
        {
            return _worker.Classes.Get(Class_id);
        }
        public IEnumerable<PlayableClass> GetAllPlayableClasses()
        {
            return _worker.Classes.GetAll();
        }
        public IEnumerable<PlayableClass> GetClassesOfCharacter(Guid Character_id)
        {
            return _worker.Classes.GetClassesOfCharacter(Character_id);
        }
        public Character_Class_Subclass GetKnownClassRecordOfCharaterAndClass(Guid Character_id, Guid Class_id)
        {
            return _worker.Classes.GetKnownClassRecordOfCharacterAndClass(Character_id, Class_id);
        }
        public void CharacterLearnsClass(Character_Class_Subclass record)
        {
            _worker.Classes.CharacterLearnsClass(record);
        }
        public void CharacterLearnsClasses(Guid Character_id, List<Guid> Class_ids)
        {
            _worker.Classes.CharacterLearnsClasses(Character_id, Class_ids);
        }
        public void CharacterForgetsClass(Guid Character_id, Guid Class_id)
        {
            _worker.Classes.CharacterForgetsClass(Character_id, Class_id);
        }

        public IEnumerable<ClassAbility> GetAbilitiesOfClass(Guid Class_id)
        {
            return _worker.ClassAbilities.GetAbilitiesOfClass(Class_id);
        }
        public IEnumerable<ClassAbility> GetAbilitiesOfClassAtOrBelowLevel(Guid Class_id, int level)
        {
            return _worker.ClassAbilities.GetAbilitiesOfClassAtOrBelowLevel(Class_id, level);
        }
        public ClassAbility GetAbility(Guid ClassAbility_id)
        {
            return _worker.ClassAbilities.Get(ClassAbility_id);
        }

        public Subclass GetSubclass(Guid Subclass_id)
        {
            return _worker.Subclasses.Get(Subclass_id);
        }
        public IEnumerable<Subclass> GetAllSubclassesForClass(Guid Class_id)
        {
            return _worker.Subclasses.GetAllSubclassesForClass(Class_id);
        }
        public void CharacterOfClassLearnsSubclass(Guid Character_id, Guid Class_id, Guid Subclass_id)
        {
            _worker.Subclasses.CharacterOfClassLearnsSubclass(Character_id, Class_id, Subclass_id);
        }
        public void CharacterOfClassForgetsSubclass(Guid Character_id, Guid Class_id, Guid Subclass_id)
        {
            _worker.Subclasses.CharacterOfClassForgetsSubclass(Character_id, Class_id, Subclass_id);
        }

        public SubclassAbility GetSubclassAbility(Guid SubclassAbility_id)
        {
            return _worker.SubclassAbilities.Get(SubclassAbility_id);
        }
        public IEnumerable<SubclassAbility> GetAllAbilitiesOfSubclass(Guid Subclass_id)
        {
            return _worker.SubclassAbilities.GetAllAbilitiesOfSubclass(Subclass_id);
        }
        public IEnumerable<SubclassAbility> GetAbilitiesOfSubclassAtOrBelowLevel(Guid Subclass_id, int level)
        {
            return _worker.SubclassAbilities.GetAbilitiesOfSubclassAtOrBelowLevel(Subclass_id, level);
        }

        public Race GetRace(Guid Race_id)
        {
            return _worker.Races.Get(Race_id);
        }
        public IEnumerable<Race> GetAllRaces()
        {
            return _worker.Races.GetAll();
        }
        public RaceAbility GetRaceAbility(Guid RaceAbility_id)
        {
            return _worker.Races.GetRaceAbility(RaceAbility_id);
        }
        public IEnumerable<RaceAbility> GetAbilitiesOfRace(Guid Race_id)
        {
            return _worker.Races.GetAbilitiesOfRace(Race_id);
        }
        public BaseUserAccess(IUnitOfWork worker)
        {
            _worker = worker;
        }

    }
}
