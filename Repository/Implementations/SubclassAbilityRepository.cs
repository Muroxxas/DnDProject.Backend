﻿using DnDProject.Backend.Contexts;
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
    public class SubclassAbilityRepository : Repository<SubclassAbility>, ISubclassAbilityRepository
    {
        public PlayableClassContext _classContext { get { return Context as PlayableClassContext; } }

        public IEnumerable<SubclassAbility> GetAllAbilitiesOfSubclass(Guid Subclass_id)
        {
            return _classContext.SubclassAbilities.Where(x => x.Subclass_id == Subclass_id).ToList();
        }
        public IEnumerable<SubclassAbility> GetAbilitiesOfSubclassAtOrBelowLevel(Guid Subclass_id, int level)
        {
            return _classContext.SubclassAbilities.Where(x => x.Subclass_id == Subclass_id && x.LevelLearned <= level).ToList();
        }

        public SubclassAbilityRepository(PlayableClassContext context) : base(context) { }
    }
}
