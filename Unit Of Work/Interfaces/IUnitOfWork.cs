using DnDProject.Backend.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Unit_Of_Work.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICharacterRepository Characters { get;  }
        IHealthRepository HealthRecords { get;  }
        ICurrencyRepository CurrencyRecords { get;  }
        IIsProficientRepository ProficiencyRecords { get;  }
        INotesRepository Notes { get;  }
        IStatsRepository Stats { get;  }
        ISpellsRepository Spells { get; }


        void SaveChanges();
        void SaveChangesAsync();
    }
}
