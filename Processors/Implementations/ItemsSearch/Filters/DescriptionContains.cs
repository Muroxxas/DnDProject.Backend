using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.ItemsSearch.Filters
{
    public class DescriptionContains : Filter
    {

        private string _whatIsContained;

        public override IQueryable<Item> GetItems()
        {
            IQueryable<Item> query = _toBeDecorated.GetItems();
            IQueryable<Item> decoratedQuery = query.Where(x => x.Description.Contains(_whatIsContained));
            return decoratedQuery;
        }

        public DescriptionContains(string whatIsContained)
        {
            _whatIsContained = whatIsContained;
        }
    }
}
