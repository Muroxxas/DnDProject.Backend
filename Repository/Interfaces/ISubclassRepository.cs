using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface ISubclassRepository : IRepository<Subclass>
    {
        void CharacterOfClassLearnsSubclass(Guid Character_id, Guid Class_id, Guid Subclass_id);
        IEnumerable<Subclass> GetAllSubclassesForClass(Guid Class_id);
        void CharacterForgetsSubclassOfClass(Guid Character_id, Guid Class_id, Guid Subclass_id);
    }
}
