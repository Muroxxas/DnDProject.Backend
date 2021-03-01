using DnDProject.Backend.Contexts;
using DnDProject.Backend.Processors.Implementations.ItemsSearch.Generic;
using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.ItemsSearch
{
    public class ItemSearchToDecorate : ItemSearchGeneric
    {
        ItemsContext _itemsContext { get; set; }

        public override IQueryable<Item> GetItems()
        {
            IQueryable<Item> query = from item in _itemsContext.Items
                                     select item;

            return query;
        }

        public ItemSearchToDecorate(ItemsContext itemsContext)
        {
            _itemsContext = itemsContext;
        }
    }
}
