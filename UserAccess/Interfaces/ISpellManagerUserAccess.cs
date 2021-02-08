using DnDProject.Entities.Spells.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Interfaces
{
    public interface ISpellManagerUserAccess : IBaseUserAccess
    {
        void AddSpell(Spell spell);
        void AddSpellMaterials(Material materials);
        void DeleteSpellMaterials(Material materials);
        void DeleteSpellMaterialsById(Guid Spell_id);
        void RemoveSpell(Spell spell);
    }
}
