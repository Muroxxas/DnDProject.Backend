using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface ICharacterCommonFunctions
    {
        bool spellExists(Guid Spell_id);
        bool playableClassExists(Guid class_id);
        bool subclassExists(Guid subclass_id);
        bool itemExists(Guid Item_id);
        bool spellCanBeCastByClass(Guid spell_id, Guid class_id);


        KnownSpellCM[] removeNonExistantSpellCMFromKnownSpells(KnownSpellCM[] KnownSpells, Guid falseSpell_id);
        Guid[] removeNonExistantClassIdFromSelectedClasses(Guid[] SelectedClasses, Guid falseClass_id);
        HeldItemCM[] removeNonExistantItemFromHeldItems(HeldItemCM[] heldItems, Guid falseItem_id);
    }
}
