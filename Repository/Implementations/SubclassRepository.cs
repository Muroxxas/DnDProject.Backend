using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class SubclassRepository : Repository<Subclass>, ISubclassRepository
    {
        public PlayableClassContext _classContext { get { return Context as PlayableClassContext; } }

        public void CharacterOfClassLearnsSubclass(Guid Character_id, Guid Class_id, Guid Subclass_id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Subclass> GetAllSubclassesForClass(Guid Class_id)
        {
            throw new NotImplementedException();
        }

        public void CharacterForgetsSubclassOfClass(Guid Character_id, Guid Class_id, Guid Subclass_id)
        {
            throw new NotImplementedException();
        }

        public SubclassRepository(PlayableClassContext context) : base(context) { }
    }
}
