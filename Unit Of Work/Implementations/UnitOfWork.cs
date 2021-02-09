using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Backend.Unit_Of_Work.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Unit_Of_Work.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private CharacterContext _context;
        private SpellsContext _spellsContext;
        private ItemsContext _itemsContext;

        //By having this ICharacterRepository as a public object, we can enable our services to access it's methods while obscuring the implementation, thus loosely coupling our data access system and our code!
        public ICharacterRepository Characters { get; private set; }
        public IHealthRepository HealthRecords { get; private set; }
        public ICurrencyRepository CurrencyRecords { get; private set; }
        public IIsProficientRepository ProficiencyRecords { get; private set; }
        public INotesRepository Notes { get; private set; }
        public IStatsRepository Stats { get; private set; }
        public ISpellsRepository Spells { get; private set; }
        public IItemsRepository Items { get; private set; }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            if(_context != null)
            {
                _context.SaveChanges();
            }
            if(_spellsContext != null)
            {
                _spellsContext.SaveChanges();
            }
        }
        public void SaveChangesAsync()
        {
            if(_context != null)
            {
                _context.SaveChangesAsync();
            }
            if(_spellsContext != null)
            {
                _spellsContext.SaveChangesAsync();
            }
        }


        //Create and use different constructors depending on what DBs I need access to!
        public UnitOfWork(CharacterContext context)
        {
            _context = context;
            //Hmm. Looks like I would need to use a factory here to keep the implementation loosely coupled. Not sure how I would get Autofac to run in a library separate from my MVC project.
            //Should probably go review TIme Coreys video on autofac.
            Characters = RepositoryFactory.GetCharacterRepository(context);
            HealthRecords = RepositoryFactory.GetHealthRepository(context);
            CurrencyRecords = RepositoryFactory.GetCurrencyRepository(context);
            ProficiencyRecords = RepositoryFactory.GetIsProficientRepository(context);
            Notes = RepositoryFactory.GetNotesRepository(context);
            Stats = RepositoryFactory.GetStatsRepository(context);


        }
        public UnitOfWork(SpellsContext SpellsContext)
        {
            _spellsContext = SpellsContext;
            Spells = RepositoryFactory.GetSpellsRepository(SpellsContext);
        }

        public UnitOfWork(CharacterContext context, SpellsContext SpellsContext)
        {
            _context = context;
            Characters = RepositoryFactory.GetCharacterRepository(context);
            HealthRecords = RepositoryFactory.GetHealthRepository(context);
            CurrencyRecords = RepositoryFactory.GetCurrencyRepository(context);
            ProficiencyRecords = RepositoryFactory.GetIsProficientRepository(context);
            Notes = RepositoryFactory.GetNotesRepository(context);
            Stats = RepositoryFactory.GetStatsRepository(context);

            _spellsContext = SpellsContext;
            Spells = RepositoryFactory.GetSpellsRepository(SpellsContext);
        }

        public UnitOfWork(ItemsContext itemsContext)
        {
            _itemsContext = itemsContext;
            Items = RepositoryFactory.GetItemsRepository(itemsContext);
        }

        public UnitOfWork(CharacterContext context, ItemsContext itemsContext)
        {
            _context = context;
            Characters = RepositoryFactory.GetCharacterRepository(context);
            HealthRecords = RepositoryFactory.GetHealthRepository(context);
            CurrencyRecords = RepositoryFactory.GetCurrencyRepository(context);
            ProficiencyRecords = RepositoryFactory.GetIsProficientRepository(context);
            Notes = RepositoryFactory.GetNotesRepository(context);
            Stats = RepositoryFactory.GetStatsRepository(context);

            _itemsContext = itemsContext;
            Items = RepositoryFactory.GetItemsRepository(itemsContext);
        }

        public UnitOfWork(CharacterContext context, SpellsContext spellsContext, ItemsContext itemsContext)
        {
            _context = context;
            Characters = RepositoryFactory.GetCharacterRepository(context);
            HealthRecords = RepositoryFactory.GetHealthRepository(context);
            CurrencyRecords = RepositoryFactory.GetCurrencyRepository(context);
            ProficiencyRecords = RepositoryFactory.GetIsProficientRepository(context);
            Notes = RepositoryFactory.GetNotesRepository(context);
            Stats = RepositoryFactory.GetStatsRepository(context);

            _spellsContext = spellsContext;
            Spells = RepositoryFactory.GetSpellsRepository(spellsContext);

            _itemsContext = itemsContext;
            Items = RepositoryFactory.GetItemsRepository(itemsContext);
        }


    }
}
