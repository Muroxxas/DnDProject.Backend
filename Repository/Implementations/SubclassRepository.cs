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
            Character_Class_Subclass foundRecord = _classContext.KnownClasses.Where(x => x.Character_id == Character_id && x.Class_id == Class_id).First();
            if(foundRecord != null)
            {
                foundRecord.Subclass_id = Subclass_id;
            }
        }
        public IEnumerable<Subclass> GetAllSubclassesForClass(Guid Class_id)
        {
            return _classContext.Subclasses.Where(x => x.Class_id == Class_id).ToList();
        }

        public void CharacterOfClassForgetsSubclass(Guid Character_id, Guid Class_id, Guid Subclass_id)
        {
            Character_Class_Subclass foundRecord = _classContext.KnownClasses.Where(x => x.Character_id == Character_id && x.Class_id == Class_id).First();
            if (foundRecord != null)
            {
                foundRecord.Subclass_id = Guid.Empty;
            }
        }

        public SubclassRepository(PlayableClassContext context) : base(context) { }
    }
}
