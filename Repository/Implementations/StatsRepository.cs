﻿using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    public class StatsRepository : Repository<Stats>, IStatsRepository
    {
        //cast the context inherited from the generic Repository as a CharacterContext.
        public CharacterContext characterContext { get { return Context as CharacterContext; } }

        //When constructing this repository, pass the generic repository the same context the real repository is based upon.
        public StatsRepository(CharacterContext context) : base(context) { }
    }
}
