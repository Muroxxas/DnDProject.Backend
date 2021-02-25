using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Character.DataModels;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Class.DataModels;
using DnDProject.Entities.Items.DataModels;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations
{
    public class CharacterCommonFunctions : ICharacterCommonFunctions
    {
        private IBaseUserAccess _userAccess;


        //------Create------
        public void addHeldItemToDb(Guid Character_id, Guid Item_id)
        {
            _userAccess.CharacterObtainsItem(Character_id, Item_id);
        }
        public void characterLearnsSpell(Guid Character_id, Guid Spell_id)
        {
            _userAccess.CharacterLearnsSpell(Character_id, Spell_id);
        }
        public void addNote(Note note)
        {
            _userAccess.AddNote(note);
        }
        public void characterLearnsClass(Character_Class_Subclass record)
        {
            _userAccess.CharacterLearnsClass(record);
        }

        //------Read------
        public bool spellExists(Guid Spell_id)
        {
            Spell foundSpell = _userAccess.GetSpell(Spell_id);
            if(foundSpell!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool playableClassExists(Guid class_id)
        {
            PlayableClass foundClass = _userAccess.GetPlayableClass(class_id);
            if(foundClass != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool subclassExists(Guid subclass_id)
        {
            Subclass foundSubclass = _userAccess.GetSubclass(subclass_id);
            if(foundSubclass != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool itemExists(Guid item_id)
        {
            Item foundItem = _userAccess.GetItem(item_id);

            if(foundItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool spellCanBeCastByClass(Guid spell_id, Guid class_id)
        {
            List<Guid> class_ids = _userAccess.GetIdsOfClassesThatCanCastSpell(spell_id).ToList();
            if (class_ids.Contains(class_id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        //------Delete------
        public KnownSpellCM[] removeNonExistantSpellCMFromKnownSpells(KnownSpellCM[] knownSpellCMs, Guid falseSpell_id)
        {
            List<KnownSpellCM> listOfCM = knownSpellCMs.ToList();
            KnownSpellCM falseSpell = listOfCM.Where(x => x.Spell_id == falseSpell_id).FirstOrDefault();
            if(falseSpell != null)
            {
                listOfCM.Remove(falseSpell);
            }
            return listOfCM.ToArray();

        }
        public Guid[] removeNonExistantClassIdFromSelectedClasses(Guid[] selectedClasses, Guid falseClass_id)
        {
            List<Guid> listOfGuid = selectedClasses.ToList();
            listOfGuid.Remove(falseClass_id);

            return listOfGuid.ToArray();
        }

        public HeldItemCM[] removeNonExistantItemFromHeldItems(HeldItemCM[] heldItems, Guid falseItem_id)
        {
            List<HeldItemCM> cms = heldItems.ToList();
            HeldItemCM falseItem = cms.Where(x => x.Item_id == falseItem_id).FirstOrDefault();
            if(falseItem != null)
            {
                cms.Remove(falseItem);
            }
            return cms.ToArray();
        }

        public CharacterCommonFunctions(IBaseUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
    }
}
