using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Interfaces
{
    public interface IPlayableClassRepository : IRepository<PlayableClass>
    {
        IEnumerable<PlayableClass> GetClassesOfCharacter(Guid Character_id);
        Character_Class_Subclass GetKnownClassRecordOfCharacterAndClass(Guid Character_id, Guid Class_id);
        IEnumerable<Character_Class_Subclass> GetAllKnownClassRecordsOfCharacter(Guid Character_id);

        void CharacterLearnsClass(Guid Character_id, Guid Class_id);
        void CharacterLearnsClasses(Guid Character_id, IEnumerable<Guid> Class_ids);
        void CharacterLearnsClass(Character_Class_Subclass record);
        void CharacterForgetsClass(Guid Character_id, Guid Class_id);
    }
}
