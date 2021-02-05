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

        //By having this ICharacterRepository as a public object, we can enable our services to access it's methods while obscuring the implementation, thus loosely coupling our data access system and our code!
        public ICharacterRepository Characters { get; private set; }
        public IHealthRepository HealthRecords { get; private set; }
        public ICurrencyRepository CurrencyRecords { get; private set; }
        public IIsProficientRepository ProficiencyRecords { get; private set; }
        public INotesRepository Notes { get; private set; }
        public IStatsRepository Stats { get; private set; }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }


        //Create and use different constructors depending on what DBs I need access to!
        public UnitOfWork(CharacterContext context)
        {
            _context = context;
            //Hmm. Looks like I would need to use a factory here to keep the implementation loosely coupled. Not sure how I would get Autofac to run in a library separate from my MVC project.
            Characters = RepositoryFactory.GetCharacterRepository(context);
            HealthRecords = RepositoryFactory.GetHealthRepository(context);
            CurrencyRecords = RepositoryFactory.GetCurrencyRepository(context);
            ProficiencyRecords = RepositoryFactory.GetIsProficientRepository(context);
            Notes = RepositoryFactory.GetNotesRepository(context);
            Stats = RepositoryFactory.GetStatsRepository(context);


        }


    }
}
