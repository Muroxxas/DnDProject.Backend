using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface IMagicRepository : IRepository<Spell>
    {
        IEnumerable<Spell> GetSpellsKnownBy(Guid Character_id);
        IEnumerable<Spell> GetSpellsOfLevel(int level);
        IEnumerable<Spell> ForgetSpell(Guid Character_id, Guid Spell_id);
        void LearnSpell(Guid Character_id, Guid Spell_id);
    }
}
