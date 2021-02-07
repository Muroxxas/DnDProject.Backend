using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Contexts
{
    public class SpellsContext : DbContext
    {
        public virtual DbSet<Spell> Spells { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<Spell_Character> KnownSpells { get; set; }
    }
}
