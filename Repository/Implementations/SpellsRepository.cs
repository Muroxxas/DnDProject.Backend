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
            throw new NotImplementedException();
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

        //When constructing this repository, pass the generic repository the same context the real repository is based upon.
        public SpellsRepository(SpellsContext context) : base(context) { }
    }
}
