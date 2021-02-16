using DnDProject.Entities.Races.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Contexts
{
    public class RaceContext : DbContext
    {
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceAbility> RaceAbilities { get; set; }

        public RaceContext() { }
    }
}
