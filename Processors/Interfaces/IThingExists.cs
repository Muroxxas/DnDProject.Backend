using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Processors.Interfaces
{
    public interface IThingExists
    {
        bool characterExists(Guid Character_id);
        bool spellExists(Guid Spell_id);
        bool playableClassExists(Guid class_id);
        bool subclassExists(Guid subclass_id);
        bool subclassIsOfClass(Guid subclass_id, Guid class_id);
        bool raceExists(Guid race_id);
        bool itemExists(Guid item_id);
    }
}
