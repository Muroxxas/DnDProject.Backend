using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Class.DataModels;
using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface ICharacterCommonFunctions
    {
        //Create
        void addHeldItemToDb(Guid Character_id, Guid Item_id);
        void characterLearnsSpell(Guid Character_id, Guid Spell_id);
        void addNote(Note note);
        void characterLearnsClass(Character_Class_Subclass record);



        //Read
        bool spellExists(Guid Spell_id);
        bool playableClassExists(Guid class_id);
        bool subclassExists(Guid subclass_id);
        bool itemExists(Guid Item_id);
        bool spellCanBeCastByClass(Guid spell_id, Guid class_id);


        KnownSpellRowCM[] removeNonExistantSpellCMFromKnownSpells(KnownSpellRowCM[] KnownSpells, Guid falseSpell_id);
        Guid[] removeNonExistantClassIdFromSelectedClasses(Guid[] SelectedClasses, Guid falseClass_id);
        HeldItemRowCM[] removeNonExistantItemFromHeldItems(HeldItemRowCM[] heldItems, Guid falseItem_id);
    }
}
