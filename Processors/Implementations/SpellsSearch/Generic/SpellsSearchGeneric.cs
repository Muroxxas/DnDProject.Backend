using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.SpellsSearch.Generic
{
    public abstract class SpellsSearchGeneric
    {
        public abstract IQueryable<Spell> GetSpells();
    }
}
