using DnDProject.Backend.Mapping.Implementations;
using DnDProject.Backend.Mapping.Implementations.Generic;
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
    public class CharacterCMBuilder : ICharacterCMBuilder
    {
        IBaseUserAccess _userAccess;

        public HeldItemRowCM buildNewHeldItemRowCM(Guid item_id)
        {
            Item foundItem = _userAccess.GetItem(item_id);
            HeldItemRowCM cm = CharacterMapper.mapItemToHeldItemRowCM(foundItem);
            cm.isAttuned = false;
            cm.isEquipped = false;
            cm.Count = 1;

            return cm;
        }
        public HeldItemRowCM buildExistingHeldItemRowCM(Guid Character_id, Guid Item_id)
        {
            Item foundItem = _userAccess.GetItem(Item_id);
            HeldItemRowCM cm = CharacterMapper.mapItemToHeldItemRowCM(foundItem);
            Character_Item foundHeldItem = _userAccess.GetHeldItemRecord(Character_id, Item_id);
            CharacterMapper.mapHeldItemRecordToHeldItemRowCM(foundHeldItem, cm);
            return cm;
        }
        public IEnumerable<HeldItemRowCM> buildItemRowCMsForCharacter(Guid Character_id)
        {
            List<HeldItemRowCM> CMs = new List<HeldItemRowCM>();

            List<Character_Item> foundHeldItems = _userAccess.GetHeldItemRecordsForCharacter(Character_id).ToList();
            int i = 0;
            foreach(Character_Item heldItem in foundHeldItems)
            {
                Item foundItem = _userAccess.GetItem(heldItem.Item_id);
                HeldItemRowCM cm = CharacterMapper.mapItemToHeldItemRowCM(foundItem);
                CharacterMapper.mapHeldItemRecordToHeldItemRowCM(heldItem, cm);
                cm.Index = i;
                i++;
                CMs.Add(cm);
            }
            return CMs;
        }
        public ItemDetailsCM buildItemDetailsCM(Guid Item_id)
        {
            Item foundItem = _userAccess.GetItem(Item_id);
            ItemDetailsCM cm = CharacterMapper.mapItemToItemDetailsCM(foundItem);
            List<Tag> foundTags = _userAccess.GetTagsForItem(Item_id).ToList();
            List<string> tags = new List<string>();
            foreach(Tag tag in foundTags)
            {
                tags.Add(tag.TagName);
            }
            cm.Tags = tags.ToArray();
            return cm;

        }

        
        public KnownSpellRowCM buildKnownSpellRowCM(Guid Spell_id)
        {
            Spell foundSpell = _userAccess.GetSpell(Spell_id);
            KnownSpellRowCM cm = CharacterMapper.mapSpellToKnownSpellRowCM(foundSpell);
            cm.School = _userAccess.GetSchool(foundSpell.School_id).Name;
            return cm;
        }
        public IEnumerable<KnownSpellRowCM> buildKnownSpellRowCMsForCharacter(Guid Character_id)
        {
            List<Spell_Character> knownSpells = _userAccess.GetKnownSpellRecordsForCharacter(Character_id).ToList();
            List<KnownSpellRowCM> CMs = new List<KnownSpellRowCM>();
            int i = 0;
            foreach(Spell_Character knownSpell in knownSpells)
            {
                Spell foundSpell = _userAccess.GetSpell(knownSpell.Spell_id);
                School foundSchool = _userAccess.GetSchool(foundSpell.School_id);

                KnownSpellRowCM cm = CharacterMapper.mapSpellToKnownSpellRowCM(foundSpell);
                cm.Index = i;
                cm.School = foundSchool.Name;
                i++;
                CMs.Add(cm);
            }
            return CMs;
        }
        public SpellDetailsCM buildSpellDetailsCM(Guid Spell_id)
        {
            Spell foundSpell = _userAccess.GetSpell(Spell_id);
            SpellDetailsCM cm = CharacterMapper.mapSpellToSpellDetailsCM(foundSpell);
            cm.School = _userAccess.GetSchool(foundSpell.School_id).Name;
            if (foundSpell.RequiresMaterial == true)
            {
                cm.Material = _userAccess.GetSpellMaterials(Spell_id).materials;
            }

            return cm;
        }


        public IEnumerable<NoteCM> buildNoteCMsFOrCharacter(Guid Character_id)
        {
            List<Note> foundNotes = _userAccess.GetNotesOwnedBy(Character_id).ToList();
            List<NoteCM> CMs = new List<NoteCM>();

            int i = 0;
            foreach(Note note in foundNotes)
            {
                NoteCM cm = CharacterMapper.mapNoteToNoteCM(note);
                cm.Index = i;
                i++;
                CMs.Add(cm);
            }
            return CMs;
        }


        //Subclasses are not set in here, as that is planned to be handled dynamically by javascript getting only subclasses for the class.
        public KnownClassRowCM buildNewKnownClassRowCM()
        {
            ReadModelMapper<PlayableClass, ClassesListModel> mapper = new ReadModelMapper<PlayableClass, ClassesListModel>();
            List<PlayableClass> foundClasses = _userAccess.GetAllPlayableClasses().ToList();
            List<ClassesListModel> clm = new List<ClassesListModel>();
            foreach(PlayableClass x in foundClasses)
            {
                ClassesListModel lm = mapper.mapDataModelToViewModel(x);
                clm.Add(lm);
            }

            KnownClassRowCM cm = new KnownClassRowCM
            {
                Level = 1,
                HitDice = 1,
                Classes = clm
            };
            return cm;
        }
        public KnownClassRowCM buildExistingKnownClassRowCM(Guid Character_id, Guid Class_id)
        {
            //Get all playable classes for reference list
            ReadModelMapper<PlayableClass, ClassesListModel> classMapper = new ReadModelMapper<PlayableClass, ClassesListModel>();
            List<PlayableClass> foundClasses = _userAccess.GetAllPlayableClasses().ToList();
            List<ClassesListModel> clm = new List<ClassesListModel>();
            foreach (PlayableClass x in foundClasses)
            {
                ClassesListModel lm = classMapper.mapDataModelToViewModel(x);
                clm.Add(lm);
            }

            //Get all subclasses of Class for reference list.
            ReadModelMapper<Subclass, SubclassesListModel> subclassMapper = new ReadModelMapper<Subclass, SubclassesListModel>();
            List<Subclass> foundSubclasses = _userAccess.GetAllSubclassesForClass(Class_id).ToList();
            List<SubclassesListModel> sclm = new List<SubclassesListModel>();
            foreach(Subclass x in foundSubclasses)
            {
                SubclassesListModel lm = subclassMapper.mapDataModelToViewModel(x);
                sclm.Add(lm);
            }

            //Get info from the associatative record.
            Character_Class_Subclass foundCCSC = _userAccess.GetKnownClassRecordOfCharaterAndClass(Character_id, Class_id);


            KnownClassRowCM cm = new KnownClassRowCM
            {
                Class_id = Class_id,
                Classes = clm,

                Subclass_id = foundCCSC.Subclass_id,
                Subclasses = sclm,

                HitDice = foundCCSC.RemainingHitDice,
                Level = foundCCSC.ClassLevel
            };

            return cm;

        }

        public CharacterCMBuilder(IBaseUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
    }
}
