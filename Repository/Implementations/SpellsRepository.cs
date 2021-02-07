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
            throw new NotImplementedException();
        }

        public IEnumerable<Spell> GetSpellsCastableBy(Guid Class_id)
        {
            throw new NotImplementedException();
        }

        public void CharacterLearnsSpell(Guid Character_id, Guid Spell_id)
        {
            throw new NotImplementedException();
        }

        public void CharacterForgetsSpell(Guid Character_id, Guid Spell_id)
        {
            throw new NotImplementedException();
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
