using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.SpellsSearch.Filters
{
    public class NameContains : Filter
    {
        private string _contents { get; set; }


        public override IQueryable<Spell> GetSpells()
        {
            IQueryable<Spell> query = _toBeDecorated.GetSpells();
            IQueryable<Spell> decoratedQuery = query.Where(x => x.Name.Contains(_contents));
            return decoratedQuery;
        }
        public NameContains(string contents)
        {
            _contents = contents;
        }
    }
}
