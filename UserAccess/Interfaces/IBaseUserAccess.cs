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

namespace DnDProject.Backend.UserAccess.Interfaces
{
    public interface IBaseUserAccess
    {
        void AddCharacter(Character newCharacter);
        Character GetCharacter(Guid Character_id);
        void DeleteCharacter(Guid Character_id);

        void AddProficiencyRecord(IsProficient proficiencies);
        IsProficient GetProficiencyRecord(Guid Character_id);


        void AddHealthRecord(Health health);
        Health GetHealthRecord(Guid Character_id);


        void AddStatsRecord(Stats stats);
        Stats GetStatsRecord(Guid CHaracter_id);

        void AddCurrencyRecord(Currency currency);
        Currency GetCurrencyRecord(Guid Character_id);

        void AddNote(Note note);
        Note GetNote(Guid Note_id);
        IEnumerable<Note> GetNotesOwnedBy(Guid Character_id);
        void DeleteNote(Guid Note_id);

        Spell GetSpell(Guid Spell_id);
        Material GetSpellMaterials(Guid SPell_id);
        IEnumerable<Spell> GetSpellsKnownBy(Guid Character_id);
        IEnumerable<Spell> GetSpellsCastableBy(Guid Class_id);
        IEnumerable<Spell> GetSpellsOfSchool(Guid School_id);

        void CharacterLearnsSpell(Guid Character_id, Guid Spell_id);
        void CharacterForgetsSpell(Guid Character_id, Guid Spell_id);


        Item GetItem(Guid Item_id);
        IEnumerable<Item> GetItemsHeldBy(Guid Character_id);
        IEnumerable<Tag> GetAllTags();
        IEnumerable<Tag> GetTagsForItem(Guid Item_id);

        void CharacterObtainsItem(Guid Character_id, Guid Item_id);
        void CharacterLosesItem(Guid Character_id, Guid Item_id);


        PlayableClass GetPlayableClass(Guid CLass_id);
        IEnumerable<PlayableClass> GetAllPlayableClasses();
        IEnumerable<PlayableClass> GetClassesOfCharacter(Guid Character_id);
        Character_Class_Subclass GetKnownClassRecordOfCharaterAndClass(Guid Character_id, Guid Class_id);
        void CharacterLearnsClass(Guid Character_id, Guid Class_id);
        void CharacterLearnsClasses(Guid Character_id, List<Guid> Class_ids);
        void CharacterForgetsClass(Guid Character_id, Guid Class_id);

        ClassAbility GetAbility(Guid ClassAbility_id);
        IEnumerable<ClassAbility> GetAbilitiesOfClass(Guid Class_id);
        IEnumerable<ClassAbility> GetAbilitiesOfClassAtOrBelowLevel(Guid Class_id, int level);

        Subclass GetSubclass(Guid Subclass_id);
        IEnumerable<Subclass> GetAllSubclassesForClass(Guid Class_id);
        void CharacterOfClassLearnsSubclass(Guid Character_id, Guid Class_id, Guid Subclass_id);
        void CharacterOfClassForgetsSubclass(Guid Character_id, Guid Class_id, Guid Subclass_id);

        SubclassAbility GetSubclassAbility(Guid Subclass_id);
        IEnumerable<SubclassAbility> GetAllAbilitiesOfSubclass(Guid Subbclass_id);
        IEnumerable<SubclassAbility> GetAbilitiesOfSubclassAtOrBelowLevel(Guid Subclass_id, int level);

        Race GetRace(Guid Race_id);
        IEnumerable<Race> GetAllRaces();
        RaceAbility GetRaceAbility(Guid RaceAbility_id);
        IEnumerable<RaceAbility> GetAbilitiesOfRace(Guid Race_id);
        
        void SaveChanges();
        void SaveChangesAsync();


    }
}
