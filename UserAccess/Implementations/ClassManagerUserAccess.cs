using DnDProject.Backend.Unit_Of_Work.Interfaces;
using DnDProject.Backend.UserAccess.Interfaces;
using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Implementations
{
    public class ClassManagerUserAccess : BaseUserAccess, IClassManagerUserAccess
    {
        IUnitOfWork _worker;

        public void AddPlayableClass(PlayableClass playableClass)
        {
            _worker.Classes.Add(playableClass);
        }
        public void RemovePlayableClass(PlayableClass toBeRemoved)
        {
            _worker.Classes.Remove(toBeRemoved);
        }
        public void AddAbility(ClassAbility ability)
        {
            _worker.ClassAbilities.Add(ability);
        }
        public void AddAbilities(IEnumerable<ClassAbility> abilities)
        {
            _worker.ClassAbilities.AddRange(abilities);
        }
        
        public IEnumerable<ClassAbility> GetAllClassAbilities()
        {
            return _worker.ClassAbilities.GetAll();
        }
        public void RemoveClassAbility(ClassAbility toBeRemoved)
        {
            _worker.ClassAbilities.Remove(toBeRemoved);
        }


        public void AddSubclass(Subclass subclass)
        {
            _worker.Subclasses.Add(subclass);
        }
        public void AddSubclasses(IEnumerable<Subclass> subclasses)
        {
            _worker.Subclasses.AddRange(subclasses);
        }
        public void RemoveSubclass(Subclass toBeRemoved)
        {
            _worker.Subclasses.Remove(toBeRemoved);
        }



        public void AddSubclassAbility(SubclassAbility subclassAbility)
        {
            _worker.SubclassAbilities.Add(subclassAbility);
        }
        public void AddSubclassAbilities(IEnumerable<SubclassAbility> subclassAbilities)
        {
            _worker.SubclassAbilities.AddRange(subclassAbilities);
        }
        public void RemoveSubclassAbility(SubclassAbility toBeRemoved)
        {
            _worker.SubclassAbilities.Remove(toBeRemoved);
        }

        public ClassManagerUserAccess(IUnitOfWork worker) : base(worker)
        {
            _worker = worker;
        }
    }
}
