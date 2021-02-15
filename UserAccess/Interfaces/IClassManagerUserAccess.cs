using DnDProject.Entities.Class.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.UserAccess.Interfaces
{
    public interface IClassManagerUserAccess : IBaseUserAccess
    {
        void AddPlayableClass(PlayableClass playableClass);
        void RemovePlayableClass(PlayableClass toBeRemoved);
        void AddAbility(ClassAbility ability);
        void AddAbilities(IEnumerable<ClassAbility> abilities);
        IEnumerable<ClassAbility> GetAllClassAbilities();
        void RemoveClassAbility(ClassAbility toBeRemoved);

        void AddSubclass(Subclass subclass);
        void AddSubclasses(IEnumerable<Subclass> subclasses);
        void RemoveSubclass(Subclass subclass);


        void AddSubclassAbility(SubclassAbility subclassAbility);
        void AddSubclassAbilities(IEnumerable<SubclassAbility> subclassAbilities);
        void RemoveSubclassAbility(SubclassAbility toBeRemoved);


    }
}
