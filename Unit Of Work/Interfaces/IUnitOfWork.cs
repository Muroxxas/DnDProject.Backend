using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Unit_Of_Work.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        void SaveChangesAsync();
    }
}
