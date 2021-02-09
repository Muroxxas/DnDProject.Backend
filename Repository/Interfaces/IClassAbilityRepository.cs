using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface IClassAbilityRepository : IRepository<ClassAbility>
    {
        IEnumerable<ClassAbility> GetAbilitiesOfClass(Guid Class_id);
        IEnumerable<ClassAbility> GetAbilitiesOfClassAtOrBelowLevel(Guid Class_id, int level);
    }
}
