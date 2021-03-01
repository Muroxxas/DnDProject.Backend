using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Items.DataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface IItemsSearchFacade
    {
        IEnumerable<Item> searchItems(string searchString, string getItemsBy, string currentFilter);
        IPagedList<foundItemCM> searchItemsToPagedList(string searchString, string getItemsBy, string currentFilter, int? page);
    }
}
