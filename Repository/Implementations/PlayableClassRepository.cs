using DnDProject.Backend.Contexts;
using DnDProject.Backend.Repository.Implementations.Generic;
using DnDProject.Backend.Repository.Interfaces;
using DnDProject.Backend.Repository.Interfaces.Generic;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Repository.Implementations
{
    class PlayableClassRepository : Repository<PlayableClass>, IPlayableClassRepository
    {
        public PlayableClassContext _classContext { get { return Context as PlayableClassContext; } }

        public IEnumerable<PlayableClass> GetClassesOfCharacter(Guid Character_id)
        {
            throw new NotImplementedException();
        }
        public Character_Class_Subclass GetKnownClassRecordOfCharacterAndClass(Guid Character_id, Guid Class_id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Character_Class_Subclass> GetAllKnownClassRecordsOfCharacter(Guid Character_id)
        {
            throw new NotImplementedException();
        }
        public void CharacterLearnsClass(Guid Character_id, Guid Class_id)
        {
            throw new NotImplementedException();
        }
        public void CharacterLearnsClass(Guid Character_id, Guid Class_id, Guid Subclass_id)
        {
            throw new NotImplementedException();
        }
        public void CharacterForgetsClass(Guid Character_id, Guid Class_id)
        {
            throw new NotImplementedException();
        }

        public PlayableClassRepository(PlayableClassContext context) : base(context) { }
    }
}
