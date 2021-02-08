using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class SpellsRepository :Repository<Spell>, ISpellsRepository
    {
        //cast the context inherited from the generic Repository as a CharacterContext.
        public SpellsContext spellsContext { get { return Context as SpellsContext; } }


        public IEnumerable<Spell> GetSpellsKnownBy(Guid Character_id)
        {
           IEnumerable<Spell_Character> knownSpellRecords = spellsContext.KnownSpells.Where(x => x.Character_id == Character_id);

            List<Guid> spell_ids = new List<Guid>();
            foreach(Spell_Character S_C in knownSpellRecords)
            {
                spell_ids.Add(S_C.Spell_id);
            }

            IEnumerable<Spell> knownSpells = spellsContext.Spells.Where(spell => spell_ids.Contains(spell.Spell_id));

            return knownSpells;
        }

        public IEnumerable<Spell> GetSpellsOfSchool(Guid School_id)
        {
            return spellsContext.Spells.Where(spell => spell.School_id == School_id).ToList();
        }

        public IEnumerable<Spell> GetSpellsCastableBy(Guid Class_id)
        {
            IEnumerable<Spell_Class> CastableByRecords = spellsContext.CastableByRecords.Where(x => x.Class_id == Class_id);

            List<Guid> spell_ids = new List<Guid>();
            foreach(Spell_Class S_C in CastableByRecords)
            {
                spell_ids.Add(S_C.Spell_id);

            }

            IEnumerable<Spell> knownSpells = spellsContext.Spells.Where(spell => spell_ids.Contains(spell.Spell_id));

            return knownSpells;
        }

        public void CharacterLearnsSpell(Guid Character_id, Guid Spell_id)
        {
            Spell_Character learnedSpell = new Spell_Character
            {
                Spell_id = Spell_id,
                Character_id = Character_id
            };
            spellsContext.KnownSpells.Add(learnedSpell);
        }

        public void CharacterForgetsSpell(Guid Character_id, Guid Spell_id)
        {
            Spell_Character foundRecord = (from S_C in spellsContext.KnownSpells
                                          where S_C.Spell_id == Spell_id & S_C.Character_id == Character_id
                                          select S_C).First();
            spellsContext.KnownSpells.Remove(foundRecord);

        }


        public void AddSpellMaterials(Material material)
        {
            spellsContext.Materials.Add(material);
        }
        public Material GetSpellMaterials(Guid Spell_id)
        {
            return spellsContext.Materials.Find(Spell_id);
        }
        public void DeleteSpellMaterials(Material material)
        {
            spellsContext.Materials.Remove(material);
        }
        public void DeleteSpellMaterialsById(Guid Spell_id)
        {
            Material foundMaterial = spellsContext.Materials.Find(Spell_id);
            spellsContext.Materials.Remove(foundMaterial);
        }

        //When constructing this repository, pass the generic repository the same context the real repository is based upon.
        public SpellsRepository(SpellsContext context) : base(context) { }
    }
}
