using DnDProject.Entities.Character.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DnDProject.Backend.Contexts
{
    public class CharacterContext : DbContext
    {
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<IsProficient> Proficiencies { get; set; }
    }
}
