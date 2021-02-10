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
    public class PlayableClassRepository : Repository<PlayableClass>, IPlayableClassRepository
    {
        public PlayableClassContext _classContext { get { return Context as PlayableClassContext; } }

        public IEnumerable<PlayableClass> GetClassesOfCharacter(Guid Character_id)
        {
            List<Character_Class_Subclass> CharacterKnownClassRecords = _classContext.KnownClasses.Where(x => x.Character_id == Character_id).ToList();

            List<PlayableClass> foundClasses = new List<PlayableClass>();
            foreach(Character_Class_Subclass knownClass in CharacterKnownClassRecords)
            {
                foundClasses.Add(_classContext.Classes.Where(x => x.Class_id == knownClass.Class_id).First());
            }
            return foundClasses;
        }
        public Character_Class_Subclass GetKnownClassRecordOfCharacterAndClass(Guid Character_id, Guid Class_id)
        {
            return _classContext.KnownClasses.Where(x => x.Character_id == Character_id && x.Class_id == Class_id).First();
        }
        public IEnumerable<Character_Class_Subclass> GetAllKnownClassRecordsOfCharacter(Guid Character_id)
        {
            return _classContext.KnownClasses.Where(x => x.Character_id == Character_id);
        }
        public void CharacterLearnsClass(Guid Character_id, Guid Class_id)
        {
            Character_Class_Subclass learnedClassRecord = new Character_Class_Subclass
            {
                Character_id = Character_id,
                Class_id = Class_id,
                ClassLevel = 1,
                RemainingHitDice = 1
            };
            _classContext.KnownClasses.Add(learnedClassRecord);
        }
        public void CharacterLearnsClasses(Guid Character_id, IEnumerable<Guid> Class_ids)
        {
            List<Character_Class_Subclass> records = new List<Character_Class_Subclass>();

            foreach(Guid class_id in Class_ids)
            {
                Character_Class_Subclass record = new Character_Class_Subclass
                {
                    Character_id = Character_id,
                    Class_id = class_id,
                    ClassLevel = 1,
                    RemainingHitDice = 1
                };
                records.Add(record);
            }
            _classContext.KnownClasses.AddRange(records);
        }
        public void CharacterLearnsClass(Guid Character_id, Guid Class_id, Guid Subclass_id)
        {
            Character_Class_Subclass learnedClassRecord = new Character_Class_Subclass
            {
                Character_id = Character_id,
                Class_id = Class_id,
                Subclass_id = Subclass_id,
                ClassLevel = 1,
                RemainingHitDice = 1
            };
            _classContext.KnownClasses.Add(learnedClassRecord);
        }
        public void CharacterForgetsClass(Guid Character_id, Guid Class_id)
        {
            Character_Class_Subclass foundRecord = _classContext.KnownClasses.Where(x => x.Character_id == Character_id & x.Class_id == Class_id).First();
            if(foundRecord != null)
            {
                _classContext.KnownClasses.Remove(foundRecord);
            }
        }

        public PlayableClassRepository(PlayableClassContext context) : base(context) { }
    }
}
