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
    public class ClassAbilityRepository : Repository<ClassAbility>, IClassAbilityRepository
    {
        public PlayableClassContext _classContext { get { return Context as PlayableClassContext; } }

        public IEnumerable<ClassAbility> GetAbilitiesOfClass(Guid Class_id)
        {
            return _classContext.ClassAbilities.Where(x => x.Class_id == Class_id);
        }
        public IEnumerable<ClassAbility> GetAbilitiesOfClassAtOrBelowLevel(Guid Class_id, int level)
        {
            IEnumerable<ClassAbility> foundAbilities = _classContext.ClassAbilities.Where(x => x.Class_id == Class_id);
            IEnumerable<ClassAbility> abilitiesAtOrUnderLevel = foundAbilities.Where(x => x.LevelLearned <= level);

            return abilitiesAtOrUnderLevel;
        }


        public ClassAbilityRepository(PlayableClassContext context) : base(context) { }
    }
}
