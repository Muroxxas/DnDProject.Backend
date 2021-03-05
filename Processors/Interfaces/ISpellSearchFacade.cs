using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Spells.DataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface ISpellSearchFacade
    {
        IEnumerable<Spell> searchSpells(string searchString, string getSpellsBy);
        IPagedList<foundSpellCM> searchSpellsToPagedList(string searchString, string getSpellsBy, int? page);
    }
}
