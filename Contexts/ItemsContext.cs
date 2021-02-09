using DnDProject.Entities.Items.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Contexts
{
    public class ItemsContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Character_Item> HeldItems { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Item_Tag> Item_Tags { get; set; }
        public ItemsContext() { }
    }
}
