using DnDProject.Backend.Unit_Of_Work.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Implementations
{
    public class SpellManagerUserAccess : BaseUserAccess, ISpellManagerUserAccess
    {
        private IUnitOfWork _worker { get; set; }

        public void AddSpell(Spell spell)
        {
            _worker.Spells.Add(spell);
        }
        public void AddSpellMaterials(Material materials)
        {
            _worker.Spells.AddSpellMaterials(materials);
        }
        public void DeleteSpellMaterials(Material materials)
        {
            _worker.Spells.DeleteSpellMaterials(materials);
        }
        public void DeleteSpellMaterialsById(Guid Spell_id)
        {
            _worker.Spells.DeleteSpellMaterialsById(Spell_id);
        }
        public void RemoveSpell(Spell spell)
        {
            _worker.Spells.Remove(spell);
        }

        public SpellManagerUserAccess(IUnitOfWork worker) : base(worker) 
        {
            _worker = worker;
        }
    }
}
