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
        public ClassRowCM buildNewClassRowCM(int Index)
        {
            ReadModelMapper<PlayableClass, ClassesListModel> mapper = new ReadModelMapper<PlayableClass, ClassesListModel>();
            List<PlayableClass> foundClasses = _userAccess.GetAllPlayableClasses().ToList();
            List<ClassesListModel> clm = new List<ClassesListModel>();
            foreach(PlayableClass x in foundClasses)
            {
                ClassesListModel lm = mapper.mapDataModelToViewModel(x);
                clm.Add(lm);
            }

            ClassRowCM cm = new ClassRowCM
            {
                Index=Index,
                Level = 1,
                RemainingHitDice = 1,
                playableClasses = clm.ToArray()
            };
            return cm;
        }
        public ClassRowCM buildKnownClassRowCM(int Index, Character_Class_Subclass ccsc, ClassesListModel[] CLM)
        {

            // Takes the set of list models as an argument, as 
            //being passed references to the same set is more efficient than searching and obtaining the set again and again.
            //Still have to search for each class' subclasses, as that changes depending on the class.
            ReadModelMapper<Subclass, SubclassesListModel> subclassMapper = new ReadModelMapper<Subclass, SubclassesListModel>();
            List<Subclass> foundSubclasses = _userAccess.GetAllSubclassesForClass(ccsc.Class_id).ToList();
            List<SubclassesListModel> sclm = new List<SubclassesListModel>();
            foreach (Subclass x in foundSubclasses)
            {
                SubclassesListModel lm = subclassMapper.mapDataModelToViewModel(x);
                sclm.Add(lm);
            }

            ClassRowCM cm = new ClassRowCM
            {
                Index = Index,
                playableClasses = CLM,
                SelectedClass_id = ccsc.Class_id,

                Level = ccsc.ClassLevel,
                RemainingHitDice = ccsc.RemainingHitDice,

                subclasses = sclm.ToArray(),
                SelectedSubclass_id = ccsc.Subclass_id
            };
            return cm;

        }


        public StatsCM buildStatsCM(Guid Character_id)
        {
            ReadModelMapper<Stats, StatsCM> mapper = new ReadModelMapper<Stats, StatsCM>();
            Stats foundStats = _userAccess.GetStatsRecord(Character_id);
            StatsCM cm = mapper.mapDataModelToViewModel(foundStats);
            return cm;
        }

        public StatBonusCM buildStatBonusCM(StatsCM cm)
        {
            StatBonusCM bonusCM = new StatBonusCM();

            bonusCM.Strength = calcStatBonus(cm.Strength);
            bonusCM.Dexterity = calcStatBonus(cm.Dexterity);
            bonusCM.Constitution = calcStatBonus(cm.Constitution);

            bonusCM.Intelligence = calcStatBonus(cm.Intelligence);
            bonusCM.Wisdom = calcStatBonus(cm.Wisdom);
            bonusCM.Charisma = calcStatBonus(cm.Charisma);

            return bonusCM;
        }

        public ProficiencyCM buildProficiencyCM(Guid Character_id, StatBonusCM statBonus, int totalLevel)
        {
            ProficiencyCM cm = new ProficiencyCM();
            cm.ProficiencyBonus = totalLevel / 4;

            IsProficientCM isProficient = buildIsProficientCM(Character_id);
            cm.isProficient = isProficient;

            SkillBonusCM skillBonus = buildSkillBonusCM(statBonus, totalLevel, isProficient);
            cm.TotalBonus = skillBonus;

            return cm;
        }
        public IsProficientCM buildIsProficientCM(Guid Character_id)
        {
            IsProficient foundRecord = _userAccess.GetProficiencyRecord(Character_id);
            ReadModelMapper<IsProficient, IsProficientCM> mapper = new ReadModelMapper<IsProficient, IsProficientCM>();
            IsProficientCM cm = mapper.mapDataModelToViewModel(foundRecord);
            return cm;
        }

        public SkillBonusCM buildSkillBonusCM(StatBonusCM statBonus, int totalLevel, IsProficientCM proficiencies)
        {
            SkillBonusCM skillBonus = new SkillBonusCM();
            int proficienyBonus = totalLevel / 4;

            //str
            skillBonus.Athletics = calcSkillBonus(statBonus.Strength, proficienyBonus, proficiencies.Athletics);

            //dex
            skillBonus.Acrobatics = calcSkillBonus(statBonus.Dexterity, proficienyBonus, proficiencies.Acrobatics);
            skillBonus.Stealth = calcSkillBonus(statBonus.Dexterity, proficienyBonus, proficiencies.Stealth);
            skillBonus.SleightOfHand = calcSkillBonus(statBonus.Dexterity, proficienyBonus, proficiencies.SleightOfHand);

            //con
            // no skills for constitution

            //int
            skillBonus.Arcana = calcSkillBonus(statBonus.Intelligence, proficienyBonus, proficiencies.Arcana);
            skillBonus.History = calcSkillBonus(statBonus.Intelligence, proficienyBonus, proficiencies.History);
            skillBonus.Investigation = calcSkillBonus(statBonus.Intelligence, proficienyBonus, proficiencies.Investigation);
            skillBonus.Nature = calcSkillBonus(statBonus.Intelligence, proficienyBonus, proficiencies.Nature);
            skillBonus.Religion = calcSkillBonus(statBonus.Intelligence, proficienyBonus, proficiencies.Religion);

            //wis
            skillBonus.AnimalHandling = calcSkillBonus(statBonus.Wisdom, proficienyBonus, proficiencies.AnimalHandling);
            skillBonus.Insight = calcSkillBonus(statBonus.Wisdom, proficienyBonus, proficiencies.Insight);
            skillBonus.Medicine = calcSkillBonus(statBonus.Wisdom, proficienyBonus, proficiencies.Medicine);
            skillBonus.Perception = calcSkillBonus(statBonus.Wisdom, proficienyBonus, proficiencies.Perception);
            skillBonus.Survival = calcSkillBonus(statBonus.Wisdom, proficienyBonus, proficiencies.Survival);

            //cha
            skillBonus.Deception = calcSkillBonus(statBonus.Charisma, proficienyBonus, proficiencies.Deception);
            skillBonus.Intimidation = calcSkillBonus(statBonus.Charisma, proficienyBonus, proficiencies.Intimidation);
            skillBonus.Performance = calcSkillBonus(statBonus.Charisma, proficienyBonus, proficiencies.Performance);
            skillBonus.Persuasion = calcSkillBonus(statBonus.Charisma, proficienyBonus, proficiencies.Persuasion);

            return skillBonus;
        }


        private int calcStatBonus (int stat)
        {
            if(stat == 10)
            {
                return 0;
            }
            else if (stat > 10)
            {
                double calculating = (double)(stat - 10) / 2;
                double result = Math.Floor(calculating);
                return (int)result;
            }
            else
            {
                double calculating = (double)(10 - stat) / 2;
                double result = 0 - Math.Ceiling(calculating);
                return (int)result;
            }
        }
        private int calcSkillBonus(int statBonus, int proficiencyBonus, bool isProficient)
        {
            if (isProficient)
            {
                return statBonus + proficiencyBonus;
            }
            else
            {
                return statBonus;
            }
        }

        public CharacterCMBuilder(IBaseUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
    }
}
