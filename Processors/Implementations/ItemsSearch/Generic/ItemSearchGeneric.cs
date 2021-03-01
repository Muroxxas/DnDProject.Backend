using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.ItemsSearch.Generic
{
    public abstract class ItemSearchGeneric
    {
        public abstract IQueryable<Item> GetItems();
    }
}
