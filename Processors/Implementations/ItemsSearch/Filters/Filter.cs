using DnDProject.Backend.Processors.Implementations.ItemsSearch.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.ItemsSearch.Filters
{
    public abstract class Filter : ItemSearchGeneric
    {
        protected ItemSearchGeneric _toBeDecorated;

        public void setToBeDecorated(ItemSearchGeneric toBeDecorated)
        {
            _toBeDecorated = toBeDecorated;
        }


    }
}
