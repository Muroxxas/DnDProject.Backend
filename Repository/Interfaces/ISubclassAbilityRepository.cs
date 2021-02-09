using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface ISubclassAbilityRepository : IRepository<SubclassAbility>
    {
        IEnumerable<SubclassAbility> GetAbilitiesOfSubclass(Guid Subclass_id);
        IEnumerable<SubclassAbility> GetAbilitiesOfSubclassAtOrBelowLevel(Guid Subclass_id, int level);

    }
}
