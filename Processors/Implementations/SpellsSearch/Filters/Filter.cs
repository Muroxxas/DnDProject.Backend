using DnDProject.Backend.Processors.Implementations.SpellsSearch.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.SpellsSearch.Filters
{
    public abstract class Filter : SpellsSearchGeneric
    {
        protected SpellsSearchGeneric _toBeDecorated;

        public void setToBeDecorated(SpellsSearchGeneric toBeDecorated)
        {
            _toBeDecorated = toBeDecorated;
        }
    }
}
