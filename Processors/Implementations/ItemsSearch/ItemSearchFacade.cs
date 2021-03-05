using DnDProject.Backend.Contexts;
using DnDProject.Backend.Mapping.Implementations.Generic;
using DnDProject.Backend.Processors.Implementations.ItemsSearch.Filters;
using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Items.DataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.ItemsSearch
{
    public class ItemSearchFacade : IItemsSearchFacade
    {
        ItemsContext _context;

        public IEnumerable<Item> searchItems(string searchString, string getItemsBy)
        {
            return Search(searchString, getItemsBy).ToList();
        }

        public IPagedList<foundItemCM> searchItemsToPagedList(string searchString, string getItemsBy, int? page)
        {            

            int pageNumber = (page ?? 1);
            int pageSize = 20;

            IQueryable<Item> query = Search(searchString, getItemsBy);

            //Paginate the query, then get the set of items specified by the paginated query.
            //Increases efficiency, as I now only get the items I need for the page.
            IPagedList<Item> pagedQuery = query.ToPagedList(pageNumber, pageSize);
            List<foundItemCM> CMList = new List<foundItemCM>();

            foreach(Item item in pagedQuery)
            {
                foundItemCM cm = buildFoundItemCM(item);
                CMList.Add(cm);
            }

            IPagedList<foundItemCM> result = new PagedList<foundItemCM>(CMList, pageNumber, pageSize);
            return result;

        }

        //Uses a decorator pattern to construct and return a filtered IQueryable.
        private IQueryable<Item> Search(string searchString, string getItemsBy)
        {

            ItemSearchToDecorate toDecorate = new ItemSearchToDecorate(_context);

            Filter decorated = null;

            switch (getItemsBy)
            {
                case "Name":
                    var nameContains = new NameContains(searchString);
                    nameContains.setToBeDecorated(toDecorate);
                    decorated = nameContains;
                    break;

                case "Description":
                    var descriptionContains = new DescriptionContains(searchString);
                    descriptionContains.setToBeDecorated(toDecorate);
                    decorated = descriptionContains;
                    break;

                default: 
                    var defaulted = new NameContains(searchString);
                    defaulted.setToBeDecorated(toDecorate);
                    decorated = defaulted;
                    break;
            }

            return decorated.GetItems();
        }

        private foundItemCM buildFoundItemCM(Item item)
        {
            ReadModelMapper<Item, foundItemCM> mapper = new ReadModelMapper<Item, foundItemCM>();
            foundItemCM cm = mapper.mapDataModelToViewModel(item);

            return cm;
        }
        public ItemSearchFacade(ItemsContext context)
        {
            _context = context;
        }
    }
}
