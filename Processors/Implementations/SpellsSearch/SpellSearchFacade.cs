using DnDProject.Backend.Contexts;
using DnDProject.Backend.Mapping.Implementations.Generic;
using DnDProject.Backend.Processors.Implementations.SpellsSearch.Filters;
using DnDProject.Backend.Processors.Interfaces;
using DnDProject.Entities.Character.ViewModels.PartialViewModels.Components;
using DnDProject.Entities.Spells.DataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Implementations.SpellsSearch
{
    public class SpellSearchFacade : ISpellSearchFacade
    {
        SpellsContext _context;

        public IEnumerable<Spell> searchSpells(string searchString, string getSpellsBy)
        {
            return Search(searchString, getSpellsBy).ToList();
        }

        public IPagedList<foundSpellCM> searchSpellsToPagedList(String searchString, string getSpellsBy, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;

            IQueryable<Spell> query = Search(searchString, getSpellsBy);

            //Paginate the query, then get the set of items specified by the paginated query.
            //Increases efficiency, as I now only get the spells I need for the page, rather than all spells that fit the user's query.
            IPagedList<Spell> pagedQuery = query.ToPagedList(pageNumber, pageSize);
            List<foundSpellCM> CMList = new List<foundSpellCM>();

            foreach(Spell spell in pagedQuery)
            {
                foundSpellCM cm = buildFoundSpellCM(spell);
                CMList.Add(cm);
            }

            IPagedList<foundSpellCM> result = new PagedList<foundSpellCM>(CMList, pageNumber, pageSize);
            return result;           

        }

        private IQueryable<Spell> Search(string searchString, string getSpellsBy)
        {
            SpellSearchToDecorate toDecorate = new SpellSearchToDecorate(_context);

            Filter decorated = null;

            switch (getSpellsBy)
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
                    decorated = default;
                    break;                
            }

            return decorated.GetSpells();
        }

        private foundSpellCM buildFoundSpellCM(Spell spell)
        {
            ReadModelMapper<Spell, foundSpellCM> mapper = new ReadModelMapper<Spell, foundSpellCM>();
            foundSpellCM cm = mapper.mapDataModelToViewModel(spell);

            return cm;
        }
        public SpellSearchFacade(SpellsContext context)
        {
            _context = context;
        }
    }
}
