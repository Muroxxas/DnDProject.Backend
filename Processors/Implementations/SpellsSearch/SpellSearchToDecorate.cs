using DnDProject.Backend.Contexts;
using DnDProject.Backend.Processors.Implementations.SpellsSearch.Generic;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.SpellsSearch
{
    public class SpellSearchToDecorate : SpellsSearchGeneric
    {
        private SpellsContext _spellsContext { get; set; }

        public override IQueryable<Spell> GetSpells()
        {
            IQueryable<Spell> query = from spell in _spellsContext.Spells
                                      select spell;

            return query;
        }

        public SpellSearchToDecorate(SpellsContext spellsContext)
        {
            _spellsContext = spellsContext;
        }
    }
}
