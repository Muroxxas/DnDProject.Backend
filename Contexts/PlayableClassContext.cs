using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Contexts
{
    public class PlayableClassContext : DbContext
    {
        public virtual DbSet<PlayableClass> Classes { get; set; }

        public virtual DbSet<ClassAbility> ClassAbilities { get; set; }

        public virtual DbSet<Subclass> Subclasses { get; set; }

        public virtual DbSet<Character_Class_Subclass> KnownClasses { get; set; }

        public virtual DbSet<SubclassAbility> SubclassAbilities { get; set; }

    }
}
