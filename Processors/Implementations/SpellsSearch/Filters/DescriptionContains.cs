using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.SpellsSearch.Filters
{
    public class DescriptionContains : Filter
    {
        private string _contents { get; set; }

        public override IQueryable<Spell> GetSpells()
        {
            IQueryable<Spell> query = _toBeDecorated.GetSpells();
            IQueryable<Spell> decoratedQuery = query.Where(x => x.Description.ToLower().Contains(_contents.ToLower()));
            return decoratedQuery;
        }

        public DescriptionContains(string contents)
        {
            _contents = contents;
        }
    }
}
